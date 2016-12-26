using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PokuponTestAutomation.Driver;

namespace PokuponTestAutomation.Pages
{
    class KuponPage : BasePage
    {
        private const string ADD_TO_FAV_LINK = "favorite-link";
        private const string REMOVE_FROM_FAV = "favorite-link-delete";
        private const string TITLE = "title";

        public KuponPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetTitle()
        {
            IWebElement ttl = driver.FindElement(By.ClassName(TITLE));
            return ttl.Text;
        }

        public void AddToFavorites()
        {
            IWebElement add = driver.FindElementSafe(By.Id(ADD_TO_FAV_LINK));
            if(add.Exists())
            add.Click();
        }

        public void RemoveFromFavorites()
        {
            IWebElement add = driver.FindElementSafe(By.Id(REMOVE_FROM_FAV));
            if (add.Exists())
                add.Click();
        }
    }
}
