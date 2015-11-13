using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class RgtVinRequest : IAmRgtVinRequest
    {
        public IAmVinNumberRequestField VinNumber { get; private set; }

        public RgtVinRequest(IAmVinNumberRequestField vinNumber)
        {
            VinNumber = vinNumber;
        }
    }
}