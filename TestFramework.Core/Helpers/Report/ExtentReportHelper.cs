using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework.Core.Interfaces;

namespace TestFramework.Core.Helpers.Report
{
    public class ExtentReportHelper : IReport
    {
        private string reportName;
        private ExtentReports extentReport;
        private ExtentTest extentTest;
        private string reportFolder = "Reports";
        private TestContext testContext;

        public ExtentReportHelper(TestContext testContext, string reportName)
        {
            this.testContext = testContext;
            Create(reportName);
        }

        /// <summary>
        /// Add image result by base64 string
        /// </summary>
        /// <param name="image"></param>
        public void AddImage(string image)
        {
            this.extentTest.AddScreenCaptureFromBase64String(image);
        }

        public void AddResult(UnitTestOutcome result)
        {
            switch (result)
            {
                case UnitTestOutcome.Passed:
                    this.extentTest.Pass("Passed");
                    break;
                case UnitTestOutcome.Failed:
                    this.extentTest.Fail("Failed");
                    break;
                default:
                    this.extentTest.Skip("Skipped");
                    break;
            }

            this.extentTest = null;
        }

        public void Create(string fileName)
        {
            this.extentReport = new ExtentReports();
            this.reportName = fileName;

            Directory.CreateDirectory(reportFolder);
            var htmlReport = new ExtentHtmlReporter($"{reportFolder}/{fileName}.html");
            extentReport.AttachReporter(htmlReport);
        }

        public void CreateTestName(string name)
        {
            // Only create test if extent test is null
            // After add result for test in method AddResult, extentTest will be set to null
            if (this.extentTest is null)
            {
                this.extentTest = extentReport.CreateTest(name);
            }
        }

        public void Export()
        {
            this.extentReport.Flush();
            File.Move($"{reportFolder}/index.html", $"{reportFolder}/{this.reportName}");
        }

        public void LogMessage(string message)
        {
            // If test is exist, we will add log to test
            if (this.extentTest != null)
            {
                this.extentTest.Log(Status.Info, message);
            }

            // Add log to test context to display in azure devops and test explorer tool
            this.testContext.WriteLine(message);
        }
    }
}
