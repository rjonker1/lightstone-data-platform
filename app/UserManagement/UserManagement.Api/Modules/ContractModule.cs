using System.Linq;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class ContractModule : NancyModule
    {
        public ContractModule(IBus bus, IRepository<Contract> contracts)
        {

            Get["/Contracts"] = _ =>
            {

                return Response.AsJson(contracts.Select(x => x));
            };
        }
    }
}