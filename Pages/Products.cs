using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V126.DOM;
using OpenQA.Selenium.DevTools.V126.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTestAutomation.Pages
{
    public class Products
    {
        IWebDriver _driver;
        public Products(IWebDriver driver)
        {
            _driver = driver;
        }
        
        By backPackItem = By.XPath("//*[@id='item_4_img_link']/img");
        By addToCartBaclPack = By.XPath("//*[text()='ADD TO CART']");
        By cartBasket = By.XPath("//*[@class='fa-layers-counter shopping_cart_badge']");
        By BackPackItemTextMsg = By.XPath("//*[@class='cart_item_label']");
        By removeButton = By.CssSelector("button.btn_secondary.cart_button");
        By cartListItem = By.CssSelector("a.shopping_cart_link.fa-layers.fa-fw");
        By cartListItem1 = By.CssSelector("span.fa-layers-counter.shopping_cart_badge");                                  
        By checkOutButton = By.CssSelector("a.btn_action.checkout_button");
        By backLightItem = By.CssSelector("#inventory_container > div > div:nth-child(2) > div.pricebar > button");
        By boltTShirtItem = By.CssSelector("#inventory_container > div > div:nth-child(3) > div.pricebar > button");
        
        public void SelectABackpackProductAndAddToCart()
        {
            _driver.FindElement(backPackItem).Click();
            _driver.FindElement(addToCartBaclPack).Click();
            _driver.FindElement(cartBasket).Click();
        }

        public void ClickOnCart()
        {
            _driver.FindElement(cartBasket).Click();
        }

        public string GetBackPackItemText()
        {
            return _driver.FindElement(BackPackItemTextMsg).Text;
        }
        public void ClickOnRemoveItem()
        {
            _driver.FindElement(removeButton).Click();
        }

        public string RemovedBackPackItemInCartList()
        {
            return _driver.FindElement(cartListItem).Text;
        }

        public string AddItemToCartList()
        {
            return _driver.FindElement(cartListItem1).Text;
        }

        public void ClickOnCheckOutButton()
        {
            _driver.FindElement(checkOutButton).Click();
        }

        public void AddBikeLightItemsToCartList()
        {
            _driver.FindElement(backLightItem).Click();
        }
        public void AddBoltTShirtItemsToCartList()
        {
            _driver.FindElement(boltTShirtItem).Click();
        }
    }
}
 