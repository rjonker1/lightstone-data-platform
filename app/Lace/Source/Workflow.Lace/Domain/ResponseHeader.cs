using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Domain
{
    public class ResponseHeader
    {
        public ResponseIdentifier Response { get; private set; }

        public ResponseHeader(ResponseIdentifier response)
        {
            Response = response;
        }
    }
}
