using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WorkMarket.PageObjects
{
    public class RegistrationPage
    {
        WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(30));

        public IWebElement IndividualRegButton
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Join as an individual']"))); }
        }

        public IWebElement FirstName
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("firstname"))); }
        }

        public IWebElement LastName
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("lastname"))); }
        }

        public IWebElement eMailAddress
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email"))); }
        }

        public IWebElement Password
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("password"))); }
        }

        public IWebElement touCheckBox
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@value = 'on']"))); }
        }

        public IWebElement RegisterButton
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[@data-component-identifier = 'wm-validating-form__submit']"))); }
        }

        public bool RegisterButtonIsEndabled()
        {
            // return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button/div/span[text() = 'Register']"))).Enabled;
           return Browser.Driver.FindElement(By.XPath("//button[@data-component-identifier = 'wm-validating-form__submit']")).Enabled; 
        }

        public IWebElement TOUlink
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@title = 'Terms of Use Agreement']"))); }
        }

        public IWebElement PrivacyStatmentlink
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@title = 'Privacy Statement']"))); }
        }

    }
} 
