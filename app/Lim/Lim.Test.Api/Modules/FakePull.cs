using Lim.Test.Api.Infrastructure;
using Lim.Test.Api.Models;
using Nancy;

namespace Lim.Test.Api.Modules
{
    public class FakePull : NancyModule
    {
        public FakePull(IRepository<SomeDealerData> repository)
        {
            Get["/api/pull"] = _ => Response.AsJson(repository.GetAll());
        }
    }
}