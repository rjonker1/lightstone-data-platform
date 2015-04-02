using Nancy;

namespace Billing.Scheduler.Modules
{
    public class Index : NancyModule
    {
        public Index()
        {
            Get["/"] = _ =>
            {
                return Response.AsRedirect("/hangfire");
            };
        }
    }
}