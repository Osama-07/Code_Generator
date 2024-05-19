using System.Configuration;

namespace Generator_Code_Data
{
    public static class clsSettingsDataAccess
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}
