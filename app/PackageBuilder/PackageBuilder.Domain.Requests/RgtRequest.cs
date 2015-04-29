using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class RgtRequest : IAmRgtRequest
    {
        public IAmCarIdRequestField CarId { get; private set; }

        public RgtRequest(IAmCarIdRequestField carId)
        {
            CarId = carId;
        }
    }
}