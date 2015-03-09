using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Domain
{
    public class DataProviderRequest
    {
        public DataProviderRequest(DataProviderRequestIdentifier request)
        {
            Request = request;
        }

        public DataProviderRequestIdentifier Request { get; private set; }
    }
}
