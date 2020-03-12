using MySql.Data.MySqlClient;
using SimplExDb.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SimplExDb.Database
{
    public abstract class ClassMap<T> where T : class
    {
        public string TableName { get; private set; }
        public T Instance { get; set; }
        public string KeyColumnName { get; private set; }
        internal Column[] Columns { get; private set; }
        internal Dictionary<Type, ForeignColumn> ForeignKeyNames { get; private set; } = new Dictionary<Type, ForeignColumn>();
        private readonly Dictionary<string, Column> columnsDictionary = new Dictionary<string, Column>();
        public ClassMap()
        {
            Instance = (T)Activator.CreateInstance(typeof(T));
            MapClass();
            Columns = columnsDictionary.Values.ToArray();
        }
        public object GetColumnValue(string columnName)
            => columnsDictionary[columnName].GetValue();
        public void SetColumnValue(string columnName, object value)
            => columnsDictionary[columnName].SetValue(value);
        protected void MapId(string columnName) =>
            KeyColumnName = columnName;
        protected void Map<TType>(string columnName, Func<TType> columnGetter, Action<TType> columnSetter)
        {
            Func<object> getter = () => columnGetter();
            Action<object> setter = (a) => columnSetter((TType)a);
            columnsDictionary.Add(columnName, new Column(columnName, getter, setter, typeof(TType)));
        }
        protected void Map<TType>(string columnName, Func<TType> columnGetter, Action<TType> columnSetter, bool allowNull)
        {
            Func<object> getter = () => columnGetter();
            Action<object> setter = (a) => columnSetter((TType)a);
            columnsDictionary.Add(columnName, new Column(columnName, getter, setter, typeof(TType), allowNull));
        }
        protected void Foreign<TOwner>(string columnName)
          => ForeignKeyNames.Add(typeof(TOwner), new ForeignColumn(columnName, false));
        protected void Foreign<TOwner>(string columnName, bool allowNull)
          => ForeignKeyNames.Add(typeof(TOwner), new ForeignColumn(columnName, allowNull));
        protected void Table(string tableName) => TableName = tableName;
        protected abstract void MapClass();
    }
    internal class ForeignColumn
    {
        public string ColumnName { get; private set; }
        public bool AllowNull { get; private set; }
        public ForeignColumn(string columnName, bool allowNull)
        {
            ColumnName = columnName;
            AllowNull = allowNull;
        }
    }
}
