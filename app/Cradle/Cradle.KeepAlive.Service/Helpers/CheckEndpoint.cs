using System;
using System.Net;
using RestSharp;

namespace Cradle.KeepAlive.Service.Helpers
{
    public class CheckEndpoint
    {
        public HttpStatusCode Invoke(string token, string root, string path, Method method)
        {
            // RestSharp
            var client = new RestClient("http://" + root);
            var request = new RestRequest(path, method);
            request.AddHeader("Authorization", "Token " + token);

            // execute the request
            var response = client.Execute(request);

            return response.StatusCode;
        }
    }
}