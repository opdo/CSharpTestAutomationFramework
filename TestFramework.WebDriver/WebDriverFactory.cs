using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TestFramework.Core.Consts;
using TestFramework.WebDriver.Enums;

namespace TestFramework.WebDriver
{
    public class WebDriverFactory
    {
        public static string DownloadFolder = Path.Combine(Directory.GetCurrentDirectory(), TestData.DownloadDirectory);

        public static IWebDriver OpenBrowser(BrowserType type)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    // Define chrome option
                    ChromeOptions options = new ChromeOptions();

                    // Download directory
                    Directory.CreateDirectory(TestData.DownloadDirectory);
                    options.AddUserProfilePreference("download.default_directory", DownloadFolder);
                    options.AddUserProfilePreference("disable-popup-blocking", "true");
                    options.AddUserProfilePreference("safebrowsing.enabled", "true");

                    driver = new ChromeDriver(@"WebDrivers\Chrome", options);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.Edge:
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException("Can not find driver");
            }

            return driver;
        }
    }
}
