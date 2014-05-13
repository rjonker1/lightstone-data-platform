using Lace.Source.Audatex.AudatexServiceReference;

namespace Lace.Source.Audatex.ServiceConfig
{
    public class ConfigureAudatexCredentials
    {
        public CredentialsInfo Credentials
        {
            get
            {
                return new CredentialsInfo()
                {
                    CompanyCode = _companyCode,
                    Password = _password,
                    UserId = _userId
                };
            }
        }

        private readonly string _companyCode = Configuration.AppSettings.DefaultAppSettingConfiguration.GetSetting("AudatexCompanyCode");
        private readonly string _userId = Configuration.AppSettings.DefaultAppSettingConfiguration.GetSetting("AudatexUserId");
        private readonly string _password = Configuration.AppSettings.DefaultAppSettingConfiguration.GetSetting("AudatexPassword");
    }
}
