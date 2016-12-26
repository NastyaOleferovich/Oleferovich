using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace PokuponTestAutomation.Driver
{
    class Browser
    {
        private static IWebDriver chrome;

        public static IWebDriver Chrome
        {
            get
            {
                if (chrome == null)
                {
                    chrome = new ChromeDriver();
                    chrome.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
                    chrome.Manage().Window.Maximize();
                }
                return chrome;
            }
        }

        public static void closeChrome()
        {
            chrome.Quit();
            chrome = null;
        }
    }
}
