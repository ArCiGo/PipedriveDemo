using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PipedriveDemo.Tests.UI.AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver GetDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.Firefox:
                    return GetFirefoxDriver();
                default:
                    ArgumentException ex = new ArgumentException("No such browser exists!");
                    throw ex;
            }
        }

        private IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");

            return new ChromeDriver(options);
        }

        private IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }
    }
}

