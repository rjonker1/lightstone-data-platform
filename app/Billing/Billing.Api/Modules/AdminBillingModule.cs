using Nancy;

namespace Billing.Api.Modules
{
    public class AdminBillingModule : NancyModule
    {
        public AdminBillingModule()
        {

            Get["/Admin/Billing"] = _ =>  Negotiate.WithView("Index");
        }
    }
}