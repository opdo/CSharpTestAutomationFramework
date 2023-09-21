using TestFramework.Consts;
using TestFramework.Core.Consts;
using TestFramework.Core.Helpers;
using TestFramework.Pages;
using TestFramework.Tests;
using TestFramework.WebDriver.Extensions;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    public class CustomTestMethodAttribute : TestMethodAttribute
    {
        public bool RequiredLogin = false;
        public string RedirectToPage = string.Empty;

        public CustomTestMethodAttribute(string displayName) : base(displayName)
        {
        }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            BaseTest.Report.CreateTestName(testMethod.TestMethodName);

            if (RequiredLogin && BaseTest.Driver.Url.Contains(PageData.Login))
            {
                Login();
            }

            if (!string.IsNullOrEmpty(RedirectToPage))
            {
                BaseTest.Driver.Go(ConfiguationHelper.GetValue<string>("url") + RedirectToPage);
                BaseTest.Report.LogMessage($"Redirect to page: {RedirectToPage}");
            }

            return base.Execute(testMethod);
        }

        private void Login()
        {
            LoginPage loginPage = new (BaseTest.Driver);
            loginPage.InputAccount(TestData.VaildUser);
            loginPage.ClickLogin();
            BaseTest.Report.LogMessage($"Login with username: {TestData.VaildUser.Username}");
        }
    }
}
