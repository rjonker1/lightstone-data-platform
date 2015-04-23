using Lace.Domain.Core.Requests.Contracts.RequestFields;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities.Requests
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