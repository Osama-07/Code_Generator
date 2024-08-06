using Generator_Code_Data;
using System.Linq;
using System.Text;


namespace Code_Generator_Business
{
    public class clsGeneratorDataAccess
    {
        private static string _GetSqlDataReaderMethod(string dataType)
        {
            switch (dataType.ToLower())
            {
                case "bool":
                case "boolean":
                    return "GetBoolean";
                case "byte":
                    return "GetByte";
                case "short":
                case "int16":
                    return "GetInt16";
                case "int":
                case "int32":
                    return "GetInt32";
                case "long":
                case "int64":
                    return "GetInt64";
                case "decimal":
                    return "GetDecimal";
                case "double":
                    return "GetDouble";
                case "float":
                    return "GetFloat";
                case "datetime":
                case "smalldatetime":
                case "date":
                    return "GetDateTime";
                case "string":
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    return "GetString";
                case "byte[]":
                case "binary":
                case "varbinary":
                case "image":
                    return "GetBytes";
                default:
                    return "GetValue"; // Fallback to the general GetValue method
            }
        }
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

        public static string DTO(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public class {tableInfo.TableName}DTO");
            sb.AppendLine("{");
            sb.Append($"    public {tableInfo.TableName}DTO(");
            // Constructor.
            foreach (var column in tableInfo.Columns)
            {
                sb.Append($"{column.DataType}");
                // if Nullable add '?'.
                if (column.IsNullable)
                    sb.Append("? ");
                else
                    sb.Append(' '); // space

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.Append($"{column.ColumnName.ToLower()}, ");
                else
                    sb.AppendLine($"{column.ColumnName.ToLower()})");
            }
            sb.AppendLine("{");
            // inside Constructor.
            foreach (var column in tableInfo.Columns)
            {
                sb.AppendLine($"    this.{column.ColumnName} = {column.ColumnName.ToLower()};");
            }
            sb.AppendLine("}");
            sb.AppendLine("");
            // Properties.
            foreach (var column in tableInfo.Columns)
            {
                // first column. (ID).
                if (column.NumberOfColumn == 1)
                {
                    sb.AppendLine($"[Range(0, int.MaxValue, ErrorMessage = \"{column.ColumnName} must be between 0 and the maximum value of an integer.\")]");
                }

                // attr [Required].
                if (!column.IsNullable)
                {
                    sb.AppendLine($"[Required(ErrorMessage = \"{column.ColumnName} is required.\")]");
                }

                // attr [MaxLength].
                string dataType = GetDataType(column.DataType);
                if (dataType == "string")
                {
                    sb.AppendLine($"[MaxLength({column.MaxCharacters}, ErrorMessage = \"{column.ColumnName} cannot exceed {column.MaxCharacters} characters.\")]");
                }

                sb.Append($"public {dataType}");
                // if Nullable add '?'.
                if (column.IsNullable)
                    sb.Append("? ");
                else
                    sb.Append(' '); // space.

                sb.Append($"{column.ColumnName} {{ get; set; }} ");

                if (column.IsNullable)
                    sb.Append("// allow null. ");

                if (dataType == "string")
                    sb.AppendLine($"// Length: {column.MaxCharacters}");
                
                sb.AppendLine("}");
            }

            return sb.ToString();
        }

        public static string AddNew(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static int? AddNewPerson(PeopleDTO newPerson)");
            else    
                sb.AppendLine($"public static int? AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}({tableInfo.TableName}DTO new{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)})");

            sb.AppendLine("{");
            sb.AppendLine("");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("");
            sb.AppendLine($"    int? newID = null;");
            sb.AppendLine("");
            sb.AppendLine("     using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_AddNewPerson\", conn))");
            else    
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}\", conn))");
            sb.AppendLine("     {");
            sb.AppendLine("");
            sb.AppendLine("     cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine("");
            foreach (var column in tableInfo.Columns)
            {
                if (column.NumberOfColumn == 1)
                    continue; // becuase in AddNew No parameter for ID.

                if (column.IsNullable)
                {
                    sb.AppendLine($"    if (string.IsNullOrEmpty(new{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName})) // allow null");
                    sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", DBNull.Value);");
                    sb.AppendLine("     else");
                    sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", new{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName});");
                }
                else
                    sb.AppendLine($"    cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", new{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName});");
            }
            sb.AppendLine("");
            sb.AppendLine("     // output parameter.");
            sb.AppendLine($"    SqlParameter outputParameter = new SqlParameter(\"@New{tableInfo.Columns.First().ColumnName}\", SqlDbType.Int)");
            sb.AppendLine("     {");
            sb.AppendLine("         Direction = ParameterDirection.Output");
            sb.AppendLine("     };");
            sb.AppendLine("     cmd.Parameters.Add(outputParameter);");
            sb.AppendLine("");
            sb.AppendLine("     try");
            sb.AppendLine("     {");
            sb.AppendLine("         conn.Open();");
            sb.AppendLine("");
            sb.AppendLine("         cmd.ExecuteNonQuery();");
            sb.AppendLine("");
            sb.AppendLine($"         newID = (int?)cmd.Parameters[\"@New{tableInfo.Columns.First().ColumnName}\"].Value;");
            sb.AppendLine("     }");
            sb.AppendLine("     catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("     {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_AddNewPerson: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("     }");
            sb.AppendLine("   }");
            sb.AppendLine("");
            sb.AppendLine("   return newID;");
            sb.AppendLine("}");


            return sb.ToString();
        }
        
        public static string AddNewAsync(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static async Task<int?> AddNewPersonAsync(PeopleDTO newPerson)");
            else    
                sb.AppendLine($"public static async Task<int?> AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async({tableInfo.TableName}DTO new{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)})");

            sb.AppendLine("{");
            sb.AppendLine("");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("");
            sb.AppendLine($"    int? newID = null;");
            sb.AppendLine("");
            sb.AppendLine("     using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_AddNewPerson\", conn))");
            else    
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}\", conn))");
            sb.AppendLine("     {");
            sb.AppendLine("");
            sb.AppendLine("     cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine("");
            foreach (var column in tableInfo.Columns)
            {
                if (column.IsNullable)
                {
                    sb.AppendLine($"    if (string.IsNullOrEmpty(new{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName})) // allow null");
                    sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", DBNull.Value);");
                    sb.AppendLine("     else");
                    sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", new{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName});");
                }
                else
                    sb.AppendLine($"    cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", new{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName});");
            }
            sb.AppendLine("");
            sb.AppendLine("     // output parameter.");
            sb.AppendLine($"    SqlParameter outputParameter = new SqlParameter(\"@New{tableInfo.Columns.First().ColumnName}\", SqlDbType.Int)");
            sb.AppendLine("     {");
            sb.AppendLine("         Direction = ParameterDirection.Output");
            sb.AppendLine("     };");
            sb.AppendLine("     cmd.Parameters.Add(outputParameter);");
            sb.AppendLine("");
            sb.AppendLine("     try");
            sb.AppendLine("     {");
            sb.AppendLine("         await conn.OpenAsync();");
            sb.AppendLine("");
            sb.AppendLine("         await cmd.ExecuteNonQueryAsync();");
            sb.AppendLine("");
            sb.AppendLine($"         newID = (int?)cmd.Parameters[\"@New{tableInfo.Columns.First().ColumnName}\"].Value;");
            sb.AppendLine("     }");
            sb.AppendLine("     catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("     {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_AddNewPerson: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("     }");
            sb.AppendLine("   }");
            sb.AppendLine("");
            sb.AppendLine("   return newID;");
            sb.AppendLine("}");


            return sb.ToString();
        }

        public static string Get(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static PeopleDTO? GetPersonByID(int? id)");
            else
                sb.AppendLine($"public static {tableInfo.TableName}DTO? Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID(int? id)");
            sb.AppendLine("{");
            sb.AppendLine($"    if (id < 0) return null; // check PersonID maybe data is not correct.");
            sb.AppendLine("");
            sb.AppendLine("    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("    {");
            sb.AppendLine("        clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("        throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("     using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_GetPersonByID\", conn))");
            else
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID\", conn))");
            sb.AppendLine("     {");
            sb.AppendLine("");
            sb.AppendLine("         cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine("");
            sb.AppendLine($"         cmd.Parameters.AddWithValue(\"@{tableInfo.Columns.First().ColumnName}\", id); // {tableInfo.Columns.First().ColumnName} parameter.");
            sb.AppendLine("");
            sb.AppendLine("     try");
            sb.AppendLine("     {");
            sb.AppendLine("         conn.Open();");
            sb.AppendLine("");
            sb.AppendLine("         using (SqlDataReader reader = cmd.ExecuteReader())");
            sb.AppendLine("         {");
            sb.AppendLine("");
            sb.AppendLine("             if (reader.Read())");
            sb.AppendLine("             {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"       return new PeopleDTO");
            else
                sb.AppendLine($"       return new {tableInfo.TableName}DTO");
            sb.AppendLine("       (");
            foreach (var column in tableInfo.Columns)
            {
                string dataType = GetDataType(column.DataType);
                if (column.IsNullable)
                    sb.Append($"           reader.IsDBNull(reader.GetOrdinal(\"{column.ColumnName}\")) ? null : reader.{_GetSqlDataReaderMethod(dataType)}(reader.GetOrdinal(\"{column.ColumnName}\"))");
                else
                    sb.Append($"           reader.{_GetSqlDataReaderMethod(dataType)}(reader.GetOrdinal(\"{column.ColumnName}\"))");

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.Append(',');

                sb.AppendLine("");
            }
            sb.AppendLine("       );");
            sb.AppendLine("             }"); // close if .
            sb.AppendLine("             else");
            sb.AppendLine("                 return null;");
            sb.AppendLine("         }"); // close reader
            sb.AppendLine("     }"); // close try
            sb.AppendLine("     catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("     {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_AddNewPerson: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("     }"); // close catch
            sb.AppendLine(" }"); // close cmd
            sb.AppendLine("");
            sb.AppendLine("     return null;");
            sb.AppendLine("}"); // close function

            return sb.ToString();
        }

        public static string GetAsync(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static async Task<PeopleDTO?> GetPersonByIDAsync(int? id)");
            else
                sb.AppendLine($"public static {tableInfo.TableName}DTO? Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByIDAsync(int? id)");
            sb.AppendLine("{");
            sb.AppendLine($"    if (id < 0) return null; // check {tableInfo.Columns.First().ColumnName} maybe data is not correct.");
            sb.AppendLine("");
            sb.AppendLine("    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("    {");
            sb.AppendLine("        clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("        throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("     using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_GetPersonByID\", conn))");
            else
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID\", conn))");
            sb.AppendLine("     {");
            sb.AppendLine("");
            sb.AppendLine("         cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine("");
            sb.AppendLine($"         cmd.Parameters.AddWithValue(\"@{tableInfo.Columns.First().ColumnName}\", id); // {tableInfo.Columns.First().ColumnName} parameter.");
            sb.AppendLine("");
            sb.AppendLine("     try");
            sb.AppendLine("     {");
            sb.AppendLine("         await conn.OpenAsync();");
            sb.AppendLine("");
            sb.AppendLine("         using (SqlDataReader reader = await cmd.ExecuteReaderAsync())");
            sb.AppendLine("         {");
            sb.AppendLine("");
            sb.AppendLine("             if (reader.Read())");
            sb.AppendLine("             {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"       return new PeopleDTO");
            else
                sb.AppendLine($"       return new {tableInfo.TableName}DTO");
            sb.AppendLine("       (");
            foreach (var column in tableInfo.Columns)
            {
                string dataType = GetDataType(column.DataType);
                if (column.IsNullable)
                    sb.Append($"           await reader.IsDBNullAsync(reader.GetOrdinal(\"{column.ColumnName}\")) ? null : reader.{_GetSqlDataReaderMethod(dataType)}(reader.GetOrdinal(\"{column.ColumnName}\"))");
                else
                    sb.Append($"           reader.{_GetSqlDataReaderMethod(dataType)}(reader.GetOrdinal(\"{column.ColumnName}\"))");

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.Append(',');

                sb.AppendLine("");
            }
            sb.AppendLine("       );");
            sb.AppendLine("             }"); // close if .
            sb.AppendLine("             else");
            sb.AppendLine("                 return null;");
            sb.AppendLine("         }"); // close reader
            sb.AppendLine("     }"); // close try
            sb.AppendLine("     catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("     {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_AddNewPerson: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("     }"); // close catch
            sb.AppendLine(" }"); // close cmd
            sb.AppendLine("");
            sb.AppendLine("     return null;");
            sb.AppendLine("}"); // close function

            return sb.ToString();
        }

        public static string Update(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static bool UpdatePerson(PeopleDTO uPerson)");
            else
                sb.AppendLine($"public static bool Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}({tableInfo.TableName}DTO u{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)})");
            sb.AppendLine("{");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("    bool IsUpdated = false;");
            sb.AppendLine();
            sb.AppendLine("    using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_UpdatePerson\", conn))");
            else
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}\", conn))");
            sb.AppendLine("    {");
			sb.AppendLine("       cmd.CommandType = CommandType.StoredProcedure;");
			sb.AppendLine("");
            foreach (var column in tableInfo.Columns)
            {
                if (column.IsNullable)
                {
                    // if column nullable.
                    if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                    {
                        sb.AppendLine($"    if (string.IsNullOrEmpty(uPerson.{column.ColumnName})) // allow null");
                        sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", DBNull.Value);");
                        sb.AppendLine("     else");
                        sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", uPerson.{column.ColumnName});");
                    }
                    else
                    {
                        sb.AppendLine($"    if (string.IsNullOrEmpty(u{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName})) // allow null");
                        sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", DBNull.Value);");
                        sb.AppendLine("     else");
                        sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", u{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName});");
                    }
                }
                else
                {
                    // if column is not null.
                    if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                        sb.AppendLine($"    cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", uPerson.{column.ColumnName});");
                    else
                        sb.AppendLine($"    cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", u{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName});");
                }
            }
            sb.AppendLine("");
            sb.AppendLine("       try");
            sb.AppendLine("       {");
            sb.AppendLine("           conn.Open();");
            sb.AppendLine("");
            sb.AppendLine("           IsUpdated = cmd.ExecuteNonQuery() > 0;");
            sb.AppendLine("       }");
            sb.AppendLine("       catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("       {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_UpdatePerson: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    return IsUpdated;");
            sb.AppendLine("}");

            sb.AppendLine();

            return sb.ToString();
        }
        
        public static string UpdateAsync(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static async Task<bool> UpdatePersonAsync(PeopleDTO uPerson)");
            else
                sb.AppendLine($"public static async Task<bool> Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async({tableInfo.TableName}DTO u{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)})");
            sb.AppendLine("{");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("    bool IsUpdated = false;");
            sb.AppendLine();
            sb.AppendLine("    using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_UpdatePerson\", conn))");
            else
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}\", conn))");
            sb.AppendLine("    {");
			sb.AppendLine("       cmd.CommandType = CommandType.StoredProcedure;");
			sb.AppendLine("");
            foreach (var column in tableInfo.Columns)
            {
                if (column.IsNullable)
                {
                    // if column nullable.
                    if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                    {
                        sb.AppendLine($"    if (string.IsNullOrEmpty(uPerson.{column.ColumnName})) // allow null");
                        sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", DBNull.Value);");
                        sb.AppendLine("     else");
                        sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", uPerson.{column.ColumnName});");
                    }
                    else
                    {
                        sb.AppendLine($"    if (string.IsNullOrEmpty(u{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName})) // allow null");
                        sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", DBNull.Value);");
                        sb.AppendLine("     else");
                        sb.AppendLine($"        cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", u{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName});");
                    }
                }
                else
                {
                    // if column is not null.
                    if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                        sb.AppendLine($"    cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", uPerson.{column.ColumnName});");
                    else
                        sb.AppendLine($"    cmd.Parameters.AddWithValue(\"@{column.ColumnName}\", u{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}.{column.ColumnName});");
                }
            }
            sb.AppendLine("");
            sb.AppendLine("       try");
            sb.AppendLine("       {");
            sb.AppendLine("           await conn.OpenAsync();");
            sb.AppendLine("");
            sb.AppendLine("           IsUpdated = await cmd.ExecuteNonQueryAsync() > 0;");
            sb.AppendLine("       }");
            sb.AppendLine("       catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("       {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_UpdatePerson: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    return IsUpdated;");
            sb.AppendLine("}");

            sb.AppendLine();

            return sb.ToString();
        }

        public static string IsExists(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static bool IsPersonExistsByID(int? id)");
            else
                sb.AppendLine($"public static bool Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ExistsByID(int? id)");
            sb.AppendLine("{");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("");
            sb.AppendLine("    bool IsExists = false;");
            sb.AppendLine("");
            sb.AppendLine("    using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_IsPersonExists\", conn))");
            else
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ExistsByID\", conn))");
            sb.AppendLine("    {");
			sb.AppendLine("       cmd.CommandType = CommandType.StoredProcedure;");
			sb.AppendLine();
            sb.AppendLine($"       cmd.Parameters.AddWithValue(\"@{tableInfo.Columns.First().ColumnName}\", id);");
            sb.AppendLine();
            sb.AppendLine("       SqlParameter returnValue = new SqlParameter");
            sb.AppendLine("       {");
            sb.AppendLine("           Direction = ParameterDirection.ReturnValue");
            sb.AppendLine("       };");
            sb.AppendLine("       cmd.Parameters.Add(returnValue);");
            sb.AppendLine();
            sb.AppendLine("       try");
            sb.AppendLine("       {");
            sb.AppendLine("           conn.Open();");
            sb.AppendLine("");
            sb.AppendLine("           cmd.ExecuteScalar();");
            sb.AppendLine("");
            sb.AppendLine("           IsExists = ((int?)returnValue.Value == 1);");
            sb.AppendLine("       }");
            sb.AppendLine("       catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("       {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_IsPersonExists: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Exists: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    return IsExists;");
            sb.AppendLine("}");

            sb.AppendLine();

            return sb.ToString();
        }

        public static string IsExistsAsync(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static async Task<bool> IsPersonExistsByIDAsync(int? id)");
            else
                sb.AppendLine($"public static async Task<bool> Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ExistsByIDAsync(int? id)");
            sb.AppendLine("{");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("");
            sb.AppendLine("    bool IsExists = false;");
            sb.AppendLine("");
            sb.AppendLine("    using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_IsPersonExistsByID\", conn))");
            else
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ExistsByID\", conn))");
            sb.AppendLine("    {");
            sb.AppendLine("       cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine();
            sb.AppendLine($"       cmd.Parameters.AddWithValue(\"@{tableInfo.Columns.First().ColumnName}\", id);");
            sb.AppendLine();
            sb.AppendLine("       SqlParameter returnValue = new SqlParameter");
            sb.AppendLine("       {");
            sb.AppendLine("           Direction = ParameterDirection.ReturnValue");
            sb.AppendLine("       };");
            sb.AppendLine("       cmd.Parameters.Add(returnValue);");
            sb.AppendLine();
            sb.AppendLine("       try");
            sb.AppendLine("       {");
            sb.AppendLine("           await conn.OpenAsync();");
            sb.AppendLine("");
            sb.AppendLine("           await cmd.ExecuteScalarAsync();");
            sb.AppendLine("");
            sb.AppendLine("           IsExists = ((int?)returnValue.Value == 1);");
            sb.AppendLine("       }");
            sb.AppendLine("       catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("       {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_IsPersonExists: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Exists: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    return IsExists;");
            sb.AppendLine("}");

            sb.AppendLine();

            return sb.ToString();
        }

        public static string Delete(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static bool DeletePerson(int? id)");
            else
                sb.AppendLine($"public static bool Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}(int? id)");
            sb.AppendLine("{");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("");
            sb.AppendLine("    bool IsDeleted = false;");
            sb.AppendLine("");
            sb.AppendLine("    using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_DeletePerson\", conn))");
            else
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}\", conn))");
            sb.AppendLine("    {");
            sb.AppendLine("       cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine();
            sb.AppendLine($"       cmd.Parameters.AddWithValue(\"@{tableInfo.Columns.First().ColumnName}\", id);");
            sb.AppendLine();
            sb.AppendLine("       try");
            sb.AppendLine("       {");
            sb.AppendLine("           conn.Open();");
            sb.AppendLine("");
            sb.AppendLine("           IsDeleted = (cmd.ExecuteNonQuery() > 0);");
            sb.AppendLine("       }");
            sb.AppendLine("       catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("       {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_DeletePerson: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    return IsDeleted;");
            sb.AppendLine("}");

            sb.AppendLine();

            return sb.ToString();
        }

        public static string DeleteAsync(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"public static async Task<bool> DeletePersonAsync(int? id)");
            else
                sb.AppendLine($"public static async Task<bool> Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async(int? id)");
            sb.AppendLine("{");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("");
            sb.AppendLine("    bool IsDeleted = false;");
            sb.AppendLine("");
            sb.AppendLine("    using (SqlConnection conn = new SqlConnection(ConnectionString))");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("     using (SqlCommand cmd = new SqlCommand(\"SP_DeletePerson\", conn))");
            else
                sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}\", conn))");
            sb.AppendLine("    {");
            sb.AppendLine("       cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine();
            sb.AppendLine($"       cmd.Parameters.AddWithValue(\"@{tableInfo.Columns.First().ColumnName}\", id);");
            sb.AppendLine();
            sb.AppendLine("       try");
            sb.AppendLine("       {");
            sb.AppendLine("           await conn.OpenAsync();");
            sb.AppendLine("");
            sb.AppendLine("           IsDeleted = (await cmd.ExecuteNonQueryAsync() > 0);");
            sb.AppendLine("       }");
            sb.AppendLine("       catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("       {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_DeletePerson: {ex.Message}\", clsUtil.enEventType.Error);");
            else
                sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    return IsDeleted;");
            sb.AppendLine("}");

            sb.AppendLine();

            return sb.ToString();
        }

        public static string GetAll(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public static List<{tableInfo.TableName}DTO?> GetAll{tableInfo.TableName}()");
            sb.AppendLine("{");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("");
            sb.AppendLine($"    var {tableInfo.TableName}List = new List<{tableInfo.TableName}DTO?>();");
            sb.AppendLine("");
            sb.AppendLine("    using (SqlConnection conn = new SqlConnection(ConnectionString))");
            sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_GetAll{tableInfo.TableName}\", conn))");
            sb.AppendLine("    {");
            sb.AppendLine("       cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine();
            sb.AppendLine("       try");
            sb.AppendLine("       {");
            sb.AppendLine("           conn.Open();");
            sb.AppendLine("");
            sb.AppendLine("           using (SqlDataReader reader = cmd.ExecuteReader())");
            sb.AppendLine("           {");
            sb.AppendLine("               while (reader.Read())");
            sb.AppendLine("               {");
            sb.AppendLine($"                   {tableInfo.TableName}List.Add(new {tableInfo.TableName}DTO(");
            sb.AppendLine("                         ");
            foreach (var column in tableInfo.Columns)
            {
                string dataType = GetDataType(column.DataType);
                if (column.IsNullable)
                    sb.Append($"                        reader.IsDBNull(reader.GetOrdinal(\"{column.ColumnName}\")) ? null : reader.{_GetSqlDataReaderMethod(dataType)}(reader.GetOrdinal(\"{column.ColumnName}\"))");
                else
                    sb.Append($"                        reader.{_GetSqlDataReaderMethod(dataType)}(reader.GetOrdinal(\"{column.ColumnName}\"))");

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.Append(',');

                sb.AppendLine("");
            }
            sb.AppendLine("                   ));");
            sb.AppendLine("               }");
            sb.AppendLine("           }");
            sb.AppendLine("       }");
            sb.AppendLine("       catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("       {");
            sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_GetAll{tableInfo.TableName}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine($"    return {tableInfo.TableName}List;");
            sb.AppendLine("}");

            sb.AppendLine();

            return sb.ToString();
        }
        
        public static string GetAllAsync(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public static async Task<List<{tableInfo.TableName}DTO?>> GetAll{tableInfo.TableName}Async()");
            sb.AppendLine("{");
            sb.AppendLine($"    if (string.IsNullOrEmpty(ConnectionString))");
            sb.AppendLine("     {");
            sb.AppendLine("         clsUtil.StoreEventInEventLogs(SourceName, $\"Connection string is not set.\", clsUtil.enEventType.Error);");
            sb.AppendLine("         throw new InvalidOperationException(\"ConnectionString or SourceName is not set.\");");
            sb.AppendLine("     }");
            sb.AppendLine("");
            sb.AppendLine($"    var {tableInfo.TableName}List = new List<{tableInfo.TableName}DTO?>();");
            sb.AppendLine("");
            sb.AppendLine("    using (SqlConnection conn = new SqlConnection(ConnectionString))");
            sb.AppendLine($"     using (SqlCommand cmd = new SqlCommand(\"SP_GetAll{tableInfo.TableName}\", conn))");
            sb.AppendLine("    {");
            sb.AppendLine("       cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine();
            sb.AppendLine("       try");
            sb.AppendLine("       {");
            sb.AppendLine("           await conn.OpenAsync();");
            sb.AppendLine("");
            sb.AppendLine("           using (SqlDataReader reader = cmd.ExecuteReader())");
            sb.AppendLine("           {");
            sb.AppendLine("               while (reader.Read())");
            sb.AppendLine("               {");
            sb.AppendLine($"                   {tableInfo.TableName}List.Add(new {tableInfo.TableName}DTO(");
            foreach (var column in tableInfo.Columns)
            {
                string dataType = GetDataType(column.DataType);
                if (column.IsNullable)
                    sb.Append($"                        await reader.IsDBNullAsync(reader.GetOrdinal(\"{column.ColumnName}\")) ? null : reader.{_GetSqlDataReaderMethod(dataType)}(reader.GetOrdinal(\"{column.ColumnName}\"))");
                else
                    sb.Append($"                        reader.{_GetSqlDataReaderMethod(dataType)}(reader.GetOrdinal(\"{column.ColumnName}\"))");

                if (column.NumberOfColumn < tableInfo.Columns.Count)
                    sb.Append(',');

                sb.AppendLine("");
            }
            sb.AppendLine("                   ));");
            sb.AppendLine("               }");
            sb.AppendLine("           }");
            sb.AppendLine("       }");
            sb.AppendLine("       catch (Exception ex) when (ex is SqlException || ex is Exception)");
            sb.AppendLine("       {");
            sb.AppendLine($"         clsUtil.StoreEventInEventLogs(SourceName, $\"Error SP_GetAll{tableInfo.TableName}: {{ex.Message}}\", clsUtil.enEventType.Error);");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine($"    return {tableInfo.TableName}List;");
            sb.AppendLine("}");

            sb.AppendLine();

            return sb.ToString();
        }





        public static string GetAllCode(TableInfo tableInfo)
        {
            StringBuilder Code = new StringBuilder();

            Code.AppendLine(DTO(tableInfo));
            Code.AppendLine(AddNew(tableInfo));
            Code.AppendLine(AddNewAsync(tableInfo));
            Code.AppendLine(Get(tableInfo));
            Code.AppendLine(GetAsync(tableInfo));
            Code.AppendLine(Update(tableInfo));
            Code.AppendLine(UpdateAsync(tableInfo));
            Code.AppendLine(IsExists(tableInfo));
            Code.AppendLine(IsExistsAsync(tableInfo));
            Code.AppendLine(Delete(tableInfo));
            Code.AppendLine(DeleteAsync(tableInfo));
            Code.AppendLine(GetAll(tableInfo));
            Code.AppendLine(GetAllAsync(tableInfo));

            return Code.ToString();
        }

	}
}
