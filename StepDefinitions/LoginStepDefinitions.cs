using NUnit.Framework;
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
    internal class LoginStepDefinitions
    { 
        Context _context;
        Login _login;
        ScenarioContext _scenarioContext;

        public LoginStepDefinitions(Context context, Login login, ScenarioContext scenarioContext)
    {
        _context = context;
        _login = login;
        _scenarioContext = scenarioContext;
    }
    
        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            _context.LoadSauceDemoApplication();
        }

        [When(@"the user enters a valid username (.*)")]
        public void WhenTheUserEntersAValidUsername(string userName)
        {
          _login.EnterUserName(userName);
        }

        [When(@"the user enters valid password (.*)")]
        public void WhenTheUserEntersValidPassword(string password)
        {
           _login.EnterPassword(password);
        }

        [When(@"clicks the login button")]
        public void WhenClicksTheLoginButton()
        {
            _login.ClickLoginButton();
            
        }

        [Then(@"the user is redirected to the product page, and the (.*) is displayed")]
        public void ThenTheUserIsRedirectedToTheProductPageAndTheProductsIsDisplayed_(string expectedHeader)
        {
            string actualResult = _login.GetProductsHeaderText();
            Assert.That(actualResult.Equals(expectedHeader));
          
        }

        [When(@"the user enters valid (.*) and (.*)")]
        public void WhenTheUserEntersValidStandard_UserAndSecret_Sauce(string userName, string password)
        {
            _login.EnterUserName(userName);
            _login.EnterPassword(password);
        }

        [When(@"the user enters invalid (.*) and (.*)")]
        public void WhenTheUserEntersInvalidLocked_Out_UserAndSecret_Sauce(string userName, string password)
        {
            _login.EnterUserName(userName);
            _login.EnterPassword(password);
        }

        [Then(@"the user is unsuccessful login and the (.*) is displayed")]
        public void ThenTheUserLoginUnsuccessfulAndTheSadfaceSorryThisUserHasBeenLockedOut_IsDisplayed_(string expectedErrorMessage)
        {
            Console.WriteLine(_login.GetUserLoginErrorMessage());

            string actualErrorMessage = string.Empty;

            if (expectedErrorMessage.Equals("Epic sadface: Sorry, this user has been locked out.")) 
            {
                actualErrorMessage = _login.GetUserLoginErrorMessage();
            }
            else if (expectedErrorMessage.Equals("Epic sadface: Username is required"))
            {
                actualErrorMessage = _login.GetUserLoginErrorMessage();
            }
            else if (expectedErrorMessage.Equals("Epic sadface: Password is required"))
            {
                actualErrorMessage = _login.GetUserLoginErrorMessage();
            }
            else if (expectedErrorMessage.Equals("Epic sadface: Username and password do not match any user in this service"))
            {
                actualErrorMessage = _login.GetUserLoginErrorMessage();
            }
            Assert.That(actualErrorMessage.Equals(expectedErrorMessage));
        }

    }
}
