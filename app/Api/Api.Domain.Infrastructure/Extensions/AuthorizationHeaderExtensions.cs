using System;
using System.Text;

namespace Api.Domain.Infrastructure.Extensions
{
    public static class AuthenticationHeaderExtensions
    {
        private static readonly Func<string, string, string> CreateBasicAuthorizationStringHeader =
            (username, password) =>
            {
                var byteArray = Encoding.UTF8.GetBytes(username + ":" + password);
                return string.Format("Basic {0}", Convert.ToBase64String(byteArray));
            };

        private static readonly Func<string, string, string> CreateBasicAuthorizationHeader =
            (username, password) =>
                string.Format("Basic {0}",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));


        public static string EncodeAuthentication(this string[] usernameAndPassword)
        {
            return CreateBasicAuthorizationHeader(usernameAndPassword[0], usernameAndPassword[1]);
        }

        public static string[] DecodeAuthentication(this string encodedAuthentication)
        {
            try
            {
                var decodedAuthentication = Encoding.UTF8.GetString(Convert.FromBase64String(encodedAuthentication));
                var removeBasic = decodedAuthentication.Replace("Basic ", string.Empty);
                var split = removeBasic.Trim().Split(':');
                var username = split[0];
                var password = split[1];
                return new[] { username, password };
            }
            catch
            {
                return null;
            }
        }
    }
}
