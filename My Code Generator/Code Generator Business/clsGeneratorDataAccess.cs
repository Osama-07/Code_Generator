
using System.Text;


namespace Code_Generator_Business
{
    public class clsGeneratorDataAccess
    {

        public static string AddNew(string TableName, string[,] Parameters)
        {
            StringBuilder code = new StringBuilder();

            // Generate Add Record (INSERT) Code
            if (TableName == "People")
				code.Append($"public static Nullable<int> AddNewPerson(string StoredProcedure, SqlParameter[] parameters)");
			else
				code.Append($"public static Nullable<int> AddNew{TableName.Remove(TableName.Length - 1)}(string StoredProcedure, SqlParameter[] parameters)");

            code.AppendLine("{");
            code.AppendLine($"     Nullable<int> {Parameters[0, 1]} = null;");
            code.AppendLine();
            code.AppendLine("    using (SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString))");
            code.AppendLine("    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))");
            code.AppendLine("    {");
            code.AppendLine("       Command.CommandType = CommandType.StoredProcedure;");
            code.AppendLine();
            code.AppendLine("       Command.Parameters.AddRange(parameters);");
            code.AppendLine();
            code.AppendLine("       // Output parameter");
            code.AppendLine($"       SqlParameter outputParameter = new SqlParameter($\"@New{Parameters[0, 1]}\", SqlDbType.Int)");
            code.AppendLine("       {");
            code.AppendLine("           Direction = ParameterDirection.Output");
            code.AppendLine("       };");
            code.AppendLine("       Command.Parameters.Add(outputParameter);");
            code.AppendLine();
            code.AppendLine("       try");
            code.AppendLine("       {");
            code.AppendLine("           Connection.Open();");
            code.AppendLine();
            code.AppendLine("           Command.ExecuteScalar();");
            code.AppendLine();
            code.AppendLine($"           {Parameters[0, 1]} = (int)Command.Parameters[$\"@New{Parameters[0, 1]}\"].Value;");
            code.AppendLine();
            code.AppendLine("       }");
            code.AppendLine("       catch (SqlException ex)");
            code.AppendLine("       {");
            code.AppendLine("           // Sql Exception.");
            code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
            code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
            code.AppendLine("       }");
            code.AppendLine("       catch(Exception ex)");
            code.AppendLine("       {");
            code.AppendLine("          clsUtil.StoreEventInEventLogs(SourceName, $\"Error AddNew {StoredProcedure}: \" + ex.Message, clsUtil.enEventType.Error);");
            code.AppendLine("          MessageBox.Show(\"Error AddNew {StoredProcedure}: \" + ex.Message, \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
            code.AppendLine("       }");
            code.AppendLine("}");
            code.AppendLine();
            code.AppendLine($"    return {Parameters[0, 1]};");
            code.AppendLine("}");

            code.AppendLine();

            return code.ToString();
        }

        public static string Find(string TableName)
        {
            StringBuilder code = new StringBuilder();

			// Generate Update Record (UPDATE) Code
			if (TableName == "People")
				code.AppendLine($"public static bool FindPerson(string StoredProcedure, ref SqlParameter[] parameters)");
			else
				code.AppendLine($"public static bool Find{TableName.Remove(TableName.Length - 1)}(string StoredProcedure, ref SqlParameter[] parameters)");
            
            code.AppendLine("{");
            code.AppendLine("    bool Found = false;");
            code.AppendLine();
            code.AppendLine("    using (SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString))");
            code.AppendLine("    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))");
            code.AppendLine("    {");
			code.AppendLine("       Command.CommandType = CommandType.StoredProcedure;");
			code.AppendLine();
            code.AppendLine("       Command.Parameters.AddWithValue($\"@{parameters[0].ParameterName}\", parameters[0].Value);");
            code.AppendLine("");
			code.AppendLine("       try");
			code.AppendLine("       {");
			code.AppendLine("           Connection.Open();");
			code.AppendLine();
			code.AppendLine("           using (SqlDataReader reader = Command.ExecuteReader())");
            code.AppendLine("           {");
            code.AppendLine("               if (reader.Read())");
            code.AppendLine("               {");
            code.AppendLine("                   for (int i = 0; i < reader.FieldCount; i++)");
            code.AppendLine("                   {");
            code.AppendLine("                       parameters[i].Value = reader[parameters[i].ParameterName];");
            code.AppendLine("                   }");
            code.AppendLine();
            code.AppendLine("                   Found = true;");
            code.AppendLine("               }");
            code.AppendLine("           }");
            code.AppendLine("       }");
			code.AppendLine("       catch (SqlException ex)");
			code.AppendLine("       {");
			code.AppendLine("           // Sql Exception.");
			code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
			code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
			code.AppendLine("       }");
			code.AppendLine("       catch(Exception ex)");
            code.AppendLine("       {");
            code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
            code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
            code.AppendLine("       }");
            code.AppendLine("    }");
            code.AppendLine("");
            code.AppendLine("    return Found;");
            code.AppendLine("}");

            code.AppendLine();

            return code.ToString();
        }

        public static string Update(string TableName, string[,] Parameters)
        {
            StringBuilder code = new StringBuilder();

			// Generate Update Record (UPDATE) Code
			if (TableName == "People")
				code.Append($"public static bool UpdatePerson(string StoredProcedure, SqlParameter[] parameters)");
            else
				code.Append($"public static bool Update{TableName.Remove(TableName.Length - 1)}(string StoredProcedure, SqlParameter[] parameters)");

			code.AppendLine("{");
            code.AppendLine("    bool Updated = false;");
            code.AppendLine();
            code.AppendLine("    using (SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString))");
            code.AppendLine("    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))");
            code.AppendLine("    {");
			code.AppendLine("       Command.CommandType = CommandType.StoredProcedure;");
			code.AppendLine("");
			code.AppendLine("       Command.Parameters.AddRange(parameters);");
			code.AppendLine("");
            code.AppendLine("       try");
            code.AppendLine("       {");
            code.AppendLine("           Connection.Open();");
            code.AppendLine("");
            code.AppendLine("           int rowAfficted = Command.ExecuteNonQuery();");
            code.AppendLine("");
            code.AppendLine("           Updated = (rowAfficted > 0);");
            code.AppendLine("       }");
			code.AppendLine("       catch (SqlException ex)");
			code.AppendLine("       {");
			code.AppendLine("           // Sql Exception.");
			code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
			code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
			code.AppendLine("       }");
			code.AppendLine("       catch(Exception ex)");
			code.AppendLine("       {");
			code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
			code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
			code.AppendLine("       }");
			code.AppendLine("");
            code.AppendLine("    }");
            code.AppendLine("");
            code.AppendLine("    return Updated;");
            code.AppendLine("}");

            code.AppendLine();

            return code.ToString();
        }

        public static string IsExists(string TableName)
        {
            StringBuilder code = new StringBuilder();

			// Generate Is Exist Record (SELECT COUNT) Code
			if (TableName == "People")
				code.AppendLine($"public static bool IsPersonExists(string StoredProcedure, SqlParameter parameter)");
            else
				code.AppendLine($"public static bool Is{TableName.Remove(TableName.Length - 1)}Exists(string StoredProcedure, SqlParameter parameter)");

			code.AppendLine("{");
            code.AppendLine("    bool Exists = false;");
            code.AppendLine("");
            code.AppendLine("    using (SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString))");
            code.AppendLine("    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))");
            code.AppendLine("    {");
			code.AppendLine("       Command.CommandType = CommandType.StoredProcedure;");
			code.AppendLine();
            code.AppendLine("       Command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);");
            code.AppendLine();
            code.AppendLine("       SqlParameter returnValue = new SqlParameter");
            code.AppendLine("       {");
            code.AppendLine("           Direction = ParameterDirection.ReturnValue");
            code.AppendLine("       };");
            code.AppendLine("       Command.Parameters.Add(returnValue);");
            code.AppendLine();
            code.AppendLine("       try");
            code.AppendLine("       {");
            code.AppendLine("           Connection.Open();");
            code.AppendLine("");
            code.AppendLine("           Command.ExecuteScalar();");
            code.AppendLine("           int result = (int)returnValue.Value;");
            code.AppendLine("");
            code.AppendLine("           Exists = (result == 1);");
            code.AppendLine("       }");
			code.AppendLine("       catch (SqlException ex)");
			code.AppendLine("       {");
			code.AppendLine("           // Sql Exception.");
			code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
			code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
			code.AppendLine("       }");
			code.AppendLine("       catch(Exception ex)");
			code.AppendLine("       {");
			code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
			code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
			code.AppendLine("       }");
			code.AppendLine("    }");
            code.AppendLine("");
            code.AppendLine("    return Exists;");
            code.AppendLine("}");

            code.AppendLine();

            return code.ToString();
        }

        public static string Delete(string TableName)
        {
            StringBuilder code = new StringBuilder();

			// Generate Delete Record (DELETE) Code
			if (TableName == "People")
				code.AppendLine($"public static bool DeletePerson(string StoredProcedure, SqlParameter parameter)");
            else
				code.AppendLine($"public static bool Delete{TableName.Remove(TableName.Length - 1)}(string StoredProcedure, SqlParameter parameter)");

			code.AppendLine("{");
            code.AppendLine("    bool Deleted = false;");
            code.AppendLine("");
            code.AppendLine("    using (SqlConnection Connection = new SqlConnection(clsSettingsDataAccess.ConnectionString))");
            code.AppendLine("    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))");
            code.AppendLine("    {");
			code.AppendLine("       Command.CommandType = CommandType.StoredProcedure;");
			code.AppendLine();
			code.AppendLine("       Command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);"); code.AppendLine("");
			code.AppendLine();
            code.AppendLine("       try");
            code.AppendLine("       {");
            code.AppendLine("           Connection.Open();");
            code.AppendLine("");
            code.AppendLine("           int rowAfficted = Command.ExecuteNonQuery();");
            code.AppendLine("");
            code.AppendLine("           Deleted = (rowAfficted > 0);");
            code.AppendLine("       }");
			code.AppendLine("       catch (SqlException ex)");
			code.AppendLine("       {");
			code.AppendLine("           // Sql Exception.");
			code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
			code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
			code.AppendLine("       }");
			code.AppendLine("       catch(Exception ex)");
			code.AppendLine("       {");
			code.AppendLine("           clsUtil.StoreEventInEventLogs(SourceName, $\"Error {StoredProcedure}: {ex.Message}\", clsUtil.enEventType.Error);");
			code.AppendLine("           MessageBox.Show($\"Error {StoredProcedure}: {ex.Message}\", \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
			code.AppendLine("       }");
			code.AppendLine("    }");
            code.AppendLine("");
            code.AppendLine("    return Deleted;");
            code.AppendLine("}");

            code.AppendLine();

            return code.ToString();
        }

        public static string GetAllCode(string TableName, string[,] Parameters)
        {
            StringBuilder Code = new StringBuilder();

            Code.Append(AddNew(TableName, Parameters));
            Code.Append(Find(TableName));
            Code.Append(Update(TableName, Parameters));
            Code.Append(IsExists(TableName));
            Code.Append(Delete(TableName));

            return Code.ToString();
        }

	}
}
