using System.Configuration;

namespace Karate_Club_Data_Access
{
    internal static class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
    }
}
