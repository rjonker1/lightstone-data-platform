using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace DataProviders.MMCode.Core.Contracts
{
    public interface IGetCarId
    {
        int RetrieveCarId(ICollection<IPointToLaceProvider> response, IAmMmCodeRequest request);
    }
}
