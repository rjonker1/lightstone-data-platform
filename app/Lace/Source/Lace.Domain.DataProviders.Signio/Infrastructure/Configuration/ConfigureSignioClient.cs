using System.Net;
using Lace.Domain.DataProviders.Core.Shared;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Configuration
{
    public sealed class ConfigureSignioClient
    {
        public readonly string Url = Credentials.DecryptyDriversLicenseApiUrl();
        public readonly string Suffix;
        public readonly string Username = Credentials.DecryptyDriversLicenseApiUsername();
        public readonly string Password = Credentials.DecryptyDriversLicenseApiPassword();
        public readonly string Token = Credentials.DecryptyDriversLicenseoApiToken();
        public readonly string Key = Credentials.DecryptyDriversLicenseApiKey();
        public readonly string Content;

        public bool IsSuccessful { get; private set; }
        public string Resonse { get; private set; }

        public ConfigureSignioClient(IAmSignioDriversLicenseDecryptionRequest request)
        {
            Suffix = string.Format("{0}/{1}", Credentials.DecryptyDriversLicenseApiSuffix(), request.UserId);
            Content = request.ScanData.Field;
        }

        public void Run()
        {

            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/xml");
                client.Headers.Add(Key, Token);
                client.Headers.Add(HttpRequestHeader.Authorization,
                    AuthenticationHeaders.CreateBasicAuthorizationStringHeader(Username, Password));
                client.BaseAddress = Url;

                var response = client.UploadString(Suffix, Content);
                IsSuccessful = !string.IsNullOrEmpty(response);

                Resonse = response;
            }
        }
    }
}
