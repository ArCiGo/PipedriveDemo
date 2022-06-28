using OpenQA.Selenium;

namespace PipedriveDemo.UI.PageObjectModel.Components
{
    public class PipedriveDemoComponent
    {
        protected IWebDriver Driver { get; set; }

        public PipedriveDemoComponent(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
