// Login Page Object - COnf

using OpenQA.Selenium;
using LoginAutomationFramework.Utilities;

namespace LoginAutomationFramework.Pages
{
    public class LoginPage : BasePage
    {
        // Login Page
        private readonly By txtUsername = By.Id("username");

        private readonly By txtPassword = By.Id("password");

        private readonly By btnContinue =
    By.CssSelector("button[data-action-button-primary='true']");

        private readonly By lnkForgotPassword = By.LinkText("Forgot password?");

        // Validation Messages
        private readonly By lblInvalidEmail =
            By.Id("error-cs-email-invalid");

        private readonly By lblWrongCredentials =
            By.Id("error-element-password");

        private readonly By lblCheckYourEmail =
            By.XPath("//h1[text()='Check Your Email']");


        public void EnterUsername(string username)
        {
            BrowserActions.EnterText(txtUsername, username);
        }

        public void EnterPassword(string password)
        {
            BrowserActions.EnterText(txtPassword, password);
        }

        public void ClickLoginButton()
        {
            BrowserActions.Click(btnContinue);
        }

        public void ClickForgotPassword()
        {
            BrowserActions.Click(lnkForgotPassword);
        }

        public string GetInvalidEmailMessage()
        {
            return BrowserActions.GetText(lblInvalidEmail);
        }

        public string GetWrongCredentialsMessage()
        {
            return BrowserActions.GetText(lblWrongCredentials);
        }

        public string GetCheckYourEmailMessage()
        {
            return BrowserActions.GetText(lblCheckYourEmail);
        }

        // Helper Methods for Login and Forgot Password
        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public void ForgotPassword(string email)
        {
            ClickForgotPassword();
            EnterUsername(email);
            ClickLoginButton();
        }

        public bool IsLoginPageDisplayed()
        {
            return BrowserActions.IsDisplayed(txtUsername);
        }
    }
}