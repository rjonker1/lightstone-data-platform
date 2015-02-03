using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class CommercialStateModule : NancyModule
    {
        public CommercialStateModule(IRepository<CommercialState> commercialStates)
        {

            Get["/CommercialStates"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = commercialStates });
            };
        }
    }
}