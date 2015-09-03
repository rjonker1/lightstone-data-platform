using RestSharp;

namespace Lace.Toolbox.Signio
{
    public interface IConfiguration
    {
        string BaseUrl { get; }
        string Suffix { get; }
        //string Username { get; }
        //string Password { get; }
        string Token { get; }
        string Key { get; }
        IAuthenticator Authenticator { get; }
    }

    public class Configuration : IConfiguration
    {
        public string BaseUrl
        {
            get { return ConfigurationReader.ReadAppSetting("drivers/license/decryption/url"); }
        }

        public string Suffix
        {
            get { return ConfigurationReader.ReadAppSetting("drivers/license/decryption/suffix"); }
        }

        public IAuthenticator Authenticator
        {
            get
            {
                return new HttpBasicAuthenticator(ConfigurationReader.ReadAppSetting("drivers/license/decryption/username"), ConfigurationReader.ReadAppSetting("drivers/license/decryption/password"));
            }
        }

        public string Token
        {
            get { return ConfigurationReader.ReadAppSetting("drivers/license/decryption/token"); }

        }

        public string Key
        {
            get { return ConfigurationReader.ReadAppSetting("drivers/license/decryption/key"); }
        }
    }

}
