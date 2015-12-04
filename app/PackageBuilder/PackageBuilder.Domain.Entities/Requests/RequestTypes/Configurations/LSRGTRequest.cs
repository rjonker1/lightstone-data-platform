using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class RgtRequest : IAmRgtRequest
    {
        public RgtRequest(ICollection<IAmRequestField> requestFields)
        {
            CarId = requestFields.GetRequestField<IAmCarIdRequestField>();
        }
        public IAmCarIdRequestField CarId { get; private set; }
    }
}