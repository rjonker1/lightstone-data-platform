using Nancy;

namespace Billing.Scheduler.Modules
{
    public class Index : NancyModule
    {
        public Index()
        {
            Get["/"] = _ => Response.AsRedirect("/hangfire");
        }
    }
}