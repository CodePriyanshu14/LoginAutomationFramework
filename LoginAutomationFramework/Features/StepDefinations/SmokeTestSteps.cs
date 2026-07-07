using LoginAutomationFramework.Pages;
using TechTalk.SpecFlow;

namespace LoginAutomationFramework.Features.StepDefinations
{
    [Binding]
    public class SmokeTestSteps
    {
        private readonly HomePage homePage = new HomePage();
        private readonly LoginPage loginPage = new LoginPage();

        [Given(@"User launches application")]
        public void GivenUserLaunchesApplication()
        {
            // Browser is launched from Hooks
        }

        [When(@"User opens the Portal Login page")]
        public void WhenUserOpensThePortalLoginPage()
        {
            homePage.OpenPortalLogin();
        }

        [Then(@"Login page should be displayed")]
        public void ThenLoginPageShouldBeDisplayed()
        {
            Assert.IsTrue(loginPage.IsLoginPageDisplayed());
        }
    }
}