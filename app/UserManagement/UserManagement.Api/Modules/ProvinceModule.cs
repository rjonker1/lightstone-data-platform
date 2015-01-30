using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class ProvinceModule : NancyModule
    {
        public ProvinceModule(IRepository<Province> provinces)
        {

            Get["/Provinces"] = _ => Response.AsJson(provinces);
        }
    }
}