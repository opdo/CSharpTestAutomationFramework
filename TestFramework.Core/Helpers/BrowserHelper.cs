namespace TestFramework.Core.Helpers
{
    public class BrowserHelper
    {
        public static void DeleteDownloadFile(string folderPath, string filePattern)
        {
            var files = Directory.GetFiles(folderPath, filePattern);
            foreach (var file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                    // Ignore error if can not delete file
                    // We dont care if a file is deleted successfully or not
                }
            }
        }

        public static List<string> GetDownloadFiles(string folderPath, string filePattern)
        {
            return Directory.GetFiles(folderPath, filePattern).ToList();
        }
    }
}
