using OpenQA.Selenium;
using LoginAutomationFramework.Utilities;

namespace LoginAutomationFramework.Pages
{
    public class HomePage : BasePage
    {
        private readonly By lnkPortalLogin =
            By.LinkText("Portal Login");

        private readonly By lnkExploreMore =
    By.XPath("//a[contains(normalize-space(),'Explore More')]");

        public IReadOnlyCollection<IWebElement> GetExploreMoreLinks()
        {
            return BrowserActions.FindElements(lnkExploreMore);
        }

        public void CaptureExploreMoreScreenshots()
        {
            var links = GetExploreMoreLinks()
            .Where(x => x.Displayed)
            .ToList();

            int count = 0;

            string[] pageNames =
            {
                "DataSolutions",
                "DigitalSolutions",
                "Listings"
            };

            foreach (IWebElement link in links)
            {
                BrowserActions.OpenLinkInNewTab(link);

                BrowserActions.SwitchToNewTab();

                WaitHelper.WaitForPageToLoad();

                ScreenshotHelper.CaptureScreenshot(pageNames[count]);

                BrowserActions.CloseCurrentTab();

                BrowserActions.SwitchToFirstTab();

                count++;
            }
        }

        public void OpenPortalLogin()
        {
            BrowserActions.Click(lnkPortalLogin);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        public void OpenHomePage()
        {
            BrowserActions.Navigate(ConfigReader.ApplicationUrl);
        }
    }
}