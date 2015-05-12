using System.Collections.Generic;
using Nancy.Authentication.Basic;
using Nancy.Security;

namespace Lim.Test.Api.Models.Users
{
    public class FakeUser : IUserIdentity
    {
        public IEnumerable<string> Claims { get; private set; }
        public string UserName { get; private set; }

        public FakeUser(string userName)
        {
            UserName = userName;
        }
    }

    public class FakeBasicUser : IUserValidator
    {
        public IUserIdentity Validate(string username, string password)
        {
            return new FakeUser("LightstoneAuto");
        }
    }
}