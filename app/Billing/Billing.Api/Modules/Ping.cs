using Billing.Api.Dtos;
using Common.Logging;
using Nancy;
using Nancy.ModelBinding;

namespace Billing.Api.Modules
{
    public class Ping : NancyModule
    {
        private static readonly ILog log = LogManager.GetLogger<Ping>();

        public Ping() : base("/ping")
        {
            Get["/"] = _ => "Pong";

            Post["/"] = o =>
            {
                var request = this.Bind<PingRequest>();

                return HttpStatusCode.OK;
            };
        }
    }
}