using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Domain
{
    public class DataProviderResponse
    {
        public DataProviderResponseIdentifier Response { get; private set; }

        public DataProviderResponse(DataProviderResponseIdentifier response)
        {
            Response = response;
        }
    }
}
