using OpenQA.Selenium;
using TestFramework.Core.Helpers;
using TestFramework.Core.Helpers.Report;
using TestFramework.Core.Interfaces;
using TestFramework.WebDriver;
using TestFramework.WebDriver.Enums;
using TestFramework.WebDriver.Extensions;

namespace TestFramework.Tests
{
    [TestClass]
    public class BaseTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static IWebDriver Driver { get; set; }
        public static IReport Report { get; set; }
        public TestContext TestContext { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext testContext)
        {
            InitBrower();
            InitReport(testContext);
        }

        private static void InitReport(TestContext testContext)
        {
            Report = new ExtentReportHelper(testContext, $"Report_{DateTime.Now.ToFileTimeUtc()}.html");
        }

        private static void InitBrower()
        {
            // Open browser
            var browserText = ConfiguationHelper.GetValue<string>("browser");
            Enum.TryParse(browserText, out BrowserType type);
            Driver = WebDriverFactory.OpenBrowser(type);

            // Set maximinize window
            Driver.Maximize();

            // Setting implicit wait
            var timeout = ConfiguationHelper.GetValue<int>("timeout");
            Driver.SetImplicitWait(timeout);

            // Go to test web page
            var url = ConfiguationHelper.GetValue<string>("url");
            Driver.Go(url);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Report.Export();
            Driver.Dispose();
        }

        /// <summary>
        /// Create test name
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Report.CreateTestName(TestContext.TestName);
            Report.LogMessage($"Perform test method: {TestContext.TestName}");
        }

        /// <summary>
        /// Add test result
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            // Add failed image if test script fail
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                Report.AddImage(Driver.TakeBase64String());
            }

            // Add result
            Report.LogMessage($"Done with result: {TestContext.CurrentTestOutcome}");
            Report.AddResult(TestContext.CurrentTestOutcome);
        }
    }
}
