using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class ContractTypeModule : NancyModule
    {
        public ContractTypeModule(IRepository<ContractType> contractTypes)
        {

            Get["/ContractTypes"] = _ => Response.AsJson(contractTypes);
        }
    }
}