using OpenQA.Selenium;
using TestFramework.WebDriver.Extensions;

namespace TestFramework.Pages.PIM
{
    public class EmployeeListPage : BasePage
    {
        public EmployeeListPage(IWebDriver driver) : base(driver)
        {
        }

        // XPath
        private IWebElement buttonAdd => driver.GetElement("//button[. = ' Add ']");

        // Method to interact with
        public void ClickAddEmployee()
        {
            buttonAdd.Click();
        }
    }
}
