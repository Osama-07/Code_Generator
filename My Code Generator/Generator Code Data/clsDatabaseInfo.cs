using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using Util;

namespace Generator_Code_Data
{
    public class clsDatabaseInfo
    {
        private static string SourceName = Assembly.GetExecutingAssembly().GetName().Name;

        private static string GetDataType(string sqlType)
        {
            switch (sqlType.ToLower())
            {
                case "bit":
                    return "bool";
                case "tinyint":
                    return "byte";
                case "smallint":
                    return "short";
                case "int":
                    return "int";
                case "bigint":
                    return "long";
                case "decimal":
                case "numeric":
                    return "decimal";
                case "money":
                case "smallmoney":
                    return "decimal";
                case "float":
                    return "double";
                case "real":
                    return "float";
                case "datetime":
                case "smalldatetime":
                case "date":
                    return "DateTime";
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    return "string";
                case "binary":
                case "varbinary":
                case "image":
                    return "byte[]";
                // Add more cases for other SQL data types as needed
                default:
                    return "object"; // Fallback to the general object type
            }
        }

        public static string[] GetDatabases()
        {
            string[] DatabasesName;

            string Connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string StoredProcedure = @"SP_GetDatabases";

            using (SqlConnection connection = new SqlConnection(Connection))
            using (SqlCommand command = new SqlCommand(StoredProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                List<string> DatabasesNameList = new List<string>();

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string dbName = reader.GetString(0); // Get the value from the first column

                            DatabasesNameList.Add(dbName);
                        }
                    }

                }
                catch(Exception ex)
                {
                    clsUtil.StoreEventInEventLogs(SourceName, $"Error Get Databases : {ex.Message}.", clsUtil.enEventType.Error);
                    MessageBox.Show($"Error Get Databases : {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DatabasesName = DatabasesNameList.ToArray();
            }
            

            return DatabasesName;
        }

        public static string[] GetTables(string SelectedDatabase)
        {
            string[] TablesName;

            string Connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(Connection))
            {
                connection.Open();

                // Query to retrieve all table names
                string query = $@"USE {SelectedDatabase};
                                 SELECT name FROM sys.tables
                                 WHERE name NOT IN ('sysdiagrams')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    List<string> TablesNameList = new List<string>();

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tableName = reader.GetString(0); // Get the value from the first column

                                TablesNameList.Add(tableName); // Add the table name to the combobox
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        clsUtil.StoreEventInEventLogs(SourceName, $"Error Get Tables : {ex.Message}.", clsUtil.enEventType.Error);
                        MessageBox.Show($"Error Get Tables : {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    TablesName = TablesNameList.ToArray();
                }
            }

            return TablesName;
        }

        public static string[,] GetColumns(string selectedDatabase, string tableName)
        {
            string[,] columnsArray;

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $@"USE {selectedDatabase};
                                  SELECT DATA_TYPE, COLUMN_NAME
                                  FROM INFORMATION_SCHEMA.COLUMNS
                                  WHERE TABLE_NAME = '{tableName}';";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<string[]> columnDataTypesList = new List<string[]>();

                    try
                    {
                        while (reader.Read())
                        {
                            string[] columnData = new string[2];

                            columnData[0] = GetDataType(reader["DATA_TYPE"].ToString());
                            columnData[1] = reader["COLUMN_NAME"].ToString();

                            columnDataTypesList.Add(columnData);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsUtil.StoreEventInEventLogs(SourceName, $"Error Get Columns : {ex.Message}.", clsUtil.enEventType.Error);
                        MessageBox.Show($"Error Get Columns : {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    int numColumns = columnDataTypesList.Count;
                    columnsArray = new string[numColumns, 2];

                    for (int i = 0; i < numColumns; i++)
                    {
                        columnsArray[i, 0] = columnDataTypesList[i][0];
                        columnsArray[i, 1] = columnDataTypesList[i][1];
                    }
                }
            }

            return columnsArray;
        }

        public static string[,] GetColumnSQLInfo(string databaseName, string tableName)
        {
            string[,] columnsArray = null;
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"
                                      USE {databaseName};
                                      SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH AS Length
                                      FROM INFORMATION_SCHEMA.COLUMNS
                                      WHERE TABLE_NAME = '{tableName}';";

                    List<string[]> columnDataTypesList = new List<string[]>();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            string[] columnData = new string[3];

                            columnData[0] = reader["DATA_TYPE"].ToString();
                            columnData[1] = reader["COLUMN_NAME"].ToString();

                            if (reader["Length"].ToString() != "-1")
                                columnData[2] = reader["Length"].ToString();
                            else
                                columnData[2] = "MAX";

                            columnDataTypesList.Add(columnData);
                        }
                    }

                    // Convert List<string[]> to a 2D array
                    int numColumns = columnDataTypesList.Count;
                    columnsArray = new string[numColumns, 3];

                    for (int i = 0; i < numColumns; i++)
                    {
                        columnsArray[i, 0] = columnDataTypesList[i][0];
                        columnsArray[i, 1] = columnDataTypesList[i][1];
                        columnsArray[i, 2] = columnDataTypesList[i][2];
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.StoreEventInEventLogs(SourceName, $"Error Get Columns: {ex.Message}.", clsUtil.enEventType.Error);
                MessageBox.Show($"Error Get Columns: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return columnsArray;
        }
    }
}
