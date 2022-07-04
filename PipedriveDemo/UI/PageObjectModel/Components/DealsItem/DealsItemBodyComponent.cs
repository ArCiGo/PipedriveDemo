using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PipedriveDemo.UI.PageObjectModel.Components.DealsItem
{
    public class DealsItemBodyComponent : PipedriveDemoComponent
    {
        // Variables & Constants
        private readonly WebDriverWait wait;

        // Elements
        private By TitleHeadH1 => By.CssSelector("div[class='descriptionHead'] h1 a");
        private By MenuSettingsButton => By.CssSelector("div[class = 'content actionsContent'] div[class = 'actions'] span[class *= 'selectSettings']");
        private By MenuSettingsOptions => By.CssSelector("div[class *= 'dropMenu'] ul li");
        private By DeletedBadge => By.XPath("//div[@class = 'actions']/div[contains(@class, 'dealStatus')]/span");

        // Constructor
        public DealsItemBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Actions
        public bool CheckTitle(string dealTitle)
        {
            var titleHeadH1 = wait.Until(ExpectedConditions.ElementIsVisible(TitleHeadH1)).Text;

            if (titleHeadH1.Contains(dealTitle))
                return true;

            return false;
        }

        public void DeleteDeal()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(MenuSettingsButton)).Click();

            var menuSettingsOptions = Driver.FindElements(MenuSettingsOptions);

            foreach (var item in menuSettingsOptions)
            {
                if (item.Text.Trim().Contains("Delete"))
                {
                    item.Click();
                    Driver.SwitchTo().Alert().Accept();
                    break;
                }
            }
        }

        public bool DealWasDeleted()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(DeletedBadge)).Displayed;
        }
    }
}

