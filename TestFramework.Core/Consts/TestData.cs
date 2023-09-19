using TestFramework.Models;

namespace TestFramework.Core.Consts
{
    public static class TestData
    {
        public static string DownloadDirectory = "DownloadTemp";
        
        public static UserModel VaildUser = new UserModel
        {
            Username = "Admin",
            Password = "admin123",
        };
    }
}
