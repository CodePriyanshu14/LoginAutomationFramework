using LoginAutomationFramework.Drivers;
using OpenQA.Selenium;


namespace LoginAutomationFramework.Utilities
{
    public class BrowserActions
    {
        private static IWebDriver Driver => DriverFactory.GetDriver();

        public static void Click(By locator)
        {
            WaitHelper.WaitUntilClickable(locator).Click();
        }

        public static void EnterText(By locator, string text)
        {
            IWebElement element = WaitHelper.WaitUntilVisible(locator);

            element.Clear();
            element.SendKeys(text);
        }

        public static string GetText(By locator)
        {
            return WaitHelper.WaitUntilVisible(locator).Text;
        }

        public static bool IsDisplayed(By locator)
        {
            try
            {
                return WaitHelper.WaitUntilVisible(locator).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public static void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static void PressTab()
        {
            Driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
        }

        public static void SwitchToNewTab()
        {
            var driver = DriverFactory.GetDriver();

            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void SwitchToFirstTab()
        {
            var driver = DriverFactory.GetDriver();

            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        public static void CloseCurrentTab()
        {
            DriverFactory.GetDriver().Close();
        }

        public static void OpenLinkInNewTab(IWebElement element)
        {
            IJavaScriptExecutor js =
                (IJavaScriptExecutor)Driver;

            string url = element.GetAttribute("href");

            js.ExecuteScript($"window.open('{url}','_blank');");
        }

        public static IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return Driver.FindElements(locator);
        }
    }
}