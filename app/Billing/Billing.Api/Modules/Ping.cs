using Billing.Api.Dtos;
using Common.Logging;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.Security;

namespace Billing.Api.Modules
{
    public class Ping : SecureModule
    {
        private static readonly ILog log = LogManager.GetLogger<Ping>();

        //public Ping() : base("/ping")
        //{
        //    Get["/"] = _ => "Pong";

        //    Post["/"] = o =>
        //    {
        //        var request = this.Bind<PingRequest>();

        //        return HttpStatusCode.OK;
        //    };
        //}
    }
}