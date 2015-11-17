using Nancy;
using Shared.BuildingBlocks.Api.Security;

namespace Billing.Api.Modules
{
    public class PreBillingCoSModule : SecureModule
    {
        public PreBillingCoSModule()
        {
            Get["/PreBillingCoS"] = _ => Negotiate.WithView("Index");
        }
    }
}