using System.Collections.Generic;
using Nancy.Security;

namespace Shared.BuildingBlocks.Api.Security
{
    public class ApiUser : IUserIdentity
    {
        public ApiUser()
        {
        }

        public ApiUser(string userName)
        {
            UserName = userName;
            Claims = new List<string>();
        }

        public string UserName { get; private set; }
        public IEnumerable<string> Claims { get; set; }
    }
}