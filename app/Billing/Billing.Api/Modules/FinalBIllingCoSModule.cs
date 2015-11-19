using System.Runtime.Remoting.Messaging;
using Nancy;
using Shared.BuildingBlocks.Api.Security;

namespace Billing.Api.Modules
{
    public class FinalBillingCoSModule : SecureModule
    {
        public FinalBillingCoSModule()
        {
            Get["/FinalBillingCoS"] = _ => Negotiate.WithView("Index");
        }
    }
}