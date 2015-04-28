using Lim.Test.Api.Infrastructure;
using Lim.Test.Api.Models;
using Nancy;

namespace Lim.Test.Api.Modules
{
    public class FakeDealerPullApi : NancyModule
    {
        public FakeDealerPullApi(IRepository<SomeDealerData> repository)
        {
            Get["/api/get/dealerships"] = _ => Response.AsJson(repository.GetAll());
        }
    }
}