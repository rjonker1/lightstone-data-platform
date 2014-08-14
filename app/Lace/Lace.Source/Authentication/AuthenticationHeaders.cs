using System;
using System.Net;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;
using System.Text;

namespace Lace.Source.Authentication
{
    public class AuthenticationHeaders
    {
        public static Func<string, string, AuthenticationHeaderValue> CreateBasicAuthenticationHeaderValue =
            (username, password) =>
            {
                var byteArray = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password));
                return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            };

        public static Func<string, string, string> CreateBasicAuthorizationHeader =
            (username, password) =>
                string.Format("Basic {0}",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));


        public static Func<string, string, HttpRequestMessageProperty> CreateBasicHttpRequestMessageProperty =
            (username, password) =>
            {
                var property = new HttpRequestMessageProperty();
                property.Headers[HttpRequestHeader.Authorization] = CreateBasicAuthorizationHeader(username, password);
                return property;
            };
    }
}
