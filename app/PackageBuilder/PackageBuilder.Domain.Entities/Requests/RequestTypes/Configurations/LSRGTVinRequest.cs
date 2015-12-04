using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class RgtVinRequest : IAmRgtVinRequest
    {
        public RgtVinRequest(ICollection<IAmRequestField> requestFields)
        {
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
        }
        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}