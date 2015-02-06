using System;
using System.Net;
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

        public ConfigureSignioClient(string content, Guid userId)
        {
            Operation = string.Format("{0}/{1}", Credentials.DecryptyDriversLicenseApiOperation(),userId);
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

        //public async Task RunAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(_url);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        //        client.DefaultRequestHeaders.Authorization = AutorizationHelper.CreateBasicHeader(_username, _password);
        //        client.DefaultRequestHeaders.Add("X-Auth-Token", _xAuthToken);

        //        var request = new HttpRequestMessage(HttpMethod.Post, _operation);
        //        request.Content = _stringContent;
        //        var response = await client.SendAsync(request);
        //        IsSuccessful = response.IsSuccessStatusCode;

        //        Resonse = await response.Content.ReadAsStringAsync();
        //    }
        //}
    }
}
