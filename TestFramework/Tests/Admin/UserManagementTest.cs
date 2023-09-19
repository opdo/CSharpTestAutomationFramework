using FluentAssertions;
using TestFramework.Consts;
using TestFramework.Pages.Admin;

namespace TestFramework.Tests.Admin
{
    [TestClass]
    public class UserManagementTest : BaseTest
    {
        readonly UserManagementPage userManagementPage;

        public UserManagementTest()
        {
            userManagementPage = new(Driver);
        }

        [CustomTestMethod("TC02: Verify User Admin is exist or not",
            RequiredLogin = true,
            RedirectToPage = PageData.ViewSystemUsers)]
        public void VerifyAdminUserIsExist()
        {
            var username = "Admin";
            Report.LogMessage($"Search by username: {username}");

            var totalResult = userManagementPage.SearchByUsername(username);
            Report.LogMessage($"Total record found: {totalResult}");

            totalResult.Should().Be(1, "Total record not equal 1");
        }
    }
}
