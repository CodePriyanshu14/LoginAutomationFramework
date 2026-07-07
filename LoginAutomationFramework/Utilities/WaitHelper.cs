using LoginAutomationFramework.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LoginAutomationFramework.Utilities
{
    public class WaitHelper
    {
        private static IWebDriver Driver => DriverFactory.GetDriver();

        private static WebDriverWait GetWait()
        {
            return new WebDriverWait(
                Driver,
                TimeSpan.FromSeconds(ConfigReader.ExplicitWait));
        }

        public static IWebElement WaitUntilVisible(By locator)
        {
            return GetWait().Until(driver =>
            {
                IWebElement element = driver.FindElement(locator);

                if (element.Displayed)
                    return element;

                return null;
            });
        }

        public static IWebElement WaitUntilClickable(By locator)
        {
            return GetWait().Until(driver =>
            {
                IWebElement element = driver.FindElement(locator);

                if (element.Displayed && element.Enabled)
                    return element;

                return null;
            });
        }

        public static void WaitForPageToLoad()
        {
            WebDriverWait wait = new WebDriverWait(
                Driver,
                TimeSpan.FromSeconds(ConfigReader.ExplicitWait));

            wait.Until(driver =>
            {
                return ((IJavaScriptExecutor)driver)
                    .ExecuteScript("return document.readyState")
                    .Equals("complete");
            });
        }
    }
}