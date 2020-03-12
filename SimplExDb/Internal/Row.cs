using System.Data;
namespace SimplExDb.Internal
{
    internal class Row
    {
        public readonly DataRow DataRow;
        public readonly object Instance;
        public Row(DataRow dataRow, object instance)
        {
            DataRow = dataRow;
            Instance = instance;
        }
    }
}
