using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class ContractDurationModule : NancyModule
    {
        public ContractDurationModule(IRepository<ContractDuration> contractDurations)
        {
            Get["/ContractDurations"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = contractDurations });
            };
        }
    }
}