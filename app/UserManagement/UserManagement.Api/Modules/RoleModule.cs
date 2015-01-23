using System.Linq;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class RoleModule : NancyModule
    {
        public RoleModule(IRepository<Role> roleRepository)
        {

            Get["/Roles"] = _ => Response.AsJson(roleRepository.ToList());

        }
    }
}