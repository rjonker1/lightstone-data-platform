using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class RequestReferenceRequestField : IAmRequestReferenceRequestField
    {
        public string Field { get; private set; }

        public RequestReferenceRequestField(string field)
        {
            Field = field;
        }
    }
}