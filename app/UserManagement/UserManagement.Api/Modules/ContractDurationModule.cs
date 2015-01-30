using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class ContractDurationModule : NancyModule
    {
        public ContractDurationModule(IRepository<ContractDuration> contractDurations)
        {

            Get["/ContractDurations"] = _ => Response.AsJson(contractDurations);
        }
    }
}