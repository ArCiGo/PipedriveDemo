using OpenQA.Selenium;
using PipedriveDemo.UI.PageObjectModel.Components.DealsDashboard;
using PipedriveDemo.UI.PageObjectModel.Utilities;

namespace PipedriveDemo.UI.PageObjectModel.Pages
{
    public class PipedriveDemoDealsDashboardPage : BasePage
    {
        // Variables & Constants
        private readonly DealsDashboardBodyComponent dealsDashboardBodyComponent;

        // Constructor
        public PipedriveDemoDealsDashboardPage(IWebDriver driver) : base(driver)
        {
            dealsDashboardBodyComponent = new DealsDashboardBodyComponent(driver);
        }

        // Actions
        public void ClickOnAddDeal()
        {
            dealsDashboardBodyComponent.ClickOnAddDeal();
        }

        public void FillAddDealForm(DealModel deal)
        {
            dealsDashboardBodyComponent.FillAddDealForm(deal);
        }

        public void ClickOnSave()
        {
            dealsDashboardBodyComponent.ClickOnSave();
        }

        public bool DealWasCreated(string dealTitle)
        {
            return dealsDashboardBodyComponent.DealWasCreated(dealTitle);
        }

        public PipedriveDemoDealsItemPage ClickOnDeal(string dealTitle)
        {
            return dealsDashboardBodyComponent.ClickOnDeal(dealTitle);
        }

        public List<string> MandatoryFormErrors()
        {
            return dealsDashboardBodyComponent.MandatoryFormErrors();
        }
    }
}

