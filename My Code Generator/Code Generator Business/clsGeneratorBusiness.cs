using System;
using System.Text;

namespace Code_Generator_Business
{
    public class clsGeneratorBusiness
    {
        private static string GetExpression(string dataType)
        {
            switch (dataType.ToLower())
            {
                case "int":
                    return "(int)";
                case "string":
                    return "(string)";
                case "bool":
                    return "(bool)";
                case "byte":
                    return "(byte)";
                case "short":
                    return "(short)";
                case "long":
                    return "(long)";
                case "decimal":
                    return "(decimal)";
                case "double":
                    return "(double)";
                case "float":
                    return "(float)";
                case "datetime":
                    return "(DateTime)";
                case "byte[]":
                    return "(byte[])";
                default:
                    return "(object)";
            }
        }

        public static string GeneratorBusinessCode(string SelectedTable, string[,] Properties)
        {
            StringBuilder code = new StringBuilder();

            // =====================================================================================================================
            // Create Mode.
            code.AppendLine("    public enum enMode { AddNew = 1, Update = 2}");
            code.AppendLine("    public enMode Mode;");
            code.AppendLine();

            // =====================================================================================================================
            // Create Properties.
            for (int i = 0; i < Properties.GetLength(0); i++)
            {
                string propertyType = Properties[i, 0];
                string propertyName = Properties[i, 1];

                if (i == 0)
                {
                    code.AppendLine($"    public Nullable<{propertyType}> {propertyName} {{ get; set; }}");
                }
                else
                    code.AppendLine($"    public {propertyType} {propertyName} {{ get; set; }}");

            }
            code.AppendLine();

            // =====================================================================================================================
            // Public Constructor.
            code.AppendLine($"    public cls{SelectedTable}()");
            code.AppendLine("    {");
            for (int i = 0; i < Properties.GetLength(0); i++)
            {
                string propertyName = Properties[i, 1];
                code.AppendLine($"        this.{propertyName} = default({Properties[i, 0]});");
            }
            code.AppendLine();
            code.AppendLine("        this.Mode = enMode.AddNew;");
            code.AppendLine("    }");
            code.AppendLine();

            // =====================================================================================================================
            // private Constructor.
            code.Append($"    private cls{SelectedTable}(");
            for (int i = 0; i < Properties.GetLength(0); i++)
            {
                string propertyType = Properties[i, 0];
                string propertyName = Properties[i, 1];

                code.Append($"{propertyType} {propertyName.ToLower()}");

                if (i < Properties.GetLength(0) - 1)
                {
                    code.Append(", ");
                }
                else
                {
                    code.Append(")");
                }
            }
            code.AppendLine("    {");
            for (int i = 0; i < Properties.GetLength(0); i++)
            {
                string propertyName = Properties[i, 1];
                code.AppendLine($"        this.{propertyName} = {propertyName.ToLower()};");
            }
            code.AppendLine();
            code.AppendLine("        this.Mode = enMode.Update;");
            code.AppendLine("    }");
            code.AppendLine();

            // =====================================================================================================================
            // AddNew Function.
            code.AppendLine($"   private bool _AddNew{SelectedTable}()");
            code.AppendLine("    {");
            code.AppendLine("       // parameters");
            code.AppendLine($"       SqlParameter[] parameters = new SqlParameter[{Properties.GetLength(0) - 1}];");

            for(int i = 1; i < Properties.GetLength(0); i++)
            {
                string propertyName = Properties[i, 1];

                code.AppendLine($"    parameters[{i - 1}] = new SqlParameter(\"{propertyName}\", this.{propertyName});");
            }

            // Stored Procedure Name.
            code.AppendLine("// Stored Procedure Name.");
            if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s") // for remove last char if it was = 's'.
                code.AppendLine($"       string StoredProcedure = \"SP_AddNew{SelectedTable.Remove(SelectedTable.Length - 1)}\";");
            else
                code.AppendLine($"       string StoredProcedure = \"SP_AddNew{SelectedTable}\";");

            code.AppendLine("");

            if (SelectedTable == "People")
                code.AppendLine($"       this.{Properties[0, 1]} = cls{SelectedTable}Data.AddNewPerson(StoredProcedure, parameters);");
            else if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s")
				code.AppendLine($"       this.{Properties[0, 1]} = cls{SelectedTable}Data.AddNew{SelectedTable.Remove(SelectedTable.Length - 1)}(StoredProcedure, parameters);");
			else
				code.AppendLine($"       this.{Properties[0, 1]} = cls{SelectedTable}Data.AddNew{SelectedTable}(StoredProcedure, parameters);");
			
            code.AppendLine("");
            code.AppendLine($"        return (this.{Properties[0, 1]} != null);");
            code.AppendLine("     }");
            code.AppendLine("");

            // =====================================================================================================================
            // Update Function.
            code.AppendLine($"    private bool _Update{SelectedTable}()");
            code.AppendLine("     {");
            code.AppendLine("       // parameters");
            code.AppendLine($"       SqlParameter[] parameters = new SqlParameter[{Properties.GetLength(0)}];");

            for (int i = 0; i < Properties.GetLength(0); i++)
            {
                string propertyName = Properties[i, 1];

                code.AppendLine($"    parameters[{i}] = new SqlParameter(\"{propertyName}\", this.{propertyName});");
            }

            // Stored Procedure Name.
            code.AppendLine("// Stored Procedure Name.");
			if (SelectedTable == "People")
				code.AppendLine($"       string StoredProcedure = \"SP_UpdatePerson\";");
			else if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s") // for remove last char if it was = 's'.
                code.AppendLine($"       string StoredProcedure = \"SP_Update{SelectedTable.Remove(SelectedTable.Length - 1)}\";");
            else
                code.AppendLine($"       string StoredProcedure = \"SP_Update{SelectedTable}\";");

            code.AppendLine("");

            if (SelectedTable == "People")
                code.AppendLine($"       return cls{SelectedTable}Data.UpdatePerson(StoredProcedure, parameters);");
            else if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s")
				code.AppendLine($"       return cls{SelectedTable}Data.Update{SelectedTable.Remove(SelectedTable.Length - 1)}(StoredProcedure, parameters);");
            else
				code.AppendLine($"       return cls{SelectedTable}Data.Update{SelectedTable}(StoredProcedure, parameters);");

			code.AppendLine("     }");
            code.AppendLine();

            // =====================================================================================================================
            // Save Function.
            code.AppendLine($"    public bool Save()");
            code.AppendLine("    {");
            code.AppendLine("        switch (Mode)");
            code.AppendLine("        {");
            code.AppendLine($"            case enMode.AddNew:");
            code.AppendLine($"                if (_AddNew{SelectedTable}())");
            code.AppendLine("                {");
            code.AppendLine($"                    this.Mode = enMode.Update;");
            code.AppendLine("                    return true;");
            code.AppendLine("                }");
            code.AppendLine("                else");
            code.AppendLine("                    return false;");
            code.AppendLine();
            code.AppendLine($"            case enMode.Update:");
            code.AppendLine($"                return _Update{SelectedTable}();");
            code.AppendLine();
            code.AppendLine("        }");
            code.AppendLine("        return false;");
            code.AppendLine("    }");
            code.AppendLine();

            // =====================================================================================================================
            // Find Function.
            code.AppendLine($"    public static cls{SelectedTable} FindBy{Properties[0, 1]}({Properties[0, 0]} {Properties[0, 1]})");
            code.AppendLine("    {");
            code.AppendLine("       // parameters");
            code.AppendLine($"       SqlParameter[] parameters = new SqlParameter[{Properties.GetLength(0)}];");

            for (int i = 0; i < Properties.GetLength(0); i++)
            {
                string propertyName = Properties[i, 1];

                if (i == 0)
                    code.AppendLine($"   parameters[{i}] = new SqlParameter(\"{propertyName}\", {propertyName});");
                else
                    code.AppendLine($"   parameters[{i}] = new SqlParameter(\"{propertyName}\", null);");
            }

            code.AppendLine("// Stored Procedure Name.");
			if (SelectedTable == "People")
				code.AppendLine($"       string StoredProcedure = \"SP_FindPerson\";");
			else if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s") // for remove last char if it was = 's'.
                code.AppendLine($"       string StoredProcedure = \"SP_Find{SelectedTable.Remove(SelectedTable.Length - 1)}\";");
            else
                code.AppendLine($"       string StoredProcedure = \"SP_Find{SelectedTable}\";");

            code.AppendLine("");

			if (SelectedTable == "People")
				code.AppendLine($"if (cls{SelectedTable}Data.FindPerson(StoredProcedure, ref parameters))");
            else if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s")
				code.AppendLine($"if (cls{SelectedTable}Data.Find{SelectedTable.Remove(SelectedTable.Length - 1)}(StoredProcedure, ref parameters))");
			else
				code.AppendLine($"if (cls{SelectedTable}Data.Find{SelectedTable}(StoredProcedure, ref parameters))");

			code.AppendLine("{");
            code.Append($"   return new cls{SelectedTable}(");

            for(short i = 0; i < Properties.GetLength(0); i++)
            {
                string dataType = Properties[i, 0];

                if (i == Properties.GetLength(0) - 1)
                    code.AppendLine($"{GetExpression(dataType)}parameters[{i}].Value);"); // without seperator.
                else
                    code.Append($"{GetExpression(dataType)}parameters[{i}].Value, "); // with seperator.
            }

            code.AppendLine("}");
            code.AppendLine("else");
            code.AppendLine("   return null;");
            code.AppendLine("");
            code.AppendLine("    }");
            code.AppendLine("");

            // =====================================================================================================================
            // IsExists Function.
            code.AppendLine($"    public static bool IsExist({Properties[0, 0]} {Properties[0, 1]})");
            code.AppendLine("    {");
            code.AppendLine($"       SqlParameter parameter = new SqlParameter(\"{Properties[0, 1]}\", {Properties[0, 1]});");
            code.AppendLine("");

            code.AppendLine("// Stored Procedure Name.");
			if (SelectedTable == "People")
				code.AppendLine($"       string StoredProcedure = \"SP_IsPersonExists\";");
			if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s") // for remove last char if it was = 's'.
                code.AppendLine($"       string StoredProcedure = \"SP_Is{SelectedTable.Remove(SelectedTable.Length - 1)}Exists\";");
            else
                code.AppendLine($"       string StoredProcedure = \"SP_Is{SelectedTable}Exists\";");

            code.AppendLine("");

			if (SelectedTable == "People")
				code.AppendLine($"       return cls{SelectedTable}Data.IsPersonExists(StoredProcedure, parameter);");
			else if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s") // for remove last char if it was = 's'.
				code.AppendLine($"       return cls{SelectedTable}Data.Is{SelectedTable.Remove(SelectedTable.Length - 1)}Exists(StoredProcedure, parameter);");
            else
				code.AppendLine($"       return cls{SelectedTable}Data.Is{SelectedTable}Exists(StoredProcedure, parameter);");

			code.AppendLine("    }");
            code.AppendLine("");

            // =====================================================================================================================
            // Delete Function.
            code.AppendLine($"    public static bool Delete({Properties[0, 0]} {Properties[0, 1]})");
            code.AppendLine("    {");
            code.AppendLine($"       SqlParameter parameter = new SqlParameter(\"{Properties[0, 1]}\", {Properties[0, 1]});");
            code.AppendLine("");

            code.AppendLine("// Stored Procedure Name.");
			if (SelectedTable == "People")
				code.AppendLine($"       string StoredProcedure = \"SP_DeletePerson\";");
			if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s") // for remove last char if it was = 's'.
                code.AppendLine($"       string StoredProcedure = \"SP_Delete{SelectedTable.Remove(SelectedTable.Length - 1)}\";");
            else
                code.AppendLine($"       string StoredProcedure = \"SP_Delete{SelectedTable}\";");

            code.AppendLine("");
			if (SelectedTable == "People")
				code.AppendLine($"       return cls{SelectedTable}Data.DeletePerson(StoredProcedure, parameter);");
            else if (SelectedTable[SelectedTable.Length - 1].ToString().ToLower() == "s") // for remove last char if it was = 's'.
				code.AppendLine($"       return cls{SelectedTable}Data.Delete{SelectedTable.Remove(SelectedTable.Length - 1)}(StoredProcedure, parameter);");
            else
				code.AppendLine($"       return cls{SelectedTable}Data.Delete{SelectedTable}(StoredProcedure, parameter);");

			code.AppendLine("    }");


            return code.ToString();
        }

    }
}
