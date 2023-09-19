using OpenQA.Selenium;
using TestFramework.Consts;
using TestFramework.Core.Consts;
using TestFramework.Pages;

namespace TestFramework.Tests.Login
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        readonly LoginPage loginPage;

        public LoginTest()
        {
            loginPage = new (Driver);
        }

        [TestMethod("TC01: Login with vaild user")]
        public void LoginWithVaildUser()
        {
            loginPage.InputAccount(TestData.VaildUser);
            Report.LogMessage($"Login with username {TestData.VaildUser.Username}");

            loginPage.ClickLogin();
        }
    }
}