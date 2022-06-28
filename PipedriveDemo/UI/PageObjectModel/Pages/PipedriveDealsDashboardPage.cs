using OpenQA.Selenium;
using PipedriveDemo.UI.PageObjectModel.Components.DealsDashboard;
using PipedriveDemo.UI.PageObjectModel.Utilities;

namespace PipedriveDemo.UI.PageObjectModel.Pages
{
    public class PipedriveDealsDashboardPage : BasePage
    {
        // Variables & Constants
        private readonly DealsDashboardBodyComponent dealsDashboardBodyComponent;

        // Constructor
        public PipedriveDealsDashboardPage(IWebDriver driver) : base(driver)
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
    }
}

