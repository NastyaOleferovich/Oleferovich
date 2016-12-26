using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PokuponTestAutomation.Pages
{
    class ProfilePage : BasePage
    {
        private const string BASE_URL = "https://pokupon.by/users/profile";
        private const string SURRNAME_XPATH = ".//*[@id='b-page']/div/div[2]/div[2]/div[1]/div[1]/table/tbody/tr[3]/td[2]/div";
        private const string EDITBUTT_XPATH = ".//*[@id='b-page']/div/div[2]/div[2]/div[1]/a";
        private const string EDIT_SURNAME = "user_last_name";
        private const string EDIT_CURR_PASS = "user_current_password";
        private const string EDIT_NEW_PASS = "user_password";
        private const string EDIT_CONFIRM_NEW_PASS = "user_password_confirmation";
        private const string SAVE_CHANGES = "app-edit-profile-submit";
        private const string CURR_PASS_ERR = ".//*[@id='edit_user']/div[2]/table/tbody/tr[7]/td[2]/div/dl/dd[1]/p";


        public ProfilePage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string GetSurname()
        {
            IWebElement surname = driver.FindElement(By.XPath(SURRNAME_XPATH));
            return surname.Text;
        }

        public void EditProfileClick()
        {
            IWebElement edt = driver.FindElement(By.XPath(EDITBUTT_XPATH));
            edt.Click();
        }

        public void EnterNewSurname(string surname)
        {
            IWebElement edt = driver.FindElement(By.Id(EDIT_SURNAME));
            edt.SendKeys(surname);
        }

        public void EnterOldPass(string pass)
        {
            IWebElement pswd = driver.FindElement(By.Id(EDIT_CURR_PASS));
            pswd.SendKeys(pass);
        }

        public void EnterNewPass(string pass)
        {
            IWebElement pswd = driver.FindElement(By.Id(EDIT_NEW_PASS));
            pswd.SendKeys(pass);
        }

        public void EnterConfirmNewPass(string pass)
        {
            IWebElement pswd = driver.FindElement(By.Id(EDIT_CONFIRM_NEW_PASS));
            pswd.SendKeys(pass);
        }

        public void SaveChangesClick()
        {
            IWebElement save = driver.FindElement(By.Id(SAVE_CHANGES));
            save.Click();
        }

        public string GetCurrentPassErr()
        {
            IWebElement currerr = driver.FindElement(By.Id(CURR_PASS_ERR));
            return currerr.Text;
        }
    }
}
