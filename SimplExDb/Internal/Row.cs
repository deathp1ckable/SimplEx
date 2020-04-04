using System.Data;
namespace SimplExDb.Internal
{
    internal class Row
    {
        public DataRow DataRow { get; private set; }
        public object Instance { get; private set; }
        public bool IsCommited { get; set; }

        public Row(DataRow dataRow, object instance)
        {
            DataRow = dataRow;
            Instance = instance;
        }
    }
}
