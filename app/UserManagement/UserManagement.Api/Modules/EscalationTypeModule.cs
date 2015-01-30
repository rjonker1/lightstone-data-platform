using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class EscalationTypeModule : NancyModule
    {
        public EscalationTypeModule(IRepository<EscalationType> escalationTypes)
        {

            Get["/EscalationTypes"] = _ => Response.AsJson(escalationTypes);
        }
    }
}