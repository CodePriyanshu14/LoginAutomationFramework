using LoginAutomationFramework.Pages;
using LoginAutomationFramework.Utilities;
using TechTalk.SpecFlow;
using LoginAutomationFramework.Models;

namespace LoginAutomationFramework.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly HomePage homePage = new HomePage();

        private readonly LoginPage loginPage = new LoginPage();

        private LoginDataModel loginData;

        [Given(@"User is on the Login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            homePage.OpenPortalLogin();
        }

        //Invalid Email
        [When(@"User enters invalid email format ""(.*)""")]
        public void WhenUserEntersInvalidEmailFormat(string email)
        {
            loginPage.EnterUsername(email);

        }

        [When(@"User enters email from Excel")]
        public void WhenUserEntersEmailFromExcel()
        {
            loginPage.EnterUsername(loginData.Email);
        }

        [When(@"User enters password from Excel")]
        public void WhenUserEntersPasswordFromExcel()
        {
            loginPage.EnterPassword(loginData.Password);
        }

        [When(@"User loads test data ""(.*)""")]
        public void WhenUserLoadsTestData(string testCase)
        {
            loginData = ExcelHelper.GetLoginData(testCase);
        }

        [When(@"User enters any password ""(.*)""")]
        public void WhenUserEntersAnyPassword(string password)
        {
            loginPage.EnterPassword(password);
        }

        //Invalid Username
        [When(@"User enters invalid username ""(.*)""")]
        public void WhenUserEntersInvalidUsername(string username)
        {
            loginPage.EnterUsername(username);
        }

        //Valid Username
        [When(@"User enters valid username ""(.*)""")]
        public void WhenUserEntersValidUsername(string username)
        {
            loginPage.EnterUsername(username);
        }

        //Valid Password
        [When(@"User enters valid password ""(.*)""")]
        public void WhenUserEntersValidPassword(string password)
        {
            loginPage.EnterPassword(password);
        }

        //Invalid Password
        [When(@"User enters invalid password ""(.*)""")]
        public void WhenUserEntersInvalidPassword(string password)
        {
            loginPage.EnterPassword(password);
        }

        //Login Button
        [When(@"User clicks the Login button")]
        public void WhenUserClicksTheLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        //Forgot Password
        [When(@"User clicks Forgot Password")]
        public void WhenUserClicksForgotPassword()
        {
            loginPage.ClickForgotPassword();
        }

        // Recovery Email
        [When(@"User enters recovery email ""(.*)""")]
        public void WhenUserEntersRecoveryEmail(string email)
        {
            loginPage.EnterUsername(email);
        }

        //Submit
        [When(@"User submits Forgot Password request")]
        public void WhenUserSubmitsForgotPasswordRequest()
        {
            loginPage.ClickLoginButton();
        }

        //THEN

        //Invalid Email
        [Then(@"User should see invalid email message ""(.*)""")]
        public void ThenUserShouldSeeInvalidEmailMessage(string expectedMessage)
        {
            string actualMessage = loginPage.GetInvalidEmailMessage();

            Console.WriteLine("========== Validation ==========");
            Console.WriteLine($"Expected : {expectedMessage}");
            Console.WriteLine($"Actual   : {actualMessage}");
            Console.WriteLine("================================");

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        //Wrong Credentials
        [Then(@"User should see wrong credentials message ""(.*)""")]
        public void ThenUserShouldSeeWrongCredentialsMessage(string expectedMessage)
        {
            string actualMessage = loginPage.GetWrongCredentialsMessage();

            Console.WriteLine($"Actual Message : {actualMessage}");

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        //Forgot Password
        [Then(@"User should see confirmation message ""(.*)""")]
        public void ThenUserShouldSeeConfirmationMessage(string expectedMessage)
        {
            string actualMessage = loginPage.GetCheckYourEmailMessage();

            Console.WriteLine($"Actual Message : {actualMessage}");

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

    }
}