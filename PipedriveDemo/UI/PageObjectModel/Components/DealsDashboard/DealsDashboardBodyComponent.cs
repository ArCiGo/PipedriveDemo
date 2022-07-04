using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PipedriveDemo.UI.PageObjectModel.Pages;
using PipedriveDemo.UI.PageObjectModel.Utilities;
using SeleniumExtras.WaitHelpers;

namespace PipedriveDemo.UI.PageObjectModel.Components.DealsDashboard
{
    public class DealsDashboardBodyComponent : PipedriveDemoComponent
    {
        // Variables & Constants
        private readonly WebDriverWait wait;
        private string dealContactPerson;
        private List<string> errores;

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
        private By DealDraggableItems => By.XPath("//div[@draggable]/descendant::a[contains(@class, 'sc-kjEcyX')]/span");
        private By ContactPersonError => By.XPath("//div[contains(text(), 'Contact person')]/following-sibling::div/descendant::div[@class = 'cui5-input__error-message']");
        private By OrganizationError => By.XPath("//div[contains(text(), 'Organization')]/following-sibling::div/descendant::div[@class = 'cui5-input__error-message']");
        private By TitleError => By.XPath("//div[contains(text(), 'Title')]/following-sibling::div/descendant::div[@class = 'cui5-input__error-message']");

        // Constructor
        public DealsDashboardBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Actions
        public void ClickOnAddDeal()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(AddDealButton)).Click();
        }

        public void FillAddDealForm(DealModel deal)
        {
            dealContactPerson = deal.ContactPerson;

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

            if(!String.IsNullOrEmpty(contactPerson) || !String.IsNullOrWhiteSpace(contactPerson))
                contactPersonInputField.SendKeys(contactPerson);
        }

        private void EnterOrganization(string organization)
        {
            var organizationInputField = wait.Until(ExpectedConditions.ElementIsVisible(OrganizationInputField));
            organizationInputField.Clear();

            if (!String.IsNullOrEmpty(organization) || !String.IsNullOrWhiteSpace(organization))
                organizationInputField.SendKeys(organization);
        }

        private void EnterTitle(string title)
        {
            var titleInputField = wait.Until(ExpectedConditions.ElementIsVisible(TitleInputFIeld));
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].value = ''", titleInputField);

            if (!String.IsNullOrEmpty(title) || !String.IsNullOrWhiteSpace(title))
                titleInputField.SendKeys(title);
        }

        private void EnterValue(string value)
        {
            var valueInputField = wait.Until(ExpectedConditions.ElementIsVisible(ValueInputField));
            valueInputField.Clear();

            if (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value))
                valueInputField.SendKeys(value);
        }

        private void EnterExpectedCloseDate(string date)
        {
            var expectedCloseDateInputField = wait.Until(ExpectedConditions.ElementIsVisible(ExpectedCloseDateInputFIeld));
            expectedCloseDateInputField.Clear();

            if (!String.IsNullOrEmpty(date) || !String.IsNullOrWhiteSpace(date))
                expectedCloseDateInputField.SendKeys(date);
        }

        private void EnterPhoneInput(string phone)
        {
            var phoneInputField = wait.Until(ExpectedConditions.ElementIsVisible(PhoneInputField));
            phoneInputField.Clear();

            if(!String.IsNullOrEmpty(phone) || !String.IsNullOrWhiteSpace(phone))
                phoneInputField.SendKeys(phone);
        }

        private void EnterEmailInput(string email)
        {
            var emailInputField = wait.Until(ExpectedConditions.ElementIsVisible(EmailInputField));
            emailInputField.Clear();

            if (!String.IsNullOrEmpty(email) || !String.IsNullOrWhiteSpace(email))
                emailInputField.SendKeys(email);
        }        

        public void ClickOnSave()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(SaveDealButton)).Click();

            if(!String.IsNullOrEmpty(dealContactPerson) || !String.IsNullOrWhiteSpace(dealContactPerson))
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@data-test='add-modal']")));
        }

        public bool DealWasCreated(string dealTitle)
        {
            var dealDraggableItems = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(DealDraggableItems));

            foreach (var item in dealDraggableItems)
            {
                if (item.Text.Contains(dealTitle))
                {
                    return true;
                }
            }

            return false;
        }

        public PipedriveDemoDealsItemPage ClickOnDeal(string dealTitle)
        {
            var dealDraggableItems = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(DealDraggableItems));

            foreach (var item in dealDraggableItems)
            {
                if (item.Text.Contains(dealTitle))
                {
                    item.Click();
                }
            }

            return new PipedriveDemoDealsItemPage(Driver);
        }

        public List<string> MandatoryFormErrors()
        {
            ClickOnSave();

            return new List<string>()
            {
                wait.Until(ExpectedConditions.ElementIsVisible(ContactPersonError)).Text,
                wait.Until(ExpectedConditions.ElementIsVisible(OrganizationError)).Text,
                wait.Until(ExpectedConditions.ElementIsVisible(TitleError)).Text
            };
        }
    }
}

