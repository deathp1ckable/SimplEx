using System;
namespace SimplExNetworking.UniqueIdentifiers
{
    public class UniqueId : IDisposable
    {
        public uint Id { get; private set; }
        public UniqueIdHost Host { get; internal set; }
        internal bool isCustom;
        private bool isDisposed;
        internal UniqueId(uint id, UniqueIdHost host)
        {
            this.Id = id;
            Host = host;
        }
        public UniqueId(uint ID)
        {
            this.Id = ID;
            isCustom = true;
        }
        public void Dispose()
        {
            if (!isDisposed && !isCustom)
            {
                Host.DisposeUniqueID(this);
                isDisposed = true;
            }
            else throw new InvalidOperationException();
        }
        public override string ToString() => $"{GetType().Name.ToString()}: {Id}";
        public override bool Equals(object obj) => ReferenceEquals((obj as UniqueId).Host, Host) && ((UniqueId)obj).Id == Id;
        public static implicit operator uint(UniqueId param) => param.Id;
        public static bool operator ==(UniqueId uniqueIdA, UniqueId uniqueIdB) => uniqueIdA.Id == uniqueIdB.Id;
        public static bool operator !=(UniqueId uniqueIdA, UniqueId uniqueIdB) => uniqueIdA.Id != uniqueIdB.Id;
        public override int GetHashCode() => (int)Id;
    }
}
