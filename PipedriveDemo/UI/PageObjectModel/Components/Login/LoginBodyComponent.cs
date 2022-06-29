using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PipedriveDemo.UI.PageObjectModel.Pages;
using SeleniumExtras.WaitHelpers;

namespace PipedriveDemo.UI.PageObjectModel.Components.Login
{
    public class LoginBodyComponent : PipedriveDemoComponent
    {
        // Variables & Constants
        private readonly WebDriverWait wait;

        // Elements
        private By EmailInputField => By.Id("login");
        private By PasswordInputField => By.Id("password");
        private By LoginButton => By.Name("submit");

        // Constructor
        public LoginBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public void FillLoginForm(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
        }

        private void EnterEmail(string email)
        {
            var emailInputField = wait.Until(ExpectedConditions.ElementIsVisible(EmailInputField));
            emailInputField.Clear();
            emailInputField.SendKeys(email);
        }

        private void EnterPassword(string password)
        {
            var passwordInputField = wait.Until(ExpectedConditions.ElementIsVisible(PasswordInputField));
            passwordInputField.Clear();
            passwordInputField.SendKeys(password);
        }

        public PipedriveDemoDealsDashboardPage Login()
        {
            Driver.FindElement(LoginButton).Click();

            return new PipedriveDemoDealsDashboardPage(Driver);
        }
    }
}

