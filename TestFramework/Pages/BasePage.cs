using OpenQA.Selenium;
using System.Diagnostics;

namespace TestFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //public void SendKey(IWebElement element, string key)
        //{
        //    element.Clear();
        //    element.SendKeys(key);
        //    element.SendKeys(Keys.Return);
        //}

        public void PoolingWait()
        {
            int timeout = 10;
            Stopwatch watch = new Stopwatch();
            while (true)
            {
                try
                {
                    // do something

                    // success
                    break;
                }
                catch
                {

                }

                if (watch.ElapsedMilliseconds > timeout * 1000) throw new Exception("TC failed");
            }

        }
    }
}
