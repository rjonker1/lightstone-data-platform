using System.Configuration;
using System.Linq;

namespace Lace.Toolbox.PCubed
{
    public class ConfigurationHelper
    {
        public static TReturnType Read<TReturnType>(string name, bool required, TReturnType defaultValue)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(name))
            {
                if (required)
                    throw new ConfigurationErrorsException(string.Format("Required AppSettings key missing: {0}", name));

                return defaultValue;
            }

            var reader = new AppSettingsReader();
            return (TReturnType)reader.GetValue(name, typeof(TReturnType));
        }
    }

}
