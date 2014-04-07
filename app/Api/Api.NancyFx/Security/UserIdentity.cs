using System.Collections.Generic;
using Nancy.Security;

namespace Api.NancyFx.Security
{
    public class UserIdentity : IUserIdentity
    {
        public string UserName { get; set; }

        public IEnumerable<string> Claims { get; set; }
    }
}