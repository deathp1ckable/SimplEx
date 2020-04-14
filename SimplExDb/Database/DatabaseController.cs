using MySql.Data.MySqlClient;
using SimplExDb.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace SimplExDb.Database
{
    public sealed class DatabaseController : IDisposable
    {
        private readonly Dictionary<object, Row> loadedRows = new Dictionary<object, Row>();
        private readonly Queue<DataRow> updateRowQueue = new Queue<DataRow>();
        private MySqlCommand command;
        private string updateString;
        private string loadString;
        private Rule[] rules;
        private bool isOpened;
        private bool isDeleted;
        private bool isAdded;
        private long id;
        public MySqlConnection Connection { get; private set; }
        public SchemaMap Schema { get; private set; }
        public DatabaseController(SchemaMap schema) => Schema = schema;
        public void Open(string server, string user, uint port, string password)
        {
            if (isOpened)
                throw new Exception("Attepting to open already opened controller.");
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder
            {
                Server = server,
                Port = port,
                UserID = user,
                Password = password,
            };
            Connection = new MySqlConnection(stringBuilder.ConnectionString);
            Connection.Open();
            command = new MySqlCommand("", Connection);
            rules = new Rule[Schema.SchemaDataSet.Relations.Count];
            int i;
            for (i = 0; i < rules.Length; i++)
                rules[i] = Schema.SchemaDataSet.Relations[i].ChildKeyConstraint.UpdateRule;
            isOpened = true;
        }
        public void OpenSchema()
        {
            command.CommandText = $"USE {Schema.DatabaseName};";
            command.ExecuteNonQuery();
        }
        public void CreateSchema()
        {
            loadString = $"DROP DATABASE IF EXISTS `{Schema.DatabaseName}`;";
            loadString += $"CREATE SCHEMA `{Schema.DatabaseName}` DEFAULT CHARACTER SET utf8; " +
                $"USE `{Schema.DatabaseName}`; ";
            foreach (DataTable table in Schema.SchemaDataSet.Tables)
            {
                loadString += $"CREATE TABLE `{Schema.DatabaseName}`.`{table.TableName}` (";
                foreach (DataColumn column in table.Columns)
                    if (!ReferenceEquals(column, table.PrimaryKey[0]))
                        loadString += $"`{column.ColumnName}` {Schema.MappedDataTypes[column.DataType]} {(column.AllowDBNull ? "NULL," : "NOT NULL,")}";
                loadString += $"`{table.PrimaryKey[0].ColumnName}` {Schema.MappedDataTypes[table.PrimaryKey[0].DataType]} NOT NULL AUTO_INCREMENT,";
                loadString += $"PRIMARY KEY(`{table.PrimaryKey[0].ColumnName}`)) " +
                    $"ENGINE = InnoDB;";
            }
            foreach (DataRelation relation in Schema.SchemaDataSet.Relations)
                loadString += $"ALTER TABLE `{Schema.DatabaseName}`.`{relation.ChildTable.TableName}` " +
                    $"ADD INDEX `{relation.RelationName + "_inx"}` (`{relation.ParentColumns[0]}` ASC) VISIBLE, " +
                    $"ADD CONSTRAINT {relation.RelationName} " +
                    $"FOREIGN KEY ({relation.ChildColumns[0].ColumnName}) " +
                    $"REFERENCES {relation.ParentTable.TableName} ({relation.ParentColumns[0]}) " +
                    $"ON DELETE {GetActionString(relation.ChildKeyConstraint.DeleteRule)} " +
                    $"ON UPDATE {GetActionString(relation.ChildKeyConstraint.UpdateRule)};";
            command.CommandText = loadString;
            command.ExecuteNonQuery();
        }
        public T[] Select<T>(string whereExpression = "true") where T : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            ClassMap<T> map = Schema.GetClassMapInstance<T>();

            DataTable dataTable = new DataTable(map.TableName);
            DataTable schemaTable = Schema.SchemaDataSet.Tables[map.TableName];

            command.CommandText = $"SELECT * FROM {map.TableName} " +
                $"WHERE {whereExpression};";
            MySqlDataReader reader = command.ExecuteReader();
            dataTable.Load(reader);
            T[] result = new T[dataTable.Rows.Count];

            for (int i = 0, j, k = 0; i < dataTable.Rows.Count; i++)
            {
                T loaded = CheckLoading<T>(dataTable.Rows[i][map.KeyColumnName]);
                if (loaded == null)
                {
                    T tmp = (T)Activator.CreateInstance(typeof(T));
                    map.Instance = tmp;
                    for (j = 0; j < map.Columns.Length; j++)
                        map.Columns[j].SetValue(dataTable.Rows[i][map.Columns[j].ColumnName]);

                    schemaTable.ImportRow(dataTable.Rows[i]);
                    loadedRows.Add(tmp, new Row(schemaTable.Rows[schemaTable.Rows.Count - 1], tmp)
                    {
                        IsCommited = true
                    });
                    result[k++] = tmp;
                }
                else result[k++] = loaded;
            }
            dataTable.Dispose();
            return result;
        }
        public TChild[] SelectChild<TParent, TChild>(TParent instance, string whereExpression = "true") where TParent : class where TChild : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            if (!loadedRows.ContainsKey(instance))
                throw new ArgumentException("This instnace wasn't loaded. Use Insert() or Select() to load instance.");
            ClassMap<TParent> parentMap = Schema.GetClassMapInstance<TParent>();
            ClassMap<TChild> childMap = Schema.GetClassMapInstance<TChild>();

            DataTable dataTable = new DataTable(childMap.TableName);
            DataTable schemaTable = Schema.SchemaDataSet.Tables[childMap.TableName];

            parentMap.Instance = instance;
            string selectStr = "";
            for (int i = 0; i < schemaTable.Columns.Count; i++)
                selectStr += $"{schemaTable.TableName}.{schemaTable.Columns[i].ColumnName}" + (i + 1 == schemaTable.Columns.Count ? "" : ", ");

            command.CommandText = $"SELECT {selectStr} " +
                  $"FROM {parentMap.TableName} " +
                  $"INNER JOIN {childMap.TableName} ON " +
                  $"{childMap.TableName}.{childMap.ForeignKeyNames[typeof(TParent)].ColumnName} = {loadedRows[instance].DataRow[parentMap.KeyColumnName]} " +
                  $"WHERE {whereExpression};";
            MySqlDataReader reader = command.ExecuteReader();
            dataTable.Load(reader);
            TChild[] result = new TChild[dataTable.Rows.Count];

            for (int i = 0, j, k = 0; i < dataTable.Rows.Count; i++)
            {
                TChild loaded = CheckLoading<TChild>(dataTable.Rows[i][childMap.KeyColumnName]);
                if (loaded == null)
                {
                    TChild tmp = (TChild)Activator.CreateInstance(typeof(TChild));
                    childMap.Instance = tmp;
                    for (j = 0; j < childMap.Columns.Length; j++)
                        childMap.Columns[j].SetValue(dataTable.Rows[i][childMap.Columns[j].ColumnName]);
                    schemaTable.ImportRow(dataTable.Rows[i]);
                    loadedRows.Add(tmp, new Row(schemaTable.Rows[schemaTable.Rows.Count - 1], tmp)
                    {
                        IsCommited = true
                    });
                    result[k++] = tmp;
                }
                else result[k++] = loaded;
            }
            dataTable.Dispose();
            return result;
        }
        public TParent[] SelectParent<TParent, TChild>(TChild instance, string whereExpression = "true") where TParent : class where TChild : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            if (!loadedRows.ContainsKey(instance))
                throw new ArgumentException("This instnace wasn't loaded. Use Insert() or Select() to load instance.");
            ClassMap<TParent> parentMap = Schema.GetClassMapInstance<TParent>();
            ClassMap<TChild> childMap = Schema.GetClassMapInstance<TChild>();
            Row row = loadedRows[instance];
            TParent[] results = Select<TParent>($"{parentMap.KeyColumnName} = {row.DataRow[childMap.ForeignKeyNames[typeof(TParent)].ColumnName]} AND {whereExpression}");
            if (results.Length == 0)
                return null;
            return results;
        }
        public void Insert<T>(T instance, params object[] parents) where T : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            if (loadedRows.ContainsKey(instance))
                throw new ArgumentException("This instnace was already loaded. Use Update() or Regularize() to update data of an instance.");
            int i;
            ClassMap<T> map = Schema.GetClassMapInstance(instance);
            DataTable dataTable = Schema.SchemaDataSet.Tables[map.TableName];
            DataRow row = dataTable.NewRow();
            row[map.KeyColumnName] = id--;
            for (i = 0; i < map.Columns.Length; i++)
                row[map.Columns[i].ColumnName] = map.Columns[i].GetValue();
            for (i = 0; i < parents.Length; i++)
                row.SetParentRow(loadedRows[parents[i]].DataRow, Schema.GetRelation(loadedRows[parents[i]].DataRow.Table.TableName, map.TableName));
            dataTable.Rows.Add(row);
            loadedRows.Add(instance, new Row(row, instance)
            {
                IsCommited = false
            });
            updateRowQueue.Enqueue(row);
        }
        public void Regularize<T>(T instance, params object[] parents) where T : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            if (!loadedRows.ContainsKey(instance))
                throw new ArgumentException("This instnace wasn't loaded. Use Insert() or Select() to load instance.");
            ClassMap<T> map = Schema.GetClassMapInstance(instance);
            Row temp = loadedRows[instance];
            temp.IsCommited = false;
            DataRow row = temp.DataRow;
            for (int i = 0; i < parents.Length; i++)
                row.SetParentRow(loadedRows[parents[i]].DataRow, Schema.GetRelation(loadedRows[parents[i]].DataRow.Table.TableName, map.TableName));
            if (!updateRowQueue.Contains(row))
                updateRowQueue.Enqueue(row);
        }
        public void Update<T>(T instance) where T : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            if (!loadedRows.ContainsKey(instance))
                throw new ArgumentException("This instnace wasn't loaded. Use Insert() or Select() to load instance.");
            ClassMap<T> map = Schema.GetClassMapInstance(instance);
            Row temp = loadedRows[instance];
            temp.IsCommited = false;
            DataRow row = temp.DataRow;
            for (int i = 0; i < map.Columns.Length; i++)
                row[map.Columns[i].ColumnName] = map.Columns[i].GetValue();
            if (!updateRowQueue.Contains(row))
                updateRowQueue.Enqueue(row);
        }
        public void Delete<T>(T instance) where T : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            if (!loadedRows.ContainsKey(instance))
                throw new ArgumentException("This instnace wasn't loaded. Use Insert() or Select() to load instance.");
            Row temp = loadedRows[instance];
            temp.IsCommited = false;
            DataRow row = temp.DataRow;
            loadedRows.Remove(instance);
            row.AcceptChanges();
            if (!updateRowQueue.Contains(row))
                updateRowQueue.Enqueue(row);
        }
        public void Commit()
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            DataRow row;
            int i;
            isDeleted = false;
            isAdded = false;
            updateString = "SET FOREIGN_KEY_CHECKS = 0; SET AUTOCOMMIT = 0;";
            while (updateRowQueue.Count > 0)
            {
                row = updateRowQueue.Dequeue();
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        if (!isAdded)
                            for (i = 0; i < rules.Length; i++)
                                Schema.SchemaDataSet.Relations[i].ChildKeyConstraint.UpdateRule = Rule.Cascade;
                        string colStr = "";
                        string valStr = "";
                        for (i = 0; i < row.Table.Columns.Count; i++)
                        {
                            colStr += $"{row.Table.Columns[i].ColumnName}, ";
                            if (ReferenceEquals(row.Table.Columns[i], row.Table.PrimaryKey[0]) || row.IsNull(i)) valStr += $"null, ";
                            else if (row.Table.Columns[i].DataType == typeof(DateTime)) valStr += $"'{(DateTime)row[i]:yyyy:MM:dd HH:mm:ss}', ";
                            else valStr += $"'{row[i]}', ";
                        }

                        colStr = colStr.Remove(colStr.Length - 2, 2);
                        valStr = valStr.Remove(valStr.Length - 2, 2);

                        command.CommandText = $"INSERT INTO {row.Table} " +
                          $"({colStr}) " +
                          $"VALUES ({valStr})";
                        command.ExecuteNonQuery();
                        row[row.Table.PrimaryKey[0]] = command.LastInsertedId;
                        isAdded = true;
                        break;
                    case DataRowState.Modified:
                        string setStr = "";
                        for (i = 0; i < row.Table.Columns.Count; i++)
                            if (row.IsNull(i)) setStr += $"{row.Table.Columns[i].ColumnName} = null, ";
                            else if (row.Table.Columns[i].DataType == typeof(DateTime)) setStr += $"{row.Table.Columns[i].ColumnName} = '{(DateTime)row[i]:yyyy:MM:dd HH:mm:ss}', ";
                            else setStr += $"{row.Table.Columns[i].ColumnName} = '{row[i]}', ";
                        setStr = setStr.Remove(setStr.Length - 2, 2);

                        updateString += $"UPDATE {row.Table} " +
                              $"SET {setStr} " +
                              $"WHERE {row.Table.PrimaryKey[0].ColumnName} = {row[row.Table.PrimaryKey[0]]};";
                        row.AcceptChanges();
                        break;
                    case DataRowState.Unchanged:
                        updateString += "SET FOREIGN_KEY_CHECKS = 1;";
                        updateString += $"DELETE FROM {row.Table.TableName} " +
                            $"WHERE {row.Table.PrimaryKey[0].ColumnName} = {row[row.Table.PrimaryKey[0]]};";
                        updateString += "SET FOREIGN_KEY_CHECKS = 0;";
                        row.Delete();
                        isDeleted = true;
                        break;
                }
            }
            if (isAdded)
            {
                foreach (Row rowInfo in loadedRows.Values)
                    if (rowInfo.DataRow.RowState == DataRowState.Added)
                    {
                        row = rowInfo.DataRow;
                        string setStr = "";
                        for (i = 0; i < row.Table.Columns.Count; i++)
                            if (row.IsNull(i)) setStr += $"{row.Table.Columns[i].ColumnName} = null, ";
                            else if (row.Table.Columns[i].DataType == typeof(DateTime)) setStr += $"{row.Table.Columns[i].ColumnName} = '{(DateTime)row[i]:yyyy:MM:dd HH:mm:ss}', ";
                            else setStr += $"{row.Table.Columns[i].ColumnName} = '{row[i]}', ";
                        setStr = setStr.Remove(setStr.Length - 2, 2);

                        updateString += $"UPDATE {row.Table} " +
                            $"SET {setStr} " +
                            $"WHERE {row.Table.PrimaryKey[0].ColumnName} = {row[row.Table.PrimaryKey[0]]};";
                        row.AcceptChanges();
                    }
                for (i = 0; i < rules.Length; i++)
                    Schema.SchemaDataSet.Relations[i].ChildKeyConstraint.UpdateRule = rules[i];
            }
            if (isDeleted)
            {
                Row[] rows = loadedRows.Values.ToArray();
                for (i = 0; i < rows.Length; i++)
                    if (rows[i].DataRow.RowState == DataRowState.Deleted)
                        loadedRows.Remove(rows[i].Instance);
            }
            updateString += "SET FOREIGN_KEY_CHECKS = 1;  SET AUTOCOMMIT = 1;";
            command.CommandText = updateString;
            command.ExecuteNonQuery();
            foreach (Row temp in loadedRows.Values)
                temp.IsCommited = true;
        }

        public int? GetIdentifier<T>(T instance) where T : class
        {
            if (loadedRows.TryGetValue(instance, out Row row))
            {
                DataRow dataRow = row.DataRow;
                return int.Parse(dataRow[dataRow.Table.PrimaryKey[0]].ToString());
            }
            return null;
        }
        public bool IsLoaded<T>(T instance) where T : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            return loadedRows.ContainsKey(instance);
        }
        public bool IsIdentifierLoaded<T>(int id) where T : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            ClassMap<T> map = Schema.GetClassMapInstance((T)Activator.CreateInstance(typeof(T)));
            DataTable table = Schema.SchemaDataSet.Tables[map.TableName];
            string idStr = id.ToString();
            for (int i = 0; i < table.Rows.Count; i++)
                if (table.Rows[i][table.PrimaryKey[0]].ToString() == idStr)
                    return true;
            return false;
        }
        public bool IsCommited<T>(T instance) where T : class
        {
            if (!isOpened)
                throw new Exception("Attepting to use unopened controller.");
            loadedRows.TryGetValue(instance, out Row row);
            return row.IsCommited;
        }
        public bool IsConnected()
        {
            try
            {
                command.CommandText = "SELECT 1;";
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable result = new DataTable();
            command.CommandText = query;
            result.Load(command.ExecuteReader());
            return result;
        }
        public void Unload()
        {
            Schema.SchemaDataSet.Clear();
            updateRowQueue.Clear();
            loadedRows.Clear();
        }

        public void Close() => Dispose();
        public void Dispose()
        {
            Connection.Dispose();
            Schema.Dispose();
            if (command != null)
                command.Dispose();
            isOpened = false;
        }

        private T CheckLoading<T>(object key) where T : class
        {
            ClassMap<T> map = Schema.GetClassMapInstance<T>();
            DataTable dataTable = Schema.SchemaDataSet.Tables[map.TableName];
            DataColumn keyColumn = dataTable.Columns[map.KeyColumnName];
            T result = null;
            foreach (Row rowInfo in loadedRows.Values)
                if (ReferenceEquals(rowInfo.DataRow.Table, dataTable))
                    if (int.Parse(rowInfo.DataRow[keyColumn].ToString()) == int.Parse(key.ToString()))
                    {
                        result = (T)rowInfo.Instance;
                        break;
                    }
            if (result == null)
                return null;
            return result;
        }
        private string GetActionString(Rule rule)
        {
            switch (rule)
            {
                case Rule.Cascade:
                    return "CASCADE";
                case Rule.SetNull:
                    return "SET NULL";
                case Rule.None:
                    return "NO ACTION";
            }
            return "NO ACTION";
        }
    }
}
