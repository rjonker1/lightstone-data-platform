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


        //public static Func<string> DecryptyLightstonePropertyUsername = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyLspServiceFuncUsername");
        //public static Func<string> DecryptyLightstonePropertyPassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptySlpServicePassword");
        //public static Func<string> DecryptyLightstonePropertyOperation = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("DecryptyLspServiceOperation");

        //// Lightstone Property Web Service
        //public static Func<string> LightstonePropertyWsUrl = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("LspWsUrl");
        //public static Func<string> LightstonePropertyOperation = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("ReturnPropertiesOperation");
        //public static Func<string> LightstonePropertyWsUsername = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("LspWsUsername");
        //public static Func<string> LightstonePropertyWsPassword = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("LspWPassword");
        //public static Func<string> LightstonePropertyWsUserId = () => AppSettings.DefaultAppSettingConfiguration.GetSetting("LspWsUser_ID");


    }
}
