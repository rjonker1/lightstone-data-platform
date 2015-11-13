using System.Net;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Shared;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Configuration
{
    public sealed class ConfigureSignioClient
    {
        public readonly string Suffix;
        public readonly string Content;

        public bool IsSuccessful { get; private set; }
        public string Resonse { get; private set; }

        public ConfigureSignioClient(IAmSignioDriversLicenseDecryptionRequest request)
        {
            Suffix = string.Format("{0}/{1}", SignioDriversLicenseConfiguration.Suffix, request.UserId);
            Content = request.ScanData.Field;
        }

        public void Run()
        {

            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/xml");
                client.Headers.Add(SignioDriversLicenseConfiguration.Key, SignioDriversLicenseConfiguration.Token);
                client.Headers.Add(HttpRequestHeader.Authorization,
                    AuthenticationHeaders.CreateBasicAuthorizationStringHeader(SignioDriversLicenseConfiguration.Username, SignioDriversLicenseConfiguration.Password));
                client.BaseAddress = SignioDriversLicenseConfiguration.Url;

                var response = client.UploadString(Suffix, Content);
                IsSuccessful = !string.IsNullOrEmpty(response);

                Resonse = response;
            }
        }
    }
}
