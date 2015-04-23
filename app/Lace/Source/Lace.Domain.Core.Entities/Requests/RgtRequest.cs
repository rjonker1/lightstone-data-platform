using Lace.Domain.Core.Requests.Contracts.RequestFields;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities.Requests
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