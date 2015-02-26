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

        public static Func<string> DecryptyDriversLicenseApiUsername = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyDriversLicenseApiUsername");
        public static Func<string> DecryptyDriversLicenseApiPassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyDriversLicenseApiPassword");
        public static Func<string> DecryptyDriversLicenseoApiXAuthToken = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyDriversLicenseoApiXAuthToken");
        public static Func<string> DecryptyDriversLicenseApiOperation = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyDriversLicenseApiOperation");
        public static Func<string> DecryptyDriversLicenseApiUrl = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyDriversLicenseApiUrl");


        public static Func<string> DecryptyLspServiceFuncUsername = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyLspServiceFuncUsername");
        public static Func<string> DecryptyLspServicePassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptySlpServicePassword");
        public static Func<string> DecryptyLspServiceOperation = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyLspServiceOperation");

    }
}
