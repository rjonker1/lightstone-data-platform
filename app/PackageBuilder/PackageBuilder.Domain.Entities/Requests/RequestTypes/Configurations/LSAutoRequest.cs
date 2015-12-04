using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class LightstoneAutoRequest : IAmLightstoneAutoRequest
    {
        public LightstoneAutoRequest(ICollection<IAmRequestField> requestFields)
        {
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
            CarId = requestFields.GetRequestField<IAmCarIdRequestField>();
            Make = requestFields.GetRequestField<IAmMakeRequestField>();
            Year = requestFields.GetRequestField<IAmYearRequestField>();
        }

        public IAmCarIdRequestField CarId { get; private set; }
        public IAmYearRequestField Year { get; private set; }
        public IAmMakeRequestField Make { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}