using TechTalk.SpecFlow;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WorkMarket.Steps
{
    [Binding]
    public class QATestsSteps
    {
        [AfterScenario]
        public void AfterScenario()
        {
            Browser.Quit();
        }

        [Given(@"User is on registration page")]
        public void GivenUserIsOnRegistrationPage()
        {
            if (!Browser.Initialised) Browser.Initialize();
            string RegUrl = ConfigurationManager.AppSettings["RegEnv"].ToString();
            Browser.Driver.Navigate().GoToUrl(RegUrl);
        }

        [Given(@"User registers as an individual account ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void GivenUserRegistersAsAnIndividualAccount(string fName, string lName, string email, string pw)
        {
            Random random = new Random();
            int randomNumber = random.Next();
            string numText = randomNumber.ToString();
     
            if (email == "test")
            {            
                email = email + "" + numText + "@fakemail.com";
            }
            var regPage = new PageObjects.RegistrationPage();
            regPage.IndividualRegButton.Click();
            regPage.FirstName.SendKeys(fName);
            regPage.LastName.SendKeys(lName);
            regPage.eMailAddress.SendKeys(email);
            regPage.Password.SendKeys(pw);
            regPage.touCheckBox.Click();
            regPage.RegisterButton.Click();
        }

        [Given(@"User tried to submit an incomplete registraction form")]
        public void GivenUserTriedToSubmitAnIncompleteRegistractionForm()
        {
            var regPage = new PageObjects.RegistrationPage();
            regPage.IndividualRegButton.Click();
            regPage.FirstName.SendKeys("John");
            regPage.LastName.SendKeys("Doe");
            regPage.Password.SendKeys("adfadfadfa");
            regPage.touCheckBox.Click();

        }


        [Then(@"The Register button is dissabled")]
        public void ThenTheRegisterButtonIsDissabled()
        {
            var regPage = new PageObjects.RegistrationPage();
            bool endabled = regPage.RegisterButtonIsEndabled();
            endabled.ShouldBeEquivalentTo(false);
        }

        [Then(@"""(.*)"" should be displayed to the user")]
        public void ThenShouldBeDisplayedToTheUser(string msg)
        {
            Thread.Sleep(3000);
            bool verifyReg = Browser.Driver.FindElement(By.XPath("//body[contains(text(), msg)]")).Displayed;
            verifyReg.ShouldBeEquivalentTo(true);   
        }

        [Given(@"User clicks the Terms of Use Agreement")]
        public void GivenUserClicksTheTermsOfUseAgreement()
        {
            var regPage = new PageObjects.RegistrationPage();
            regPage.IndividualRegButton.Click();
            regPage.TOUlink.Click();
        }

        [Given(@"User clicks the Privacy Statement")]
        public void GivenUserClicksThePrivacyStatement()
        {
            var regPage = new PageObjects.RegistrationPage();
            regPage.IndividualRegButton.Click();
            regPage.PrivacyStatmentlink.Click();
        }

        [Given(@"User is logged in")]
        public void GivenUserIsLoggedIn()
        {                     
            string loginUrl = ConfigurationManager.AppSettings["loginURL"].ToString();
            string id = ConfigurationManager.AppSettings["UserID"].ToString();
            string pw = ConfigurationManager.AppSettings["Password"].ToString();

            if (!Browser.Initialised) Browser.Initialize();
            Browser.Driver.Navigate().GoToUrl(loginUrl);

            var loginPage = new PageObjects.LoginPage();
            loginPage.eMailAddress.SendKeys(id);
            loginPage.Password.SendKeys(pw);
            loginPage.LoginButton.Click();
        }

        [Given(@"User Searches for ""(.*)"" on the Find Talent Page")]
        public void GivenUserSearchesForOnTheFindTalentPage(string searchText)
        {
            var findTalPage = new PageObjects.FindTalentPage();
            Thread.Sleep(3000);
            Browser.Driver.FindElement(By.XPath("//*/div[text() = 'Find Talent']")).Click();
            Thread.Sleep(3000);
            findTalPage.SearchTextInput.SendKeys(searchText);
            findTalPage.SearchTextInput.SendKeys(Keys.Return);
        }

        [Then(@"Each returned search result should contain the search phrase ""(.*)""")]
        public void ThenEachReturnedSearchResultShouldContainTheSearchPhrase(string text)
        {
            Thread.Sleep(3000);     
            foreach (var item in Browser.Driver.FindElements(By.XPath("//a[@class = 'profile-card--name open-user-profile-popup']")))
            {
                string searchText = text.ToLower();
                string profileResult = item.Text.ToLower();
                profileResult.Should().Contain(searchText);
            }
        }

        [Then(@"User is redirected to ""(.*)"" page")]
        public void ThenUserIsRedirectedToPage(string title)
        {
            Thread.Sleep(3000);
            string pageTitle = Browser.Driver.Title;
            pageTitle.Should().BeEquivalentTo(title);
        }

        [Then(@"User is redirected to new ""(.*)"" tab")]
        public void ThenUserIsRedirectedToNewTab(string title)
        {
            Thread.Sleep(3000);
            Browser.Driver.SwitchTo().Window(Browser.Driver.WindowHandles.Last());
            string pageTitle = Browser.Driver.Title;
            pageTitle.Should().BeEquivalentTo(title);
        }


        private static void WaitForAjax()
        {
            Thread.Sleep(3000);
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(90));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        }



    }
}
