using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
namespace WorkMarket.PageObjects
{
   public class LoginPage
    {

        WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(30));

        public IWebElement eMailAddress
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-email"))); }
        }

        public IWebElement Password
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-password"))); }
        }

        public IWebElement LoginButton
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login_page_button"))); }
        }
    }
}
