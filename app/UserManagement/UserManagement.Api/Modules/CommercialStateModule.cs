using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class CommercialStateModule : NancyModule
    {
        public CommercialStateModule(IRepository<CommercialState> commercialStates)
        {

            Get["/CommercialStates"] = _ => Response.AsJson(commercialStates);
        }
    }
}