using Lim.Test.Api.Data;
using Lim.Test.Api.Models.Packages;
using Nancy;

namespace Lim.Test.Api.Modules
{
    public class CacheModule : NancyModule
    {
        public CacheModule(IRepository repository)
        {
            Get["/api/pull/clear/transactions"] = _ =>
            {
                repository.Delete<Transaction>();
                return View["/"];
            };
        }
    }
}