namespace TheCoffeeCatStore.Admin
{
    public class AdminConfig
    {
        public static string GetAdminEmail()
        {
            var _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            return _config["admin:email"];
        }

        public static string GetAdminPassword()
        {
            var _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            return _config["admin:password"];
        }
    }
}
