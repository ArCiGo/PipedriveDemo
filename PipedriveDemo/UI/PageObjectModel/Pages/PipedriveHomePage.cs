using OpenQA.Selenium;
using PipedriveDemo.UI.PageObjectModel.Components.Home;

namespace PipedriveDemo.UI.PageObjectModel.Pages
{
    public class PipedriveHomePage : BasePage
    {
        // Variables & Constants
        private readonly HomeHeaderComponent homeHeaderComponent;

        // Constructor
        public PipedriveHomePage(IWebDriver driver) : base(driver)
        {
            homeHeaderComponent = new HomeHeaderComponent(driver);
        }

        // Actions
        public void GoTo(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public PipedriveLoginPage Login()
        {
            return homeHeaderComponent.Login();
        }
    }
}