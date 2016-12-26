using OpenQA.Selenium;
using PokuponTestAutomation.Driver;
using PokuponTestAutomation.Pages;


namespace PokuponTestAutomation.Steps
{
    class TestSteps
    {
        IWebDriver driver;
        public void StartBrowser()
        {
            driver = Browser.Chrome;
        }

        public void CloseBrowser()
        {
            Browser.closeChrome();
        }

        public void Login(string email, string pass)
        {
            SignInPage sp = new SignInPage(driver);
            sp.Open();
            sp.FillLoginEmail(email);
            sp.FillLoginPass(pass);
            sp.SignInClick();
        }

        public string GetUserName()
        {
            MainPage mp = new MainPage(driver);
            mp.Open();
            return mp.GetUserName();
        }

        public string GetLoginErrorMsg()
        {
            SignInPage sp = new SignInPage(driver);
            return sp.GetLoginErrorMessage();
        }

        public void Logout()
        {
            MainPage mp = new MainPage(driver);
            mp.Open();
            mp.OpenUserMenu();
            mp.LogOutClick();
        }

        public string GetBalance()
        {
            MainPage mp = new MainPage(driver);
            mp.Open();
            mp.OpenUserMenu();
            return mp.GetBalance();
        }

        public string GetBonus()
        {
            MainPage mp = new MainPage(driver);
            mp.Open();
            mp.OpenUserMenu();
            return mp.GetBonus();
        }

        public void SwitchToMobile()
        {
            SignInPage sp = new SignInPage(driver);
            sp.Open();
            sp.ScrollToBottom();
            sp.SwitchToMobile();
        }

        public void SwitchToFull()
        {
            SignInPage sp = new SignInPage(driver);
            sp.Open();
            sp.ScrollToBottom();
            sp.SwitchToFull();
        }

        public bool IsMobileVersion()
        {
            SignInPage sp = new SignInPage(driver);
            sp.Open();
            sp.ScrollToBottom();
            return sp.IsMobileVersion();
        }

        public void Search(string query)
        {
            MainPage mp = new MainPage(driver);
            mp.Open();
            mp.FillSearchInput(query);
            mp.SearchButtClick();
        }

        public void GoToResult()
        {
            SearchResultsPage sp = new SearchResultsPage(driver);
            sp.GoToResult();
        }

        public string AddToFavorites()
        {
            KuponPage kp = new KuponPage(driver);
            string result = kp.GetTitle();
            kp.AddToFavorites();
            return result;
        }

        public void RemoveFromFavorites(string title)
        {
            FavoritesPage fv = new FavoritesPage(driver);
            fv.Open();
            fv.GoToDescription(title);
            KuponPage kp = new KuponPage(driver);
            kp.RemoveFromFavorites();
        }

        public bool CheckInFavorites(string title)
        {
            FavoritesPage fv = new FavoritesPage(driver);
            fv.Open();
            return fv.IsKuponExists(title);
        }

        public string GetSurname()
        {
            ProfilePage pp = new ProfilePage(driver);
            pp.Open();
            return pp.GetSurname();
        }

        public void ChangeSurname(string surname)
        {
            ProfilePage pp = new ProfilePage(driver);
            pp.Open();
            pp.EnterNewSurname(surname);
            pp.SaveChangesClick();
        }

        public void ChangePass(string oldpass, string newpass, string confirmnewpass)
        {
            ProfilePage pp = new ProfilePage(driver);
            pp.Open();
            pp.EditProfileClick();
            pp.EnterOldPass(oldpass);
            pp.EnterNewPass(newpass);
            pp.EnterConfirmNewPass(confirmnewpass);
            pp.SaveChangesClick();
        }

        public string GetCurrentPassErr()
        {
            ProfilePage pp = new ProfilePage(driver);
            return pp.GetCurrentPassErr();
        }
    }
}
