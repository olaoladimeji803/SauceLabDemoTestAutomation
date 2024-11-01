using OpenQA.Selenium;


namespace SauceDemoTestAutomation.Pages
{
    public class Login
    {
        
        IWebDriver _driver;
        public Login(IWebDriver driver) 
        {
            _driver = driver;
        }

        By userNameField = By.CssSelector("input#user-name.form_input");
        By passwordField = By.CssSelector("#password");
        By loginBtn = By.CssSelector("#login-button");
        By productPageHeader = By.XPath("//div[@class='product_label']");
        By lockedUserErrorMessage = By.XPath("//*[@data-test='error']");
        By userLoginErrorMessage = By.XPath("//*[@data-test='error']");
       
        public void EnterUserName(string userName)
        {
           Thread.Sleep(2000);
           _driver.FindElement(userNameField).SendKeys(userName);
           
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(loginBtn).Click();
        }

        public string GetProductsHeaderText()
        {
           return  _driver.FindElement(productPageHeader).Text;
        }

        public string GetUserLoginErrorMessage()
        {
            return _driver.FindElement(userLoginErrorMessage).Text;
        }
    }
}
