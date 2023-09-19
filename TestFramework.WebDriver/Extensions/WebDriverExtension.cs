using OpenQA.Selenium;

namespace TestFramework.WebDriver.Extensions
{
    public static class WebDriverExtension
    {
        public static IWebElement GetElement(this IWebDriver driver, string xpath)
        {
            return GetElement(driver, By.XPath(xpath));
        }

        public static IWebElement GetElement(this IWebDriver driver, By xpath)
        {
            return driver.FindElement(xpath);
        }

        public static bool IsElementDisplay(this IWebDriver driver, By xpath)
        {
            var timeSpan = driver.Manage().Timeouts().ImplicitWait;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            try
            {
                return driver.FindElement(xpath).Displayed;
            }
            catch
            {
                return false;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = timeSpan;
            }
        }

        public static void Maximize(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void Go(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void SetImplicitWait(this IWebDriver driver, int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        public static string TakeBase64String(this IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            return ss.AsBase64EncodedString;
        }
    }
}
