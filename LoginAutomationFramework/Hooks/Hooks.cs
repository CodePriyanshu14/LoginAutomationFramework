using LoginAutomationFramework.Drivers;
using TechTalk.SpecFlow;

namespace LoginAutomationFramework.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverFactory.InitializeDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverFactory.QuitDriver();
        }
    }
}