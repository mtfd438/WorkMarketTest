using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace WorkMarket
{
    public static class Browser
    {

        public static IWebDriver Driver { get; set; }
        public static bool Initialised { get; set; }

        public static IWebElement FindElement(this IWebDriver Driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return Driver.FindElement(by);
        }

        public static void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("disable-infobars");
            options.AddUserProfilePreference("credentials_enable_service", false);
            Driver = new ChromeDriver(options);
            //Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Driver.Manage().Window.Maximize();
            Initialised = true;
        }

        public static void Quit()
        {
            Driver.Quit();
            Driver.Dispose();
            Initialised = false;
        }
    }
}
