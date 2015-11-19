using System.Text;
using Lim.Test.Api.Models.Users;
using Nancy.Security;

namespace Lim.Test.Api.Core
{
    public interface IUserApiMapper
    {
        IUserIdentity GetAnyUser();
        IUserIdentity GetUserFromToken(string token);
        IUserIdentity GetUserWithTokenAndAutorization(string token, string authorization);
    }

    public class UserApiMapper : IUserApiMapper
    {
        private const string Token = "2b1eeb42-0cf7-4234-b798-3bbaa293e273";
        private const string Username = "LightStoneAuto";
        private const string Password = "1234567890";

        public IUserIdentity GetUserFromToken(string token)
        {
            return token == Token ? new FakeUser("LightstoneAuto") : null;
        }

        public IUserIdentity GetUserWithTokenAndAutorization(string token, string authorization)
        {
            var usercredentials = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(authorization));

            if (string.IsNullOrEmpty(usercredentials))
                return null;

            var user = usercredentials.Split(':');
            if (string.IsNullOrWhiteSpace(user[0]) || string.IsNullOrWhiteSpace(user[1]))
                return null;

            return token == Token ? new FakeUser("LightstoneAuto") : null;
        }

        public IUserIdentity GetAnyUser()
        {
            return new FakeUser("LightstoneAuto");
        }
    }

}
