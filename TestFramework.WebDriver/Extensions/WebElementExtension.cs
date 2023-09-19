using OpenQA.Selenium;

namespace TestFramework.WebDriver.Extensions
{
    public static class WebElementExtension
    {
        public static void SendKey(this IWebElement element, string keyword)
        {
            element.Clear();
            element.SendKeys(keyword);
        }
    }
}
