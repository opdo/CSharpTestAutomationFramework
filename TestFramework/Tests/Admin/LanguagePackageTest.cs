using FluentAssertions;
using TestFramework.Consts;
using TestFramework.Core.Helpers;
using TestFramework.Pages.Admin;
using TestFramework.WebDriver;

namespace TestFramework.Tests.Admin
{
    [TestClass]
    public class LanguagePackageTest : BaseTest
    {
        private LanguagePackagePage languagePackagePage;

        public LanguagePackageTest()
        {
            languagePackagePage = new LanguagePackagePage(Driver);
        }

        [CustomTestMethod("TC03: Verify download English package successfully",
            RequiredLogin = true,
            RedirectToPage = PageData.LanguagePackage)]
        public void VerifyDownloadEnglishPackage()
        {
            var language = "English (United States)";
            languagePackagePage.ClickExport(language);
            Report.LogMessage($"Download xml for language: {language}");

            // Define file pattern and try to wait get downloaded file
            string filePattern = "i18n-*.xml";
            string downloadedFilePath = string.Empty;

            // Wait download file
            BrowserHelper.DeleteDownloadFile(WebDriverFactory.DownloadFolder, filePattern);
            WaitHelper.WaitFor(() =>
            {
                downloadedFilePath = BrowserHelper.GetDownloadFiles(WebDriverFactory.DownloadFolder, filePattern)?.FirstOrDefault() ?? string.Empty;
                return !string.IsNullOrEmpty(downloadedFilePath);
            }).Should().BeTrue("Download xml file failed");

            Report.LogMessage($"File was downloaded successfully, file path: {downloadedFilePath}");
        }
    }
}
