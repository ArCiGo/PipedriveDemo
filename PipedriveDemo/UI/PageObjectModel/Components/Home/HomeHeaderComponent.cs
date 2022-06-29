using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PipedriveDemo.UI.PageObjectModel.Pages;
using SeleniumExtras.WaitHelpers;

namespace PipedriveDemo.UI.PageObjectModel.Components.Home
{
    public class HomeHeaderComponent : PipedriveDemoComponent
    {
        // Variables & Constants
        private readonly WebDriverWait wait;

        // Elements
        private By LoginLink => By.XPath("//a[contains(@class, 'puco-navigation-link')]/span[contains(text(), 'Log')]");

        // Constructor
        public HomeHeaderComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Actions
        public PipedriveDemoLoginPage ClickOnLoginLink()
        {
            var loginLink = wait.Until(ExpectedConditions.ElementIsVisible(LoginLink));
            loginLink.Click();

            return new PipedriveDemoLoginPage(Driver);
        }
    }
}

