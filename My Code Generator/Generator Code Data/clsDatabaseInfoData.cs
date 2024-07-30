using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using Util;

namespace Generator_Code_Data
{
    public class DatabaseSchema
    {
        public string DatabaseName { get; set; }
        public List<TableInfo> Tables { get; set; }
    }

    public class TableInfo
    {
        public string TableName { get; set; }
        public List<ColumnInfo> Columns { get; set; }
    }

    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool IsNullable { get; set; }
        public int? MaxCharacters { get; set; }
    }

    public class clsDatabaseInfoData
    {
        private static string SourceName = Assembly.GetExecutingAssembly().GetName().Name;
        private static string ConnectionString = clsSettingsDataAccess.ConnectionString;

        private static string GetDataType(string sqlType)
        {
            switch (sqlType.ToLower())
            {
                case "bit": return "bool";
                case "tinyint": return "byte";
                case "smallint": return "short";
                case "int": return "int";
                case "bigint": return "long";
                case "decimal":
                case "numeric": return "decimal";
                case "money":
                case "smallmoney": return "decimal";
                case "float": return "double";
                case "real": return "float";
                case "datetime":
                case "smalldatetime":
                case "date": return "DateTime";
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext": return "string";
                case "binary":
                case "varbinary":
                case "image": return "byte[]";
                default: return "object"; // Fallback to the general object type
            }
        }

        public static List<string> GetDatabases()
        {
            List<string> DatabasesName = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_GetDatabases", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dbName = reader.GetString(0); // Get the value from the first column
                            DatabasesName.Add(dbName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsUtil.StoreEventInEventLogs(SourceName, $"Error Get Databases : {ex.Message}.", clsUtil.enEventType.Error);
                    MessageBox.Show($"Error Get Databases : {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return DatabasesName;
        }

        public static List<string> GetTables(string selectedDatabase)
        {
            List<string> TablesName = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $@"USE {selectedDatabase};
                              SELECT name FROM sys.tables
                              WHERE name NOT IN ('sysdiagrams')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tableName = reader.GetString(0); // Get the value from the first column
                                TablesName.Add(tableName); // Add the table name to the list
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsUtil.StoreEventInEventLogs(SourceName, $"Error Get Tables : {ex.Message}.", clsUtil.enEventType.Error);
                        MessageBox.Show($"Error Get Tables : {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return TablesName;
        }

        public static List<ColumnInfo> GetColumns(string selectedDatabase, string tableName)
        {
            List<ColumnInfo> columns = new List<ColumnInfo>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $@"USE {selectedDatabase};
                              SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH 
                              FROM INFORMATION_SCHEMA.COLUMNS
                              WHERE TABLE_NAME = '{tableName}';";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                columns.Add(new ColumnInfo
                                {
                                    ColumnName = reader["COLUMN_NAME"].ToString(),
                                    DataType = GetDataType(reader["DATA_TYPE"].ToString()),
                                    IsNullable = reader["IS_NULLABLE"].ToString() == "YES",
                                    MaxCharacters = reader["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value ? (int?)Convert.ToInt32(reader["CHARACTER_MAXIMUM_LENGTH"]) : null
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsUtil.StoreEventInEventLogs(SourceName, $"Error Get Columns : {ex.Message}.", clsUtil.enEventType.Error);
                        MessageBox.Show($"Error Get Columns : {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return columns;
        }

        public static List<DatabaseSchema> GetAllDatabaseSchemas()
        {
            List<DatabaseSchema> schemas = new List<DatabaseSchema>();
            var databases = GetDatabases();

            foreach (var database in databases)
            {
                var schema = new DatabaseSchema
                {
                    DatabaseName = database,
                    Tables = new List<TableInfo>()
                };

                var tables = GetTables(database);
                foreach (var tableName in tables)
                {
                    var table = new TableInfo
                    {
                        TableName = tableName,
                        Columns = GetColumns(database, tableName)
                    };

                    schema.Tables.Add(table);
                }

                schemas.Add(schema);
            }

            return schemas;
        }
        
        public static DatabaseSchema GetDatabaseSchema(string selectedDatabase)
        {
            var schema = new DatabaseSchema
            {
                DatabaseName = selectedDatabase,
                Tables = new List<TableInfo>()
            };

            var tables = GetTables(selectedDatabase);
            foreach (var tableName in tables)
            {
                var table = new TableInfo
                {
                    TableName = tableName,
                    Columns = GetColumns(selectedDatabase, tableName)
                };

                schema.Tables.Add(table);
            }

            return schema;
        }

    }
}
