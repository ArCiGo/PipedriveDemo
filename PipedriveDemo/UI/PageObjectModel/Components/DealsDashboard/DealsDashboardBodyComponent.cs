using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PipedriveDemo.UI.PageObjectModel.Utilities;
using SeleniumExtras.WaitHelpers;

namespace PipedriveDemo.UI.PageObjectModel.Components.DealsDashboard
{
    public class DealsDashboardBodyComponent : PipedriveDemoComponent
    {
        // Variables & Constants
        private readonly WebDriverWait wait;

        // Elements
        private By AddDealButton => By.XPath("//button[@data-test='pipeline-add-deal']");
        private By ContactPersonInputField => By.Id("downshift-0-input");
        private By OrganizationInputField => By.Id("downshift-1-input");
        private By TitleInputFIeld => By.CssSelector("div[data-test-key*='title'] input");
        private By ValueInputField => By.XPath("//div[contains(text(), 'Value')]/following-sibling::div/descendant::input[@data-testid='compound-input']");
        private By ExpectedCloseDateInputFIeld => By.XPath("//div[contains(text(), 'Expected')]/following-sibling::div/descendant::input");
        private By PhoneInputField => By.XPath("//div[contains(text(), 'Phone')]/following-sibling::div/descendant::input");
        private By EmailInputField => By.XPath("//div[contains(text(), 'Email')]/following-sibling::div/descendant::input");
        private By SaveDealButton => By.CssSelector("button[data-test='add-modals-save']");

        // Constructor
        public DealsDashboardBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public void ClickOnAddDeal()
        {
            Driver.FindElement(AddDealButton).Click();
        }

        public void FillAddDealForm(DealModel deal)
        {
            EnterContactPerson(deal.ContactPerson);
            EnterOrganization(deal.Organization);
            EnterTitle(deal.Title);
            EnterValue(deal.Value);
            EnterExpectedCloseDate(deal.ExpectedCloseDate);
            EnterPhoneInput(deal.Phone);
            EnterEmailInput(deal.Email);
        }

        private void EnterContactPerson(string contactPerson)
        {
            var contactPersonInputField = wait.Until(ExpectedConditions.ElementIsVisible(ContactPersonInputField));
            contactPersonInputField.Clear();
            contactPersonInputField.SendKeys(contactPerson);
        }

        private void EnterOrganization(string organization)
        {
            var organizationInputField = wait.Until(ExpectedConditions.ElementIsVisible(OrganizationInputField));
            organizationInputField.Clear();
            organizationInputField.SendKeys(organization);
        }

        private void EnterTitle(string title)
        {
            var titleInputField = wait.Until(ExpectedConditions.ElementIsVisible(TitleInputFIeld));
            titleInputField.Clear();
            titleInputField.SendKeys(title);
        }

        private void EnterValue(string value)
        {
            var valueInputField = wait.Until(ExpectedConditions.ElementIsVisible(ValueInputField));
            valueInputField.Clear();
            valueInputField.SendKeys(value);
        }

        private void EnterExpectedCloseDate(string date)
        {
            var expectedCloseDateInputField = wait.Until(ExpectedConditions.ElementIsVisible(ExpectedCloseDateInputFIeld));
            expectedCloseDateInputField.Clear();
            expectedCloseDateInputField.SendKeys(date);
        }

        private void EnterPhoneInput(string date)
        {
            var phoneInputField = wait.Until(ExpectedConditions.ElementIsVisible(PhoneInputField));
            phoneInputField.Clear();
            phoneInputField.SendKeys(date);
        }

        private void EnterEmailInput(string date)
        {
            var emailInputField = wait.Until(ExpectedConditions.ElementIsVisible(EmailInputField));
            emailInputField.Clear();
            emailInputField.SendKeys(date);
        }

        public void ClickOnSave()
        {
            Driver.FindElement(SaveDealButton).Click();
        }
    }
}

