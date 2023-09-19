using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFramework.Core.Interfaces
{
    public interface IReport
    {
        public void Create(string fileName);
        public void Export();
        public void CreateTestName(string name);
        public void LogMessage(string message);
        public void AddResult(UnitTestOutcome result);
        public void AddImage(string base64String);
    }
}
