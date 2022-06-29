using OpenQA.Selenium;
using PipedriveDemo.UI.PageObjectModel.Components.Home;

namespace PipedriveDemo.UI.PageObjectModel.Pages
{
    public class PipedriveDemoHomePage : BasePage
    {
        // Variables & Constants
        private readonly HomeHeaderComponent homeHeaderComponent;

        // Constructor
        public PipedriveDemoHomePage(IWebDriver driver) : base(driver)
        {
            homeHeaderComponent = new HomeHeaderComponent(driver);
        }

        // Actions
        public void GoTo(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public PipedriveDemoLoginPage ClickOnLoginLink()
        {
            return homeHeaderComponent.ClickOnLoginLink();
        }
    }
}