using System.Linq;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class RoleModule : NancyModule
    {
        public RoleModule(IRepository<Role> roles)
        {

            Get["/Roles"] = _ => Response.AsJson(roles.ToList());

        }
    }
}