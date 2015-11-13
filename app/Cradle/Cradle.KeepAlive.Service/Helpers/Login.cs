using System.Configuration;
using System.Net;
using DataPlatform.Shared.ExceptionHandling;
using RestSharp;

namespace Cradle.KeepAlive.Service.Helpers
{
    public class Login
    {
        public string GetToken()
        {
            var client = new RestClient("http://" + ConfigurationManager.AppSettings["endpoint/url/api"]);
            var request = new RestRequest("/login", Method.POST);
            request.AddHeader("Username", ConfigurationManager.AppSettings["systemLoginUser"]);
            request.AddHeader("Password", ConfigurationManager.AppSettings["systemLoginPassword"]);

            var response = client.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;

            return statusCode == HttpStatusCode.OK ? response.Content : null;
        }

        public string GetMobileMenu()
        {
            var client = new RestClient("http://" + ConfigurationManager.AppSettings["endpoint/url/api"]);
            var request = new RestRequest("/login/mobi", Method.POST);
            request.AddHeader("Username", ConfigurationManager.AppSettings["systemLoginUser"]);
            request.AddHeader("Password", ConfigurationManager.AppSettings["systemLoginPassword"]);

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) throw new LightstoneAutoException("Mobile API Error");

            return response.Content;
        }
    }
}