using System.Configuration;

namespace TestFramework.Core.Helpers
{
    public static class ConfiguationHelper
    {
        public static T GetValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value is null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
