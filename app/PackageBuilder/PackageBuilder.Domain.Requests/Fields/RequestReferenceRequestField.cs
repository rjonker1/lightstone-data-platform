using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
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