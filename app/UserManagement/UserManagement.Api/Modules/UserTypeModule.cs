using System.Linq;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class UserTypeModule : NancyModule
    {
        public UserTypeModule(IRepository<UserType> userTypeRepo )
        {

            Get["/UserTypes"] = _ => Response.AsJson(userTypeRepo.ToList());

        }
    }
}