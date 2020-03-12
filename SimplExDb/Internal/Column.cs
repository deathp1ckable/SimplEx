using MySql.Data.MySqlClient;
using System;
namespace SimplExDb.Internal
{
    internal class Column
    {
        public string ColumnName { get; private set; }
        public Type ColumnType { get; private set; }
        public bool AllowNull { get; private set; }
        private Func<object> columnGetter;
        private Action<object> columnSetter;
        public Column(string columnName, Func<object> columnGetter, Action<object> columnSetter, Type type, bool allowNull)
        {
            ColumnName = columnName;
            ColumnType = type;
            AllowNull = allowNull;
            this.columnGetter = columnGetter;
            this.columnSetter = columnSetter;
        }
        public Column(string columnName, Func<object> columnGetter, Action<object> columnSetter, Type type)
        {
            ColumnName = columnName;
            ColumnType = type;
            AllowNull = false;
            this.columnGetter = columnGetter;
            this.columnSetter = columnSetter;
        }
        public object GetValue() => columnGetter();
        public void SetValue(object value) => columnSetter(value);
    }
}
