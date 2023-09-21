using OpenQA.Selenium;
using TestFramework.Core.Helpers;
using TestFramework.WebDriver.Extensions;

namespace TestFramework.Pages.Admin
{
    public class UserManagementPage : BasePage
    {
        public UserManagementPage(IWebDriver driver) : base(driver)
        {
        }

        // XPath and Element
        private IWebElement inputSearchUsername => driver.GetElement("//div[./label[text() = 'Username']]/following-sibling::div/input");
        private IWebElement buttonSearch => driver.GetElement("//button[@type = 'submit']");
        private By xpathResultValue = By.XPath("//div[contains(@class, 'orangehrm-horizontal-padding')]/span");
        private IWebElement selectUserRole => driver.GetElement("//div[./label[text() = 'User Role']]/following-sibling::div//div[contains(@class, 'oxd-select-wrapper')]");


        // Method to interact with web UI
        public void InputUsername(string username)
        {
            inputSearchUsername.SendKey(username);
        }

        /// <summary>
        /// Search by username and return total result
        /// Return value >= 0: no error
        /// Return value = -1: error
        /// </summary>
        /// <param name="username"></param>
        public int SearchByUsername(string username)
        {
            InputUsername(username);
            buttonSearch.Click();

            if (WaitHelper.WaitFor(() => driver.IsElementDisplay(xpathResultValue), 15))
            {
                var elementText = driver.GetElement(xpathResultValue).Text;
                var splitString = elementText.Split('(', ')');
                if (splitString.Length > 1)
                {
                    return int.Parse(splitString[1]);
                }

                // Not found
                return 0;
            }

            // Error
            return -1;
        }

        public void SelectUserRole(string role)
        {
            selectUserRole.Click();
            selectUserRole.FindElement(By.XPath($".//div/span[text() = '{role}']")).Click();
        }
    }
}
