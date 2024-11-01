using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace SauceDemoTestAutomation.SetUp
{
    public class Context
    { 
        private IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private string baseUrl = "https://www.saucedemo.com/v1/index.html";

        public Context(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);

        }

        public void LoadSauceDemoApplication()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _driver.Navigate().GoToUrl(baseUrl);
            _driver.Manage().Window.Maximize();
        }
        
        public void ShutDownSauceDemoApplication()
        {
           _driver.Close();
           _driver.Dispose();
        } 
    }
}
