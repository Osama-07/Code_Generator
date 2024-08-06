using Generator_Code_Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Code_Generator_Business
{
    public class clsGeneratorBusiness
    {
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

        public static string GeneratorBusinessCode(TableInfo tableInfo)
        {
            StringBuilder sb = new StringBuilder();

            // =====================================================================================================================
            // Create Mode.
            sb.AppendLine("    public enum enMode { AddNew = 1, Update = 2}");
            sb.AppendLine("    public enMode Mode;");
            sb.AppendLine();

            // =====================================================================================================================
            // Create DTO Variable.
            sb.AppendLine($"public {tableInfo.TableName}DTO {tableInfo.TableName[0].ToString().ToUpper()}DTO");
            sb.AppendLine("{");
            sb.AppendLine("     get");
            sb.AppendLine("     {");
            sb.AppendLine($"        return new {tableInfo.TableName}DTO");
            sb.AppendLine("         (");
            foreach (var column in tableInfo.Columns)
            {
                if (column.NumberOfColumn != tableInfo.Columns.Count)
                    sb.AppendLine($"            this.{column.ColumnName},");
                else
                    sb.AppendLine($"            this.{column.ColumnName}");
            }
            sb.AppendLine("         );");
            sb.AppendLine("     }");
            sb.AppendLine("}");

            // =====================================================================================================================
            // Constructor.
            sb.AppendLine($"    public cls{tableInfo.TableName}({tableInfo.TableName}DTO {tableInfo.TableName[0].ToString().ToUpper()}DTO, enMode mode = enMode.AddNew)");
            sb.AppendLine("     {");
            foreach (var column in tableInfo.Columns)
            {
                sb.AppendLine($"        this.{column.ColumnName} = {tableInfo.TableName[0].ToString().ToUpper()}DTO.{column.ColumnName};");
            }
            sb.AppendLine("");
            sb.AppendLine("        this.Mode = mode;");
            sb.AppendLine("     }");
            sb.AppendLine();

            // =====================================================================================================================
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
            }

            // =====================================================================================================================
            // Function AddNew & AddNewAsync.
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"private bool _AddNewPerson()");
            else
                sb.AppendLine($"private bool _AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}()");
            sb.AppendLine("    {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"this.{tableInfo.Columns.First().ColumnName} = clsPeopleData.AddNewPerson(PDTO);");
            else
                sb.AppendLine($"this.{tableInfo.Columns.First().ColumnName} = cls{tableInfo.TableName}Data.AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}({tableInfo.TableName[0].ToString().ToUpper()}DTO);");
            sb.AppendLine("");
            sb.AppendLine($"       return (this.{tableInfo.Columns.First().ColumnName} > 0);");
            sb.AppendLine("    }");
            sb.AppendLine("");

            // Async.
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"private async Task<bool> _AddNewPersonAsync()");
            else
                sb.AppendLine($"private async Task<bool> _AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async()");
            sb.AppendLine("    {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"this.{tableInfo.Columns.First().ColumnName} = await clsPeopleData.AddNewPersonAsync(PDTO);");
            else
                sb.AppendLine($"this.{tableInfo.Columns.First().ColumnName} = await cls{tableInfo.TableName}Data.AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async({tableInfo.TableName[0].ToString().ToUpper()}DTO);");
            sb.AppendLine("");
            sb.AppendLine($"       return (this.{tableInfo.Columns.First().ColumnName} > 0);");
            sb.AppendLine("    }");
            sb.AppendLine("");

            // =====================================================================================================================
            // Update Function.
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"private bool _UpdatePerson()");
            else
                sb.AppendLine($"private bool _Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}()");
            sb.AppendLine("     {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"        return clsPeopleData.UpdatePerson(PDTO);");
            else
                sb.AppendLine($"        return cls{tableInfo.TableName}Data.Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}({tableInfo.TableName[0].ToString().ToUpper()}DTO);");
            sb.AppendLine("     }");
            sb.AppendLine("");

            // Async.
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"private async Task<bool> _UpdatePersonAsync()");
            else
                sb.AppendLine($"private async Task<bool> _Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async()");
            sb.AppendLine("     {");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"        return await clsPeopleData.UpdatePersonAsync(PDTO);");
            else
                sb.AppendLine($"        return await cls{tableInfo.TableName}Data.Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async({tableInfo.TableName[0].ToString().ToUpper()}DTO);");
            sb.AppendLine("     }");
            sb.AppendLine("");

            // =====================================================================================================================
            // Save Function.
            sb.AppendLine($"    public bool Save()");
            sb.AppendLine("    {");
            sb.AppendLine("        switch (Mode)");
            sb.AppendLine("        {");
            sb.AppendLine($"            case enMode.AddNew:");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"                if (_AddNewPerson())");
            else
                sb.AppendLine($"                if (_AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}())");
            sb.AppendLine("                {");
            sb.AppendLine($"                    this.Mode = enMode.Update;");
            sb.AppendLine("                    return true;");
            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                    return false;");
            sb.AppendLine();
            sb.AppendLine($"            case enMode.Update:");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"                return _UpdatePerson();");
            else
                sb.AppendLine($"                return _Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}();");
            sb.AppendLine("        }");
            sb.AppendLine("        return false;");
            sb.AppendLine("    }");
            sb.AppendLine();

            // Async
            sb.AppendLine($"    public async Task<bool> SaveAsync()");
            sb.AppendLine("    {");
            sb.AppendLine("        switch (Mode)");
            sb.AppendLine("        {");
            sb.AppendLine($"            case enMode.AddNew:");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"                if (await _AddNewPersonAsync())");
            else
                sb.AppendLine($"                if (await _AddNew{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async())");
            sb.AppendLine("                {");
            sb.AppendLine($"                    this.Mode = enMode.Update;");
            sb.AppendLine("                    return true;");
            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                    return false;");
            sb.AppendLine();
            sb.AppendLine($"            case enMode.Update:");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"                return await _UpdatePersonAsync();");
            else
                sb.AppendLine($"                return await _Update{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}Async();");
            sb.AppendLine("        }");
            sb.AppendLine("        return false;");
            sb.AppendLine("    }");
            sb.AppendLine();

            // =====================================================================================================================
            // Get .
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"    public static cls{tableInfo.TableName}? GetPersonByID(int? id)");
            else
                sb.AppendLine($"    public static cls{tableInfo.TableName}? Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID(int? id)");
            sb.AppendLine("    {");
            sb.AppendLine($"           if (id < 1 || id == null) return null;");
            sb.AppendLine("");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"        {tableInfo.TableName}DTO? {tableInfo.TableName[0].ToString().ToLower()}DTO = cls{tableInfo.TableName}Data.GetPersonByID(id);");
            else
                sb.AppendLine($"        {tableInfo.TableName}DTO? {tableInfo.TableName[0].ToString().ToLower()}DTO = cls{tableInfo.TableName}Data.Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID(id);");
            sb.AppendLine("");
            sb.AppendLine($"        if ({tableInfo.TableName[0].ToString().ToLower()}DTO != null)");
            sb.AppendLine("         {");
            sb.AppendLine($"             return new cls{tableInfo.TableName}({tableInfo.TableName[0].ToString().ToLower()}DTO, enMode.Update);");
            sb.AppendLine("         }");
            sb.AppendLine("         else");
            sb.AppendLine("             return null;");
            sb.AppendLine("    }");
            sb.AppendLine("");

            // Async.
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"    public static async Task<cls{tableInfo.TableName}?> GetPersonByIDAsync(int? id)");
            else
                sb.AppendLine($"    public static async Task<cls{tableInfo.TableName}?> Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByIDAsync(int? id)");
            sb.AppendLine("    {");
            sb.AppendLine($"           if (id < 1 || id == null) return null;");
            sb.AppendLine("");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"        {tableInfo.TableName}DTO? {tableInfo.TableName[0].ToString().ToLower()}DTO = await cls{tableInfo.TableName}Data.GetPersonByIDAsync(id);");
            else
                sb.AppendLine($"        {tableInfo.TableName}DTO? {tableInfo.TableName[0].ToString().ToLower()}DTO = await cls{tableInfo.TableName}Data.Get{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByIDAsync(id);");
            sb.AppendLine("");
            sb.AppendLine($"        if ({tableInfo.TableName[0].ToString().ToLower()}DTO != null)");
            sb.AppendLine("         {");
            sb.AppendLine($"             return new cls{tableInfo.TableName}({tableInfo.TableName[0].ToString().ToLower()}DTO, enMode.Update);");
            sb.AppendLine("         }");
            sb.AppendLine("         else");
            sb.AppendLine("             return null;");
            sb.AppendLine("    }");
            sb.AppendLine("");

            // =====================================================================================================================
            // IsExists Function.
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"    public static bool IsPersonExistsByID(int? id)");
            else
                sb.AppendLine($"    public static bool Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ExistsByID(int? id)");
            sb.AppendLine("    {");
            sb.AppendLine("           if (id < 1 || id == null) return false;");
            sb.AppendLine("");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"       return cls{tableInfo.TableName}Data.IsPersonExistsByID(id);");
            else
                sb.AppendLine($"       return cls{tableInfo.TableName}Data.Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ExistsByID(id);");
			sb.AppendLine("    }");
            sb.AppendLine("");

            // Async
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"    public static async Task<bool> IsPersonExistsByIDAsync(int? id)");
            else
                sb.AppendLine($"    public static async Task<bool> Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ExistsByIDAsync(int? id)");
            sb.AppendLine("    {");
            sb.AppendLine("           if (id < 1 || id == null) return false;");
            sb.AppendLine("");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"       return await cls{tableInfo.TableName}Data.IsPersonExistsByIDAsync(id);");
            else
                sb.AppendLine($"       return await cls{tableInfo.TableName}Data.Is{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ExistsByIDAsync(id);");
            sb.AppendLine("    }");
            sb.AppendLine("");

            // =====================================================================================================================
            // Delete Function.
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"    public static bool DeletePersonByID(int? id)");
            else
                sb.AppendLine($"    public static bool Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID(int? id)");
            sb.AppendLine("    {");
            sb.AppendLine("           if (id < 1 || id == null) return false;");
            sb.AppendLine("");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"       return cls{tableInfo.TableName}Data.DeletePersonByID(id);");
            else
                sb.AppendLine($"       return cls{tableInfo.TableName}Data.Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByID(id);");
            sb.AppendLine("    }");
            sb.AppendLine("");

            // Async
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"    public static async Task<bool> DeletePersonByIDAsync(int? id)");
            else
                sb.AppendLine($"    public static async Task<bool> Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByIDAsync(int? id)");
            sb.AppendLine("    {");
            sb.AppendLine("           if (id < 1 || id == null) return false;");
            sb.AppendLine("");
            if (tableInfo.TableName == "People" || tableInfo.TableName == "Pepole")
                sb.AppendLine($"       return await cls{tableInfo.TableName}Data.DeletePersonByIDAsync(id);");
            else
                sb.AppendLine($"       return await cls{tableInfo.TableName}Data.Delete{tableInfo.TableName.Remove(tableInfo.TableName.Length - 1)}ByIDAsync(id);");
            sb.AppendLine("    }");
            sb.AppendLine("");


            return sb.ToString();
        }

    }
}
