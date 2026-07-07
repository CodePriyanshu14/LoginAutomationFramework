using LoginAutomationFramework.Pages;
using TechTalk.SpecFlow;

namespace LoginAutomationFramework.StepDefinitions
{
    [Binding]
    public class ExploreMoreSteps
    {
        private readonly HomePage homePage = new HomePage();

        [Given(@"User is on Home Page")]
        public void GivenUserIsOnHomePage()
        {
            homePage.OpenHomePage();
        }

        [When(@"User captures screenshots of all Explore More pages")]
        public void WhenUserCapturesScreenshotsOfAllExploreMorePages()
        {
            homePage.CaptureExploreMoreScreenshots();
        }
    }
}