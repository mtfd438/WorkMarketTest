using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WorkMarket.PageObjects
{
   public class FindTalentPage
    {
        WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(30));

        public IWebElement SearchTextInput
        {
            get { return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("input-text"))); }
        }
    }
}
