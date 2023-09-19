using System.Diagnostics;

namespace TestFramework.Core.Helpers
{
    public static class WaitHelper
    {
        public static bool WaitFor(Func<bool> condition, int timeout = 60, int delay = 3)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.Elapsed.TotalSeconds < timeout)
            {
                try
                {
                    if (condition())
                    {
                        return true;
                    }
                }
                catch
                {
                    // Ignore any exception
                }

                Thread.Sleep(delay);
            }

            return false;
        }
    }
}
