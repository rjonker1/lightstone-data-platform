using System.Net;
using RestSharp;

namespace Cradle.KeepAlive.Service.Helpers
{
    public class Login
    {
        public string GetToken()
        {
            // RestSharp
            var client = new RestClient("http://dev.api.lightstone.co.za");
            var request = new RestRequest("/login", Method.POST);
            request.AddHeader("Username", "murrayw@lightstone.co.za");
            request.AddHeader("Password", "123456");

            // execute the request
            var response = client.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;

            return statusCode == HttpStatusCode.OK ? response.Content : null;
        }
    }
}