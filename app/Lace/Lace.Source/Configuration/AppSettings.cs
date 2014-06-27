namespace Lace.Source.Configuration
{
    internal class AppSettings : IConfiguration
    {
        private static readonly IConfiguration AppSettingConfiguration = new AppSettings();

        public static IConfiguration DefaultAppSettingConfiguration
        {
            get
            {
                return AppSettingConfiguration;
            }
        }

        public string GetSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
