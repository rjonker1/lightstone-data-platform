using System.Collections.Generic;
using Common.Logging;
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
        private readonly ILog _log = LogManager.GetLogger<FakeBasicUser>();
        public IUserIdentity Validate(string username, string password)
        {
            _log.Info("Getting the user");
            return new FakeUser("LightstoneAuto");
        }
    }
}