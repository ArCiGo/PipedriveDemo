using OpenQA.Selenium;
using PipedriveDemo.UI.PageObjectModel.Components.Login;

namespace PipedriveDemo.UI.PageObjectModel.Pages
{
    public class PipedriveDemoLoginPage : BasePage
    {
        // Variables & Constants
        private readonly LoginBodyComponent loginBodyComponent;

        // Constructor
        public PipedriveDemoLoginPage(IWebDriver driver) : base(driver)
        {
            loginBodyComponent = new LoginBodyComponent(driver);
        }

        // Actions
        public void FillLoginForm(string email, string password)
        {
            loginBodyComponent.FillLoginForm(email, password);
        }

        public PipedriveDemoDealsDashboardPage Login()
        {
            return loginBodyComponent.Login();
        }
    }
}
