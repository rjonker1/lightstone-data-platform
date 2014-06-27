using System;

namespace Lace.Source.Configuration
{
    public class Credentials
    {
        public static Func<string> AudatexCompanyCode = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("AudatexCompanyCode");
        public static Func<string> AudatexUserId = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("AudatexUserId");
        public static Func<string> AudatexPassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("AudatexPassword");

        public static Func<string> IvidServiceUsername = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("IvidServiceUserName");
        public static Func<string> IvidServiceUserPassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("IvidServiceUserPassword");

        public static Func<string> IvidTitleHolderServiceUserName = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("IvidTitleHolderServiceUserName");
        public static Func<string> IvidTitleHolderServiceUserPassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("IvidTitleHolderServiceUserPassword");
    }
}
