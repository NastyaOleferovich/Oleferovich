using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PokuponTestAutomation.Driver;

namespace PokuponTestAutomation.Pages
{
    class FavoritesPage : BasePage
    {
        private const string BASE_URL = "https://pokupon.by/favorites";
       

        public FavoritesPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public bool IsKuponExists(string title)
        {
            IWebElement itemLink = driver.FindElementSafe(By.XPath(".//a[text() = '" + title + "']"));
            return itemLink.Exists();
        }

        public void GoToDescription(string title)
        {
            IWebElement itemLink = driver.FindElementSafe(By.XPath(".//a[text() = '" + title + "']/../../../../../div[4]/a"));
            itemLink.Click();
        }
    }
}
