using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace SimplExDb.Database
{
    public abstract class SchemaMap : IDisposable
    {
        public string DatabaseName { get; private set; }
        public DataSet SchemaDataSet { get; private set; }
        public Dictionary<Type, string> MappedDataTypes { get; private set; } = new Dictionary<Type, string>();
        private readonly Dictionary<Type, object> maps = new Dictionary<Type, object>();
        protected SchemaMap()
        {
            MapSchema();
        }
        protected void Database(string databaseName)
        {
            DatabaseName = databaseName;
            if (SchemaDataSet == null)
                SchemaDataSet = new DataSet(DatabaseName);
            else
                SchemaDataSet.DataSetName = DatabaseName;
        }
        protected void MapClass<TClass, TMap>() where TClass : class where TMap : ClassMap<TClass>
        {
            if (SchemaDataSet == null)
                throw new Exception("Database was not assigned. Call Database() function before mapping.");
            ClassMap<TClass> map = (ClassMap<TClass>)Activator.CreateInstance(typeof(TMap));
            int i;
            DataTable table = new DataTable(map.TableName);
            table.PrimaryKey = new[] { table.Columns.Add(map.KeyColumnName) };
            table.PrimaryKey[0].AllowDBNull = false;
            table.PrimaryKey[0].DataType = typeof(int);
            ForeignColumn[] foreigns = map.ForeignKeyNames.Values.ToArray();
            for (i = 0; i < map.Columns.Length; i++)
            {
                DataColumn column = table.Columns.Add(map.Columns[i].ColumnName);
                column.AllowDBNull = map.Columns[i].AllowNull;
                column.DataType = map.Columns[i].ColumnType;
            }
            for (i = 0; i < foreigns.Length; i++)
            {
                DataColumn column = table.Columns.Add(foreigns[i].ColumnName);
                column.AllowDBNull = foreigns[i].AllowNull;
                column.DataType = typeof(int);
            }
            SchemaDataSet.Tables.Add(table);
            maps.Add(typeof(TClass), map);
        }
        protected void Relation<TParentClass, TChildClass>(Rule deleteRule, Rule updateRule) where TParentClass : class where TChildClass : class
        {
            if (SchemaDataSet == null)
                throw new Exception("Database was not assigned. Call Database() function before mapping.");
            ClassMap<TParentClass> parent = GetClassMapInstance<TParentClass>();
            ClassMap<TChildClass> child = GetClassMapInstance<TChildClass>();
            DataRelation relation = SchemaDataSet.Relations.Add($"{typeof(TParentClass).Name}_{typeof(TChildClass).Name}_Rl", SchemaDataSet.Tables[parent.TableName].Columns[parent.KeyColumnName],
                 SchemaDataSet.Tables[child.TableName].Columns[child.ForeignKeyNames[typeof(TParentClass)].ColumnName]);
            relation.ChildKeyConstraint.DeleteRule = deleteRule;
            relation.ChildKeyConstraint.UpdateRule = updateRule;
        }
        protected void MapDataType<TType>(string dbTypeName)
        => MappedDataTypes.Add(typeof(TType), dbTypeName);
        public ClassMap<T> GetClassMapInstance<T>(T instance) where T : class
        {
            ClassMap<T> classMap = (ClassMap<T>)maps[typeof(T)];
            classMap.Instance = instance;
            return classMap;
        }
        public ClassMap<T> GetClassMapInstance<T>() where T : class => (ClassMap<T>)maps[typeof(T)];
        public DataRelation GetRelation(string parentTable, string childTable)
        {
            DataTable parent = SchemaDataSet.Tables[parentTable];
            DataTable child = SchemaDataSet.Tables[childTable];
            for (int i = 0, j; i < parent.ChildRelations.Count; i++)
                for (j = 0; j < child.ParentRelations.Count; j++)
                    if (ReferenceEquals(parent.ChildRelations[i], child.ParentRelations[j]))
                        return parent.ChildRelations[i];
            return null;
        }
        protected abstract void MapSchema();
        public void Dispose() => SchemaDataSet.Dispose();
    }
}