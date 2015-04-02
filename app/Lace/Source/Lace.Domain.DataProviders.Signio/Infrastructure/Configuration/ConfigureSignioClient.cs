using System;
using System.Net;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Shared;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Configuration
{

    public class ConfigureSignioClient
    {
        public readonly string Url = Credentials.DecryptyDriversLicenseApiUrl();
        public readonly string Operation;
        public readonly string Username = Credentials.DecryptyDriversLicenseApiUsername();
        public readonly string Password = Credentials.DecryptyDriversLicenseApiPassword();
        public readonly string XAuthToken = Credentials.DecryptyDriversLicenseoApiXAuthToken();
        public readonly string Content;

        public bool IsSuccessful { get; private set; }
        public string Resonse { get; private set; }

        public ConfigureSignioClient(IHaveDriversLicenseInformation request)
        {
            Operation = string.Format("{0}/{1}", Credentials.DecryptyDriversLicenseApiOperation(), request.UserId);
            Content = request.ScanData;
        }

        public void Run()
        {

            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/xml");
                client.Headers.Add("X-Auth-Token", XAuthToken);
                client.Headers.Add(HttpRequestHeader.Authorization,
                    AuthenticationHeaders.CreateBasicAuthorizationStringHeader(Username, Password));
                client.BaseAddress = Url;

                var response = client.UploadString(Operation, Content);
                IsSuccessful = !string.IsNullOrEmpty(response);

                Resonse = response;
            }
        }
    }
}
