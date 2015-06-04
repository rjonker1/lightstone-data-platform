using System;
namespace Lace.Domain.DataProviders.Core.Shared
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

        public static Func<string> DecryptyDriversLicenseApiUsername = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("drivers/license/decryption/username");
        public static Func<string> DecryptyDriversLicenseApiPassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("drivers/license/decryption/password");
        public static Func<string> DecryptyDriversLicenseoApiToken = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("drivers/license/decryption/token");
        public static Func<string> DecryptyDriversLicenseApiSuffix = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("drivers/license/decryption/suffix");
        public static Func<string> DecryptyDriversLicenseApiKey = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("drivers/license/decryption/key");
        public static Func<string> DecryptyDriversLicenseApiUrl = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("drivers/license/decryption/url");


        // Lightstone Business API

        public static Func<string> LightstoneBusinessApiEmail = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("LightstoneBusinessApiEmail");
        public static Func<string> LightstoneBusinessApiPassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("LightstoneBusinessApiPassword");



    }
}
