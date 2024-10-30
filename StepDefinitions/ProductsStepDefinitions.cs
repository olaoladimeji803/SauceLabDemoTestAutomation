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
        Checkout _checkout;
        public ProductsStepDefinitions(Context context, Products products, Checkout checkout)
        {
            _context = context; 
            _products = products;
            _checkout = checkout;
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

        [When(@"user fill in the required information (.*) (.*) (.*) and continue")]
        public void WhenUserFillInTheRequiredInformationKazeemIyiolaMAUAndCompleteThePurchase(string fName, string lName, string pCode)
        {
           _checkout.EnterInformationDetails(fName, lName, pCode);
        }

        [Then(@"verify redirection to the confirmation page and (.*) is displayed accurately")]
        public void ThenVerifyRedirectionToTheConfirmationPageAndOrderSummaryIsDisplayedAccurately_(string expectedConfirmationText)
        {
            string actualConfirmationText = _checkout.GetConfirmationText();
            StringAssert.Contains(expectedConfirmationText, actualConfirmationText, "Your order has been dispatched, and will arrive just as fast as the pony can get there!");
        }

        [Then(@"the cart count increases to '1' in the cart basket")]
        public void ThenTheCartCountIncreasesInTheCartBasket()
        {
            var itemsNo =  _products.AddItemToCartList();
            Assert.That(itemsNo.Count, Is.EqualTo(1));
        }

        [When(@"user select a 'Sauce Lab Bike Light' item cost 9.99 each")]
        public void WhenUserSelectAItemAtCostPriceOf()
        {
            _products.AddBikeLightItemsToCartList();
        }

        [When(@"user select a 'Sauce Lab Bolt T-Shirt' item cost 15.99 each")]
        public void WhenUserSelectAItemAtPriceOf()
        {
            _products.AddBoltTShirtItemsToCartList();
        }

        [When(@"user click on cart")]
        public void WhenUserClickOnCart()
        {
           _products.ClickOnCart();
        }

        [Then(@"the user is redirected to the Checkout Overview page and (.*) are correctly dislayed")]
        public void ThenTheUserIsRedirectedToTheCheckoutOverviewPageAndAreCorrectlyDislayed(string expectedItemTotal)
        {
             var actualItemTotal = _checkout.ReturnCalculatedItemTotalValue();
              Assert.That(actualItemTotal, Is.EqualTo(expectedItemTotal)); 
        }


        [When(@"user complete the order and checkout process")]
        public void WhenUserCompleteTheOrderAndCheckoutProcess()
        {
            _checkout.ClickOnFinishButton();
        }

        [When(@"the user cancel the order")]
        public void WhenTheUserCancelTheOrder()
        {
            _checkout.ClickOnCancelButton();
        }

    }
}
