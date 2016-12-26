using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;
using PokuponTestAutomation.Driver;

namespace PokuponTestAutomation.Pages
{
    class SignInPage : BasePage
    {
        private const string BASE_URL = "https://pokupon.by/users/sign_in";

        private const string LOGIN_EMAIL_ERROR_MSG = ".//*[@id='app-sign-in-form']/div[3]/div/div[2]/div";
        private const string MOBILE_XPATH = ".//*[@id='switch_to_mobile']";
        private const string FULL_XPATH = ".//*[@id='switch_to_full']";

        [FindsBy(How = How.Id, Using = "user_email")]
        private IWebElement loginEmail;
        [FindsBy(How = How.Id, Using = "user_password")]
        private IWebElement loginPass;
        [FindsBy(How = How.Id, Using = "app-sign-in-form-submit")]
        private IWebElement signInnButt;

        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void FillLoginEmail(string email)
        {
            loginEmail.SendKeys(email);
        }

        public void FillLoginPass(string pass)
        {
            loginPass.SendKeys(pass);
        }

        public void SignInClick()
        {
            signInnButt.Click();
        }

        public string GetLoginErrorMessage()
        {
            IWebElement emailErr = driver.FindElement(By.XPath(LOGIN_EMAIL_ERROR_MSG));
            return emailErr.Text;
        }

        public void SwitchToMobile()
        {
            IWebElement mobile = driver.FindElementSafe(By.XPath(MOBILE_XPATH));
            if (mobile.Exists())
                mobile.Click();
        }

        public void SwitchToFull()
        {
            IWebElement mobile = driver.FindElement(By.XPath(FULL_XPATH));
            if(mobile.Exists())
                mobile.Click();
        }

        public bool IsMobileVersion()
        {
            IWebElement mobile = driver.FindElementSafe(By.XPath(FULL_XPATH));
            return mobile.Exists();
        }

        public void ScrollToBottom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
        }
    }
}
