using OpenQA.Selenium;
using TestFramework.Models;
using TestFramework.WebDriver.Extensions;

namespace TestFramework.Pages
{
    public class LoginPage : BasePage
    {
        private IWebElement inputUsername => driver.GetElement("//input[@name = 'username']");
        private IWebElement inputPassword => driver.GetElement("//input[@name = 'password']");
        private IWebElement buttonLogin => driver.GetElement("//button[@type = 'submit']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void InputUsername(string username)
        {
            inputUsername.SendKey(username);
        }

        public void InputPassword(string password)
        {
            inputPassword.SendKey(password);
        }

        public void InputAccount(UserModel user)
        {
            InputUsername(user.Username);
            InputPassword(user.Password);
        }

        public MainPage ClickLogin()
        {
            buttonLogin.Click();
            return new MainPage(driver);
        }
    }
}
