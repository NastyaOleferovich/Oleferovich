using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PokuponTestAutomation.Pages
{
    class SearchResultsPage : BasePage
    {
        private const string RESULT_LINK_XPATH = ".//*[@id='b-page']/div/div[4]/div[2]/div[1]/div/header/div/div/div/a";
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToResult()
        {
            IWebElement link = driver.FindElement(By.XPath(RESULT_LINK_XPATH));
            link.Click();
        }

    }
}
