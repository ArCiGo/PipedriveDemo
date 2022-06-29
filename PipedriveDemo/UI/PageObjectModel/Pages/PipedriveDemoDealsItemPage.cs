using OpenQA.Selenium;
using PipedriveDemo.UI.PageObjectModel.Components.DealsItem;

namespace PipedriveDemo.UI.PageObjectModel.Pages
{
    public class PipedriveDemoDealsItemPage : BasePage
    {
        // Variables & Constants
        private readonly DealsItemBodyComponent dealsItemBodyComponent;

        // Constructor
        public PipedriveDemoDealsItemPage(IWebDriver driver) : base(driver)
        {
            dealsItemBodyComponent = new DealsItemBodyComponent(driver);
        }

        // Actions
        public bool CheckTitle(string dealTitle)
        {
            return dealsItemBodyComponent.CheckTitle(dealTitle);
        }

        public void DeleteDeal()
        {
            dealsItemBodyComponent.DeleteDeal();
        }

        public bool DealWasDeleted()
        {
            return dealsItemBodyComponent.DealWasDeleted();
        }
    }
}

