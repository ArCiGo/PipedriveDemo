using OpenQA.Selenium;

namespace PipedriveDemo.UI.PageObjectModel.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
