using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class EscalationTypeModule : NancyModule
    {
        public EscalationTypeModule(IRepository<EscalationType> escalationTypes)
        {

            Get["/EscalationTypes"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = escalationTypes });
            };
        }
    }
}