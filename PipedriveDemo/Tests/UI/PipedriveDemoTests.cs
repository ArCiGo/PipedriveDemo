using NUnit.Framework;
using PipedriveDemo.Tests.Data;
using PipedriveDemo.UI.PageObjectModel.Pages;
using PipedriveDemo.UI.PageObjectModel.Utilities;

namespace PipedriveDemo.Tests.UI
{
    public class PipedriveDemoTests : BaseTest
    {
        // Variables
        private readonly string baseURL = "https://www.pipedrive.com/en";
        private PipedriveDemoHomePage pdHomePage;
        private PipedriveDemoLoginPage pdLoginPage;
        private PipedriveDemoDealsDashboardPage pdDealsDashPage;
        private PipedriveDemoDealsItemPage pdDealsItemPage;

        // Tests
        [Test(Description = "It creates a new deal"), Category("UI")]
        [TestCaseSource(typeof(Mocks), nameof(Mocks.validDataObjects))]
        [Order(1)]
        public void CreateANewDeal(DealModel deal, string email, string password)
        {
            InitializeObjects();
            pdHomePage.ClickOnLoginLink();

            pdLoginPage.FillLoginForm(email, password);
            pdLoginPage.Login();

            pdDealsDashPage.ClickOnAddDeal();
            pdDealsDashPage.FillAddDealForm(deal);
            pdDealsDashPage.ClickOnSave();
            // Check if the item was created
            Assert.True(pdDealsDashPage.DealWasCreated(deal.Title));

            // It is always a good idea to delete the data we created to avoid flaky tests
            pdDealsDashPage.ClickOnDeal(deal.Title);
            Assert.True(pdDealsItemPage.CheckTitle(deal.Title));

            pdDealsItemPage.DeleteDeal();
            Assert.True(pdDealsItemPage.DealWasDeleted());
        }

        [Test(Description = "It doesn't create a new deal"), Category("UI")]
        [TestCase("", "")]  // here goes your email and password
        [Order(2)]
        public void CreateAnEmptyDealShouldThrowErrors(string email, string password)
        {
            InitializeObjects();
            pdHomePage.ClickOnLoginLink();

            pdLoginPage.FillLoginForm(email, password);
            pdLoginPage.Login();

            pdDealsDashPage.ClickOnAddDeal();
            pdDealsDashPage.ClickOnSave();
            CollectionAssert.AreEqual(Mocks.mandatoryErrors, pdDealsDashPage.MandatoryFormErrors());
        }

        // Extracting code
        private void InitializeObjects()
        {
            pdHomePage = new PipedriveDemoHomePage(Driver);
            pdLoginPage = new PipedriveDemoLoginPage(Driver);
            pdDealsDashPage = new PipedriveDemoDealsDashboardPage(Driver);
            pdDealsItemPage = new PipedriveDemoDealsItemPage(Driver);

            pdHomePage.GoTo(baseURL);
        }
    }
}