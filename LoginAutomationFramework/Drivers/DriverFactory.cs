using LoginAutomationFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginAutomationFramework.Drivers
{
    public class DriverFactory
    {
        private static IWebDriver driver;

        public static void InitializeDriver()
        {
            switch (ConfigReader.Browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;

                default:
                    throw new Exception("Browser not supported.");
            }

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(ConfigReader.ImplicitWait);

            driver.Navigate().GoToUrl(ConfigReader.ApplicationUrl);
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void QuitDriver()
        {
            driver.Quit();
        }
    }
}