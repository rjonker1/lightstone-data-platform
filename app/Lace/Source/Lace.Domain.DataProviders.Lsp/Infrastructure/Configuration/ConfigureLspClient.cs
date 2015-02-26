using System;
using System.Net;
using Lace.Domain.DataProviders.Core.Shared;

namespace Lace.Domain.DataProviders.Lsp.Infrastructure.Configuration
{

    public class ConfigureLspClient
    {
        public readonly string Url = Credentials.DecryptyDriversLicenseApiUrl();
        public readonly string Operation;
        public readonly string Username = Credentials.DecryptyLspServiceFuncUsername();
        public readonly string Password = Credentials.DecryptyLspServicePassword();
        public readonly string XAuthToken = Credentials.DecryptyDriversLicenseoApiXAuthToken();
        public readonly string Content;

        public bool IsSuccessful { get; private set; }
        public string Resonse { get; private set; }

        public ConfigureLspClient(string content, Guid userId)
        {
            Operation = string.Format("{0}/{1}", Credentials.DecryptyLspServiceOperation(), userId);
            Content = content;
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
