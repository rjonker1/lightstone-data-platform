using System.Linq;
using System.Runtime.InteropServices;
using MemBus.Support;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class UserProfileModule : NancyModule
    {
        public UserProfileModule(IRepository<UserProfile> userProfiles )
        {
            Get["/UserProfile"] = _ =>
            {

                return Response.AsJson(userProfiles);
            };
        }
    }
}