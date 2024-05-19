using Generator_Code_Data;
using System;

namespace Code_Generator_Business
{
    public class DBQueryInfoEventArgs : EventArgs
    {
        public string SelectedDatabase { get; set; }
        public string SelectedTable { get; set; }
        public string[] Properties { get; set; }

        public DBQueryInfoEventArgs(string selectedDatabase, string selectedTable, string[] properties)
        {
            SelectedDatabase = selectedDatabase;
            SelectedTable = selectedTable;
            Properties = properties;
        }
    }

    public class clsGetDatabasesInformation
    {
        public delegate void CallBackEventHandler(object sender, DBQueryInfoEventArgs e);

        public static event CallBackEventHandler OnEndQuery;

        public static string[] GetDatabases()
        {
            return clsDatabaseInfo.GetDatabases();
        }

        public static string[] GetTables(string SelectedDatabase)
        {
            return clsDatabaseInfo.GetTables(SelectedDatabase);
        }

        public static string[,] GetColumns(string SelectedDatabase, string SelectedTable)
        {
            string[,] Columns = clsDatabaseInfo.GetColumns(SelectedDatabase, SelectedTable);

            if (OnEndQuery != null)
            {
                string[] properties = new string[Columns.GetLength(0)];

                for (int i = 0; i < Columns.GetLength(0); i++)
                {
                    properties[i] = Columns[i, 1];
                }

                DBQueryInfoEventArgs e = new DBQueryInfoEventArgs(SelectedDatabase, SelectedTable, properties);

                OnEndQuery?.Invoke(null, e);
            }

            return Columns;
        }

        public static string[,] GetColumnSQLInfo(string SelectedDatabase, string SelectedTable)
        {
            string[,] Columns = clsDatabaseInfo.GetColumnSQLInfo(SelectedDatabase, SelectedTable);

            if (OnEndQuery != null)
            {
                string[] properties = new string[Columns.GetLength(0)];

                for (int i = 0; i < Columns.GetLength(0); i++)
                {
                    properties[i] = Columns[i, 1];
                }

                DBQueryInfoEventArgs e = new DBQueryInfoEventArgs(SelectedDatabase, SelectedTable, properties);

                OnEndQuery?.Invoke(null, e);
            }

            return Columns;
        }

    }
}
