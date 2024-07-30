using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Generator_Code_Data
{
    public static class clsSettingsDataAccess
    {
        public static string ConnectionString = GetConnectionString("DefaultConnection");

        private static string GetConnectionString(string name)
        {
            string _jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            var json = File.ReadAllText(_jsonFilePath);
            var jsonObj = JObject.Parse(json);
            return jsonObj["ConnectionStrings"][name].ToString();
        }
    }
}
