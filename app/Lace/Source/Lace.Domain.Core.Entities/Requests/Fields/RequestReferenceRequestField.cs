using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
{
    public class RequestReferenceRequestField : IAmRequestReferenceRequestField
    {
        public string Field { get; private set; }
    }
}