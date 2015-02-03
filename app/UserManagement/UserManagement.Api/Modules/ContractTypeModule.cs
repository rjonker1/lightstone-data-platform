using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class ContractTypeModule : NancyModule
    {
        public ContractTypeModule(IRepository<ContractType> contractTypes)
        {

            Get["/ContractTypes"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = contractTypes });
            };
        }
    }
}