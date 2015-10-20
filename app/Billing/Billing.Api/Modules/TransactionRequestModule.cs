using Shared.BuildingBlocks.Api.Security;

namespace Billing.Api.Modules
{
    public class TransactionRequestModule : SecureModule
    {
        public TransactionRequestModule()
        {
            //TODO: Add route for validation of RequestId from PackageBuilder
            Get["/Transactions/Requests/Vin12"] = _ => null;
        }
    }
}