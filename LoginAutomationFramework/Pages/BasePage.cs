using LoginAutomationFramework.Drivers;
using OpenQA.Selenium;

namespace LoginAutomationFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver => DriverFactory.GetDriver();
    }
}