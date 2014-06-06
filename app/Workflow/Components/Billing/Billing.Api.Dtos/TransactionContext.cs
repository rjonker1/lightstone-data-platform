using DataPlatform.Shared.Public.Identifiers;

namespace Billing.Api.Dtos
{
    public class TransactionContext
    {
        public TransactionContext(UserIdentifier user, RequestIdentifier request)
        {
            User = user;
            Request = request;
        }

        public UserIdentifier User { get; private set; }
        public RequestIdentifier Request { get; private set; }
    }
}