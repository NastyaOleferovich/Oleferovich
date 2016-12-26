using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PokuponTestAutomation.Driver;

namespace PokuponTestAutomation.Pages
{
    class MainPage : BasePage
    {
        private const string BASE_URL = "https://pokupon.by/";

        private const string LOGOUT_XPATH = ".//*[@id='b-outer']/div[1]/div/div/div[2]/div/ul/li[1]/ul/li[11]/a";
        private const string BALANCE_XPATH = ".//*[@id='b-outer']/div[1]/div/div/div[2]/div/ul/li[1]/ul/li[1]/a";
        private const string BONUS_XPATH = ".//*[@id='b-outer']/div[1]/div/div/div[2]/div/ul/li[1]/ul/li[2]/a";



        [FindsBy(How = How.XPath, Using = ".//*[@id='b-outer']/div[1]/div/div/div[2]/div/ul/li[1]/a")]
        private IWebElement userMenu;
        [FindsBy(How = How.Id, Using = "q")]
        private IWebElement searchInput;
        [FindsBy(How = How.XPath, Using = ".//*[@id='search-form']/div[3]/input")]
        private IWebElement searchButt;

        public MainPage(IWebDriver driver) : base(driver)
        {
        }
   
        public void Open()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string GetUserName()
        {
            return userMenu.Text;
        }

        public void OpenUserMenu()
        {
            userMenu.Click();
        }

        public void LogOutClick()
        {
            IWebElement logout = driver.FindElement(By.XPath(LOGOUT_XPATH));
            logout.Click();
        }

        public void FillSearchInput(string query)
        {
            searchInput.SendKeys(query);
        }

        public void SearchButtClick()
        {
            searchButt.Click();
        }

        public string GetBalance()
        {
            IWebElement balance = driver.FindElement(By.XPath(BALANCE_XPATH));
            return balance.Text;
        }

        public string GetBonus()
        {
            IWebElement bonus = driver.FindElement(By.XPath(BONUS_XPATH));
            return bonus.Text;
        }
    }
}
