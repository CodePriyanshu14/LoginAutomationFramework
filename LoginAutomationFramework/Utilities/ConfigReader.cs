using Microsoft.Extensions.Configuration;

namespace LoginAutomationFramework.Utilities
{
    public static class ConfigReader
    {
        private static readonly IConfigurationRoot configuration;

        static ConfigReader()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Configurations/appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string Browser =>
            configuration["BrowserSettings:Browser"];

        public static string ApplicationUrl =>
            configuration["ApplicationSettings:ApplicationUrl"];

        public static string LoginUrl =>
            configuration["ApplicationSettings:LoginUrl"];

        public static int ImplicitWait =>
            int.Parse(configuration["BrowserSettings:ImplicitWait"]);

        public static int ExplicitWait =>
            int.Parse(configuration["BrowserSettings:ExplicitWait"]);

        public static string ScreenshotPath =>
            configuration["Paths:ScreenshotPath"];

        public static string ExcelPath =>
            configuration["Paths:ExcelPath"];
    }
}