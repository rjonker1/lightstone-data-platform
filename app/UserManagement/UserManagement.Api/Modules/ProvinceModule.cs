using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class ProvinceModule : NancyModule
    {
        public ProvinceModule(IRepository<Province> provinces)
        {

            Get["/Provinces"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new {data = provinces});
            };
        }
    }
}