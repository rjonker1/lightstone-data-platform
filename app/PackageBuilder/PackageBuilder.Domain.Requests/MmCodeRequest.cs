using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class MmCodeRequest : IAmMmCodeRequest
    {
        public IAmCarIdRequestField CarId { get; private set; }

        public MmCodeRequest(IAmCarIdRequestField carId)
        {
            CarId = carId;
        }
    }
}