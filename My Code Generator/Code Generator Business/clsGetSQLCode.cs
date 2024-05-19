using System;
using System.Text;

namespace Code_Generator_Business
{
    public class clsGetSQLCode
    {
        public static string GenerateSP_AddNewCode(string tableName, string[,] parameters)
        {
            StringBuilder sb = new StringBuilder();

            // CREATE PROCEDURE statement
            if (tableName[tableName.Length - 1].ToString().ToLower() == "s")
                sb.AppendLine($"CREATE PROCEDURE SP_AddNew{tableName.Remove(tableName.Length - 1)}");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_AddNew{tableName}");

            sb.AppendLine("(");

            // Add dynamic parameters
            for (int i = 1; i < parameters.GetLength(0); i++)
            {

                if (parameters[i, 2] == null || parameters[i, 2] == "")
                {
                    sb.AppendLine($"\t@{parameters[i, 1]} {parameters[i, 0].ToUpper()},");
                }
                else
                {
                    sb.AppendLine($"\t@{parameters[i, 1]} {parameters[i, 0].ToUpper()}({parameters[i, 2]}),");
                }
            }

            sb.AppendLine("\t-- Add other parameters as needed");
            sb.AppendLine($"\t@New{parameters[0, 1]} INT OUTPUT");
            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine();

            // INSERT INTO statement
            sb.Append($"\tINSERT INTO {tableName} (");

            // Add dynamic parameters
            for (int i = 1; i < parameters.GetLength(0); i++)
            {
                // if i = last row.
                if (i == parameters.GetLength(0) - 1)
                {
                    sb.Append($"{parameters[i, 1]}");
                }
                else
                    sb.Append($"{parameters[i, 1]}, ");

            }

            sb.AppendLine(")");
            sb.AppendLine("\tVALUES");
            sb.Append("\t(");

            // Add dynamic parameters
            for (int i = 1; i < parameters.GetLength(0); i++)
            {
                // if i = last row.
                if (i == parameters.GetLength(0) - 1)
                {
                    sb.Append($"@{parameters[i, 1]}");
                }
                else
                    sb.Append($"@{parameters[i, 1]}, ");

            }

            sb.AppendLine(");");
            sb.AppendLine();

            // SET @NewID = SCOPE_IDENTITY() statement
            sb.AppendLine($"\tSET @New{parameters[0, 1]} = SCOPE_IDENTITY();");
            sb.AppendLine("END");

            return sb.ToString();
        }

        public static string GenerateSP_UpdateCode(string tableName, string[,] parameters)
        {
            StringBuilder sb = new StringBuilder();

            // CREATE PROCEDURE statement
            if (tableName[tableName.Length - 1].ToString().ToLower() == "s")
                sb.AppendLine($"CREATE PROCEDURE SP_Update{tableName.Remove(tableName.Length - 1)}");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_Update{tableName}");

            sb.AppendLine("(");

            // Add dynamic parameters
            for (int i = 0; i < parameters.GetLength(0); i++)
            {
                // if i = last row.
                if (i == parameters.GetLength(0) - 1)
                {
                    if (parameters[i, 2] == null || parameters[i, 2] == "")
                    {
                        sb.AppendLine($"\t@{parameters[i, 1]} {parameters[i, 0].ToUpper()}");
                    }
                    else
                    {
                        sb.AppendLine($"\t@{parameters[i, 1]} {parameters[i, 0].ToUpper()}({parameters[i, 2]})");
                    }

                    continue;
                }

                // if i is not last row.
                if (parameters[i, 2] == null || parameters[i, 2] == "")
                {
                    sb.AppendLine($"\t@{parameters[i, 1]} {parameters[i, 0].ToUpper()},");
                }
                else
                {
                    sb.AppendLine($"\t@{parameters[i, 1]} {parameters[i, 0].ToUpper()}({parameters[i, 2]}),");
                }
            }

            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine();

            // UPDATE statement
            sb.AppendLine($"\tUPDATE {tableName}");
            sb.AppendLine("\tSET");

            // Add dynamic parameters for SET clause
            for (int i = 1; i < parameters.GetLength(0); i++) // Start from 1 to skip the primary key
            {
                if (i == parameters.GetLength(0) - 1)
                    sb.AppendLine($"\t\t{parameters[i, 1]} = @{parameters[i, 1]}");
                else
                    sb.AppendLine($"\t\t{parameters[i, 1]} = @{parameters[i, 1]},");
            }

            sb.AppendLine($"\tWHERE {parameters[0, 1]} = @{parameters[0, 1]};");
            sb.AppendLine("END");

            return sb.ToString();
        }

        public static string GenerateSP_DeleteCode(string tableName, string[,] parameters)
        {
            StringBuilder sb = new StringBuilder();

            // if last character is 's' will be removed.
            if (tableName[tableName.Length - 1].ToString().ToLower() == "s")
                sb.AppendLine($"CREATE PROCEDURE SP_Delete{tableName.Remove(tableName.Length - 1)}");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_Delete{tableName}");

            // check if parameter is () or not.
            if (parameters[0, 2] == "")
            {
                sb.AppendLine($"\t@{parameters[0, 1]} {parameters[0, 0].ToUpper()}");
            }
            else
            {
                sb.AppendLine($"\t@{parameters[0, 1]} {parameters[0, 0].ToUpper()}({parameters[0, 2]})");
            }

            sb.AppendLine($"AS");
            sb.AppendLine($"BEGIN");
            sb.AppendLine($"");
            sb.AppendLine($"      DELETE FROM {tableName} WHERE {parameters[0, 1]} = @{parameters[0, 1]}");
            sb.AppendLine($"");
            sb.AppendLine($"END");


            return sb.ToString();
        }

        public static string GenerateSP_IsExistsCode(string tableName, string[,] parameters)
        {
            StringBuilder sb = new StringBuilder();

            // if last character is 's' will be removed.
            if (tableName[tableName.Length - 1].ToString().ToLower() == "s")
                sb.AppendLine($"CREATE PROCEDURE SP_Is{tableName.Remove(tableName.Length - 1)}Exists");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_Is{tableName}Exists");

            // check if parameter is () or not.
            if (parameters[0, 2] == "")
            {
                sb.AppendLine($"\t@{parameters[0, 1]} {parameters[0, 0].ToUpper()}");
            }
            else
            {
                sb.AppendLine($"\t@{parameters[0, 1]} {parameters[0, 0].ToUpper()}({parameters[0, 2]})");
            }

            sb.AppendLine($"AS");
            sb.AppendLine($"BEGIN");
            sb.AppendLine($"");
            sb.AppendLine($"      IF EXISTS (SELECT FOUND = 1 FROM {tableName} WHERE {parameters[0, 1]} = @{parameters[0, 1]})");
            sb.AppendLine($"            RETURN 1;");
            sb.AppendLine($"      ELSE");
            sb.AppendLine($"            RETURN 0;");
            sb.AppendLine($"");
            sb.AppendLine($"END");


            return sb.ToString();
        }

        public static string GenerateSP_FindCode(string tableName, string[,] parameters)
        {
            StringBuilder sb = new StringBuilder();

            // if last character is 's' will be removed.
            if (tableName[tableName.Length - 1].ToString().ToLower() == "s")
                sb.AppendLine($"CREATE PROCEDURE SP_Find{tableName.Remove(tableName.Length - 1)}");
            else
                sb.AppendLine($"CREATE PROCEDURE SP_Find{tableName}");

            // check if parameter is () or not.
            if (parameters[0, 2] == "")
            {
                sb.AppendLine($"\t@{parameters[0, 1]} {parameters[0, 0].ToUpper()}");
            }
            else
            {
                sb.AppendLine($"\t@{parameters[0, 1]} {parameters[0, 0].ToUpper()}({parameters[0, 2]})");
            }

            sb.AppendLine($"AS");
            sb.AppendLine($"BEGIN");
            sb.AppendLine($"");
            sb.AppendLine($"      SELECT * FROM {tableName} WHERE {parameters[0, 1]} = @{parameters[0, 1]}");
            sb.AppendLine($"");
            sb.AppendLine($"END");


            return sb.ToString();
        }

        public static string GenerateAll(string tableName, string[,] parameters)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GenerateSP_AddNewCode(tableName, parameters));
            sb.AppendLine("\n-- ========================================================================\n");
            sb.AppendLine(GenerateSP_UpdateCode(tableName, parameters));
            sb.AppendLine("\n-- ========================================================================\n");
            sb.AppendLine(GenerateSP_FindCode(tableName, parameters));
            sb.AppendLine("\n-- ========================================================================\n");
            sb.AppendLine(GenerateSP_DeleteCode(tableName, parameters));
            sb.AppendLine("\n-- ========================================================================\n");
            sb.AppendLine(GenerateSP_IsExistsCode(tableName, parameters));

            return sb.ToString();
        }

    }
}
