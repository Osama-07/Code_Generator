using System.Linq;
using System.Text;
using Generator_Code_Data;

namespace Code_Generator_Business
{
    public class clsGetSQLCode
    {

        public static string SP_AddNew(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            // CREATE PROCEDURE statement
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"CREATE PROCEDURE SP_AddNewPerson");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}");

            sb.AppendLine("(");

            // Add dynamic parameters
            foreach (var column in tableInfo.Columns)
            {
                // ignore the parameter id because it not required. (ID).
                if (column.NumberOfColumn == 1)
                    continue;

                sb.Append($"    @{column.ColumnName} {column.DataType.ToUpper()}");

                if (column.MaxCharacters > 0)
                    sb.Append($"({column.MaxCharacters})");

                sb.AppendLine(",");
            }
            sb.AppendLine($"@New{tableInfo.Columns.First().ColumnName} INT OUTPUT");
            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine();

            // INSERT INTO statement
            sb.AppendLine($"\tINSERT INTO {tableInfo.TableName} (");

            // Add dynamic parameters
            foreach (var column in tableInfo.Columns)
            {
                // ignore the parameter id because it not required. (ID).
                if (column.NumberOfColumn == 1)
                    continue;

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.Append($"{column.ColumnName}, ");
                else
                    sb.Append($"{column.ColumnName}");
            }
            sb.AppendLine(")");
            sb.AppendLine("\tVALUES");
            sb.Append("\t(");
            // Add dynamic parameters
            foreach (var column in tableInfo.Columns)
            {
                // ignore the parameter id because it not required. (ID).
                if (column.NumberOfColumn == 1)
                    continue;

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.Append($"@{column.ColumnName}, ");
                else
                    sb.Append($"@{column.ColumnName}");
            }
            sb.AppendLine(");");
            sb.AppendLine();
            // SET @NewID = SCOPE_IDENTITY() statement
            sb.AppendLine($"\tSET @New{tableInfo.Columns.First().ColumnName} = SCOPE_IDENTITY();");
            sb.AppendLine("END");

            return sb.ToString();
        }

        public static string SP_Update(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            // CREATE PROCEDURE statement
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"CREATE PROCEDURE SP_UpdatePerson");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}");

            sb.AppendLine("(");

            // Add dynamic parameters
            foreach (var column in tableInfo.Columns)
            {
                sb.Append($"    @{column.ColumnName} {column.DataType.ToUpper()}");

                if (column.MaxCharacters > 0)
                    sb.Append($"({column.MaxCharacters})");

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.AppendLine(",");
            }
            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine();

            // UPDATE statement
            sb.AppendLine($"\tUPDATE {tableInfo.TableName}");
            sb.AppendLine("\tSET");

            // Add dynamic parameters for SET clause
            foreach (var column in tableInfo.Columns)
            {
                // ignore the parameter id because it will be in the last query with (WHERE).
                if (column.NumberOfColumn == 1)
                    continue;

                sb.Append($"    {column.ColumnName} = @{column.ColumnName}");

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.AppendLine(", ");
                else
                    sb.AppendLine("");
            }
            sb.AppendLine($"\tWHERE {tableInfo.Columns.First().ColumnName} = @{tableInfo.Columns.First().ColumnName};");
            sb.AppendLine("END");

            return sb.ToString();
        }

        public static string SP_Delete(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"CREATE PROCEDURE SP_DeletePersonByID");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID");
            // ID
            sb.AppendLine($"    @{tableInfo.Columns.First().ColumnName} {tableInfo.Columns.First().DataType}");
            sb.AppendLine($"AS");
            sb.AppendLine($"BEGIN");
            sb.AppendLine($"");
            sb.AppendLine($"      DELETE FROM {tableInfo.TableName} WHERE {tableInfo.Columns.First().ColumnName} = @{tableInfo.Columns.First().ColumnName}");
            sb.AppendLine($"");
            sb.AppendLine($"END");


            return sb.ToString();
        }

        public static string SP_IsExists(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"CREATE PROCEDURE SP_IsPersonExists");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Exists");
            // ID
            sb.AppendLine($"    @{tableInfo.Columns.First().ColumnName} {tableInfo.Columns.First().DataType}");
            sb.AppendLine($"AS");
            sb.AppendLine($"BEGIN");
            sb.AppendLine($"");
            sb.AppendLine($"      IF EXISTS (SELECT FOUND = 1 FROM {tableInfo.TableName} WHERE {tableInfo.Columns.First().ColumnName} = @{tableInfo.Columns.First().ColumnName})");
            sb.AppendLine($"            RETURN 1;");
            sb.AppendLine($"      ELSE");
            sb.AppendLine($"            RETURN 0;");
            sb.AppendLine($"");
            sb.AppendLine($"END");


            return sb.ToString();
        }

        public static string SP_Get(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"CREATE PROCEDURE SP_GetPersonByID");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID");
            // ID
            sb.AppendLine($"    @{tableInfo.Columns.First().ColumnName} {tableInfo.Columns.First().DataType}");
            sb.AppendLine($"AS");
            sb.AppendLine($"BEGIN");
            sb.AppendLine($"");
            sb.AppendLine($"      SELECT * FROM {tableInfo.TableName} WHERE {tableInfo.Columns.First().ColumnName} = @{tableInfo.Columns.First().ColumnName}");
            sb.AppendLine($"");
            sb.AppendLine($"END");


            return sb.ToString();
        }

        public static string All(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(SP_AddNew(tableInfo));
            sb.AppendLine("\n-- ========================================================================\n");
            sb.AppendLine(SP_Update(tableInfo));
            sb.AppendLine("\n-- ========================================================================\n");
            sb.AppendLine(SP_Get(tableInfo));
            sb.AppendLine("\n-- ========================================================================\n");
            sb.AppendLine(SP_Delete(tableInfo));
            sb.AppendLine("\n-- ========================================================================\n");
            sb.AppendLine(SP_IsExists(tableInfo));

            return sb.ToString();
        }

    }
}
