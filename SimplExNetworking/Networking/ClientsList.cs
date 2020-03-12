using SimplExNetworking.Internal;
using System.Collections;
using System.Collections.Generic;
namespace SimplExNetworking.Networking
{
    public class ClientsList : IEnumerable<uint>
    {
        private ClientsDictionary dictionary;
        internal ClientsList(ClientsDictionary dictionary)
        {
            this.dictionary = dictionary;
        }
        public int Count => dictionary.Values.Count;
        public uint this[int index] { get => dictionary.Values[index].uniqueID.Id; }
        public int IndexOf(uint item) => dictionary.Values.IndexOf(dictionary[item]);
        public bool Contains(uint item) => dictionary.Values.Contains(dictionary[item]);
        public void CopyTo(uint[] array, int arrayIndex) => dictionary.Keys.CopyTo(array, arrayIndex);

        public IEnumerator<uint> GetEnumerator() => dictionary.Keys.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => dictionary.Keys.GetEnumerator();
    }
}
