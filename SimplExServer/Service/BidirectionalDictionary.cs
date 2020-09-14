using System;
using System.Collections.Generic;

namespace SimplExServer.Service
{
    class BidirectionalDictionary<TFirst, TSecond>
    {
        private readonly IDictionary<TFirst, TSecond> firstToSecond = new Dictionary<TFirst, TSecond>();
        private readonly IDictionary<TSecond, TFirst> secondToFirst = new Dictionary<TSecond, TFirst>();
        public TSecond this[TFirst key]
        {
            get => firstToSecond[key]; set
            {
                secondToFirst.Remove(firstToSecond[key]);
                secondToFirst.Add(value, key);
                firstToSecond[key] = value;
            }
        }
        public TFirst this[TSecond key]
        {
            get => secondToFirst[key]; set
            {
                firstToSecond.Remove(secondToFirst[key]);
                firstToSecond.Add(value, key);
                secondToFirst[key] = value;
            }
        }

        public ICollection<TFirst> FirstValues => secondToFirst.Values;
        public ICollection<TSecond> SecondValues => firstToSecond.Values;
        public int Count => firstToSecond.Count;

        public void Add(TFirst first, TSecond second)
        {

            if (firstToSecond.ContainsKey(first) || secondToFirst.ContainsKey(second))
                throw new ArgumentException("Duplicate first or second");
            firstToSecond.Add(first, second);
            secondToFirst.Add(second, first);
        }
        public bool TryAdd(TFirst first, TSecond second)
        {
            if (firstToSecond.ContainsKey(first) || secondToFirst.ContainsKey(second))
                return false;

            firstToSecond.Add(first, second);
            secondToFirst.Add(second, first);
            return true;
        }

        public bool TryGetValue(TFirst first, out TSecond second) => firstToSecond.TryGetValue(first, out second);
        public bool TryGetValue(TSecond second, out TFirst first) => secondToFirst.TryGetValue(second, out first);

        public bool Contains(TFirst first) => firstToSecond.ContainsKey(first);
        public bool Contains(TSecond second) => secondToFirst.ContainsKey(second);
        public bool Remove(TFirst first)
        {
            if (firstToSecond.TryGetValue(first, out TSecond second))
            {
                firstToSecond.Remove(first);
                secondToFirst.Remove(second);
                return true;
            }
            else return false;
        }
        public bool Remove(TSecond second)
        {
            if (secondToFirst.TryGetValue(second, out TFirst first))
            {
                firstToSecond.Remove(first);
                secondToFirst.Remove(second);
                return true;
            }
            else return false;
        }
        public void Clear()
        {
            firstToSecond.Clear();
            secondToFirst.Clear();
        }
    }
}
