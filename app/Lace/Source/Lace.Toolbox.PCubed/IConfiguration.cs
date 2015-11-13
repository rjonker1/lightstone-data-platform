using RestSharp;

namespace Lace.Toolbox.PCubed
{
    public interface IConfiguration
    {
        string BaseUrl { get; }
        IAuthenticator Authenticator { get; }
    }

    public class ConfigurationProvider : IConfiguration
    {
        public IAuthenticator Authenticator
        {
            get
            {
                if (string.IsNullOrEmpty(UserName) &&
                    string.IsNullOrEmpty(Password))
                    return null;

                return new HttpBasicAuthenticator(UserName, Password);
            }
        }

        public string BaseUrl
        {
            get { return ConfigurationHelper.Read<string>("pcubed/ezscore/url", true, null); }
        }

        protected virtual string UserName
        {
            get { return ConfigurationHelper.Read<string>("pcubed/ezscore/username", false, null); }
        }

        protected virtual string Password
        {
            get { return ConfigurationHelper.Read<string>("pcubed/ezscore/password", false, null); }
        }

        public static readonly string ConsumerViewApiUrl = ConfigurationHelper.Read<string>("pcubed/ezscore/url", true, null);
    }
}
