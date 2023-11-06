using System.Configuration;

namespace BusinessLogic.Configuration
{
    public static class AppConfig
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
    }
}
