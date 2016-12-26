using NUnit.Framework;
using PokuponTestAutomation.Steps;

namespace PokuponTestAutomation
{
    class PokuponTests
    {
        private const string EMAIL = "bstutestemail@mail.ru";
        private const string WRONG_EMAIL = "Bbssttuutteesstteemmaaiill@mail.ru";
        private const string PASS = "12345qazWSX";
        private const string WRONG_PASS = "1_2_3_4_5_q_a_z_W_S_X";
        private const string USER_NAME = "Fit";
        private const string WRONG_LOGIN_PASS_ERR_MSG = "Вы указали неверный e-mail или пароль";
        private const string LOGIN_REGISTER_TEXT = "Регистрация / Вход";
        private const string BALANCE = "0.00 руб.";
        private const string BONUS = "0.00 бон.";
        private const string QUERY = "Маникюр";
        private const string NEW_SURNNAME = "NewTester";
        private const string NEW_PASS = "12345QAZWSX";
        private const string SURNAME = "Tester";
        private const string WRONG_CURR_PASS_ERR = "Вы ввели неправильный пароль";

        private TestSteps steps = new TestSteps();

        [SetUp]
        public void Init()
        {
            steps.StartBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void Login()
        {
            steps.Login(EMAIL, PASS);
            Assert.True(steps.GetUserName().Contains(USER_NAME));
        }

        [Test]
        public void LoginWithWrongEmail()
        {
            steps.Login(WRONG_EMAIL, PASS);
            Assert.True(steps.GetLoginErrorMsg().Contains(WRONG_LOGIN_PASS_ERR_MSG));
        }

        [Test]
        public void LoginWithWrongPass()
        {
            steps.Login(EMAIL, WRONG_PASS);
            Assert.True(steps.GetLoginErrorMsg().Contains(WRONG_LOGIN_PASS_ERR_MSG));
        }

        [Test]
        public void LoginWithEmptyLoginAndPass()
        {
            steps.Login("", "");
            Assert.True(steps.GetLoginErrorMsg().Contains(WRONG_LOGIN_PASS_ERR_MSG));
        }

        [Test]
        public void Logout()
        {
            steps.Logout();
            Assert.True(steps.GetUserName().Contains(LOGIN_REGISTER_TEXT));
        }

        [Test]
        public void CheckBalance()
        {
            steps.Login(EMAIL, PASS);
            Assert.True(steps.GetBalance().Contains(BALANCE));
        }

        [Test]
        public void CheckBonus()
        {
            steps.Login(EMAIL, PASS);
            Assert.True(steps.GetBonus().Contains(BONUS));
        }

        [Test]
        public void SwitchFromFullToMobile()
        {
            steps.SwitchToMobile();
            Assert.True(steps.IsMobileVersion());
        }

        [Test]
        public void SwitchFromMobileToFull()
        {
            steps.SwitchToMobile();
            steps.SwitchToFull();
            Assert.False(steps.IsMobileVersion());
        }

        [Test]
        public void AddToFavorites()
        {
            steps.Login(EMAIL, PASS);
            steps.Search(QUERY);
            steps.GoToResult();
            string addTitle = steps.AddToFavorites();
            Assert.True(steps.CheckInFavorites(addTitle));
            steps.RemoveFromFavorites(addTitle);
        }

        [Test]
        public void RemoveFromFavorites()
        {
            steps.Login(EMAIL, PASS);
            steps.Search(QUERY);
            steps.GoToResult();
            string addTitle = steps.AddToFavorites();
            steps.RemoveFromFavorites(addTitle);
            Assert.False(steps.CheckInFavorites(addTitle));
        }

        [Test]
        public void ChangeSurname()
        {
            steps.Login(EMAIL, PASS);
            string currsurname = steps.GetSurname();
            steps.ChangeSurname(NEW_SURNNAME);
            Assert.True(steps.GetSurname().Equals(NEW_SURNNAME));
            steps.ChangeSurname(currsurname);
        }

        [Test]
        public void ChangePass()
        {
            steps.Login(EMAIL, PASS);
            steps.ChangePass(PASS, NEW_PASS, NEW_PASS);
            steps.Logout();
            steps.Login(EMAIL, NEW_PASS);
            Assert.True(steps.GetUserName().Contains(USER_NAME));
            steps.ChangePass(NEW_PASS, PASS, PASS);
        }

        [Test]
        public void ChangePassWithWrongOldPass()
        {
            steps.Login(EMAIL, PASS);
            steps.ChangePass(WRONG_PASS, NEW_PASS, NEW_PASS);
            Assert.True(steps.GetCurrentPassErr().Equals(WRONG_CURR_PASS_ERR));
        }

        [Test]
        public void ChangePassNewEqualsToCurrent()
        {
            steps.Login(EMAIL, PASS);
            steps.ChangePass(PASS, PASS, PASS);
            steps.Logout();
            steps.Login(EMAIL, PASS);
            Assert.True(steps.GetUserName().Contains(USER_NAME));
        }
    }
}
