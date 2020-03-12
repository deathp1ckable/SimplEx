using System.Collections.Generic;
namespace SimplExNetworking.Internal
{
    internal class ClientsDictionary
    {
        Dictionary<uint, Client> pairs = new Dictionary<uint, Client>();
        public List<Client> Values { get; private set; } = new List<Client>();
        public Client this[uint key] { get => pairs[key]; set => pairs[key] = value; }
        public ICollection<uint> Keys => pairs.Keys;
        public int Count => Values.Count;
        public void Add(Client value)
        {
            pairs.Add(value == null ? 0 : value.uniqueID.Id, value);
            Values.Add(value);
        }
        public void Clear()
        {
            pairs.Clear();
            Values.Clear();
        }
        public bool ContainsKey(uint key) => pairs.ContainsKey(key);
        public bool Remove(uint key)
        {
            Values.Remove(pairs[key]);
            return pairs.Remove(key);
        }
        public bool TryGetValue(uint key, out Client value) => pairs.TryGetValue(key, out value);
    }
}
