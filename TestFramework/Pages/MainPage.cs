using OpenQA.Selenium;
using TestFramework.WebDriver.Extensions;

namespace TestFramework.Pages
{
    public class MainPage : BasePage
    {
        // Element
        private IWebElement linkLeftMenu(string menuName) => driver.GetElement($"//a[./span[text() = '{menuName}']]");

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToMenu(string menuName)
        {
            linkLeftMenu(menuName).Click();
        }
    }
}
