using System;
using System.Timers;
using System.Collections.Generic;
namespace SimplExNetworking.UniqueIdentifiers
{
    public class UniqueIdHost
    {
        Timer timer;
        uint FreedIndexes = 0;
       internal  Queue<uint> UnusedIdentifiers;
        bool timerStarted;
        bool needToStart;
        public uint LastIndex { get; private set; }
        public UniqueIdHost(double timeout)
        {
            UnusedIdentifiers = new Queue<uint>();
            timer = new Timer(timeout);
            timer.Elapsed += ReleaseHandler;
        }
        public UniqueId CreateUniqueID()
        {
            if (FreedIndexes > 0)
            {
                FreedIndexes--;
                return new UniqueId(UnusedIdentifiers.Dequeue(), this);
            }
            else return new UniqueId(LastIndex++, this);
        }
        uint i;
        public void RegisterUniqueID(UniqueId uniqueID)
        {
            if (uniqueID.Id >= LastIndex)
            {
                uniqueID.isCustom = false;
                uniqueID.Host = this;
                for (i = LastIndex; i < uniqueID.Id; i++)
                {
                    UnusedIdentifiers.Enqueue(i);
                    FreedIndexes++;
                }
                LastIndex = uniqueID.Id + 1;
            }
            else if (UnusedIdentifiers.Contains(uniqueID.Id))
            {
                uniqueID.isCustom = false;
                uniqueID.Host = this;
                List<uint> tmp = new List<uint>(UnusedIdentifiers.ToArray());
                tmp.Remove(uniqueID.Id);
                UnusedIdentifiers = new Queue<uint>(tmp);
                FreedIndexes--;
            }
            else
                throw new InvalidOperationException("Identifier allready exists.");
        }
        public void RegisterUniqueIDArray(UniqueId[] uniqueIDs)
        {
            foreach (UniqueId id in uniqueIDs)
                RegisterUniqueID(id);
        }
        public void DisposeUniqueID(UniqueId uniqueID)
        {
            if (!ReferenceEquals(this, uniqueID.Host))
                throw new InvalidOperationException("Invalid host.");
            else if (uniqueID.Id > LastIndex)
                throw new InvalidOperationException("Identifier is out of range.");
            else if (UnusedIdentifiers.Contains(uniqueID.Id))
                throw new InvalidOperationException("This Identifier was already disposed.");
            else
            {
                UnusedIdentifiers.Enqueue(uniqueID.Id);
                if (!timerStarted)
                {
                    timer.Start();
                    timerStarted = true;
                }
                else needToStart = true;
            }
        }
        private void ReleaseHandler(object sender, ElapsedEventArgs e)
        {
            timerStarted = false;
            if (needToStart)
            {
                timer.Start();
                timerStarted = true;
            }
            FreedIndexes++;
        }
    }
}
