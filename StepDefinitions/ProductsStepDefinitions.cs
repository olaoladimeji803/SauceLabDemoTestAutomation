using NUnit.Framework;
using NUnit.Framework.Legacy;
using SauceDemoTestAutomation.Pages;
using SauceDemoTestAutomation.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemoTestAutomation.StepDefinitions
{
    [Binding]
    internal class ProductsStepDefinitions
    {
        Context _context;
        Products _products;
        public ProductsStepDefinitions(Context context, Products products)
        {
            _context = context; 
            _products = products;
        }

        [When(@"user select a Sauce Labs Backpack item and click 'Add to Cart'")]
        public void WhenUserSelectABackpackItemAndClick()
        {
            _products.SelectABackpackProductAndAddToCart();
        }

        [Then(@"user should see the selected (.*) item appears in the cart list")]
        public void ThenUserShoudSeeThatTheSelectedItemAppearsInTheCartList_(string expectedMessage)
        {
            string actualString = _products.GetBackPackItemText();
            StringAssert.Contains(expectedMessage, actualString, "Sauce Labs Backpack carry.allTheThings() with the sleek");
            Assert.That(actualString.Count, Is.GreaterThan(0));
        }

        [Then(@"user remove the Sauce Labs Backpack item")]
        public void ThenUserRemoveTheSauceLabsBackpackItem()
        {
            _products.ClickOnRemoveItem();
        }

        [Then(@"the removed Sauce Labs Backpack item should no longer appear in the cart list")]
        public void ThenTheRemovedSauceLabsBackpackItemShouldNoLongerAppearInTheCartList()
        {
            var actualitemNo = _products.RemovedBackPackItemInCartList();
            Assert.That(actualitemNo.Count, Is.EqualTo(0));
        }

        [When(@"the user proceed to checkout")]
        public void WhenTheUserProceedToCheckout()
        {
           _products.ClickOnCheckOutButton();
        }

        [When(@"user fill in the required information (.*) (.*) (.*) and complete the purchase")]
        public void WhenUserFillInTheRequiredInformationKazeemIyiolaMAUAndCompleteThePurchase(string fName, string lName, string pCode)
        {
           _products.purchaseItem(fName, lName, pCode);
        }

        [Then(@"verify redirection to the confirmation page and (.*) is displayed accurately")]
        public void ThenVerifyRedirectionToTheConfirmationPageAndOrderSummaryIsDisplayedAccurately_(string expectedConfirmationText)
        {
            string actualConfirmationText = _products.GetConfirmationText();
            StringAssert.Contains(expectedConfirmationText, actualConfirmationText, "Your order has been dispatched, and will arrive just as fast as the pony can get there!");
        }

        [Then(@"the cart count increases in the cart basket")]
        public void ThenTheCartCountIncreasesInTheCartBasket()
        {
            var itemsNo =  _products.AddItemToCartList();
            Assert.That(itemsNo.Count, Is.EqualTo(1));
        }

        [When(@"user select a Sauce Bike Light item and click 'Add to Cart'")]
        public void WhenUserSelectASauceBikeLightItemAndClick()
        {
            _products.AddBikeLightItemsToCartList();
        }

        [When(@"user select a Sauce Bolt T-Shirt item and click 'Add to Cart'")]
        public void WhenUserSelectASauceBoltT_ShirtItemAndClick()
        {
            _products.AddBoltTShirtItemsToCartList();
        }

        [When(@"user select a Sauce Fleece Jacket item and click 'Add to Cart'")]
        public void WhenUserSelectASauceFleeceJacketItemAndClick()
        {
            _products.AddFleeceJacketItemsToCartList();
        }

        [Then(@"the cart count increases to (.*) in the cart basket")]
        public void ThenTheCartCountIncreasesToInTheCartBasket(int p0)
        {
            throw new PendingStepException();
        }
    }
}
