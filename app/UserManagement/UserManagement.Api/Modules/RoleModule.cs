using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class RoleModule : NancyModule
    {
        public RoleModule(INamedEntityRepository<NamedEntity> roles)
        {
            Get["/Roles"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new {data = roles});
            };
        }
    }
}