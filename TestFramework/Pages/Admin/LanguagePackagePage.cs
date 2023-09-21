using OpenQA.Selenium;
using TestFramework.WebDriver.Extensions;

namespace TestFramework.Pages.Admin
{
    public class LanguagePackagePage : BasePage
    {
        public LanguagePackagePage(IWebDriver driver) : base(driver)
        {
        }

        // Element
        private IWebElement buttonExport(string name) => driver.GetElement($"//div[@class = 'oxd-table-card' and .//div[text() = '{name}']]//button[contains(., 'Export')]");
    
        public void ClickExport(string languageName)
        {
            buttonExport(languageName).Click();
        }
    }
}
