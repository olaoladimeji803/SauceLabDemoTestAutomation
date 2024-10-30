using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTestAutomation.Pages
{
    internal class Checkout
    {
        IWebDriver _driver;
        public Checkout(IWebDriver driver)
        {
            _driver = driver;
        }

        By firstNameField = By.Id("first-name");
        By lastNameField = By.Id("last-name");
        By postCodeField = By.Id("postal-code");
        By continueButton = By.CssSelector("input.btn_primary.cart_button");
        By finishButton = By.CssSelector("a.btn_action.cart_button");
        By cancelButton = By.CssSelector("a.cart_cancel_link.btn_secondary");
        By confirmationTextMessage = By.CssSelector("div.complete-text");
        By subtotal = By.CssSelector("div.summary_subtotal_label");

        public void EnterInformationDetails(string fName, string lName, string pcode)
        {
            _driver.FindElement(firstNameField).SendKeys(fName);
            _driver.FindElement(lastNameField).SendKeys(lName);
            _driver.FindElement(postCodeField).SendKeys(pcode);
            _driver.FindElement(continueButton).Click();
        }

        public void ClickOnFinishButton()
        {
            _driver.FindElement(finishButton).Click();
        }

        public void ClickOnCancelButton()
        {
            _driver.FindElement(cancelButton).Click();
        }

        public string GetConfirmationText()
        {
            return _driver.FindElement(confirmationTextMessage).Text;
        }

        public string ReturnCalculatedItemTotalValue()
        {
            return _driver.FindElement(subtotal).Text;
        }
    }
}
