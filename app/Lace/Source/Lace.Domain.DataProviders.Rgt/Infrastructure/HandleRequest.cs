using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public static class HandleRequest
    {
        public static string GetVinNumber(ICollection<IPointToLaceProvider> response, IAmRgtRequest request)
        {
            return ResponseDataMiner.Mine().ForVin(response);
        }

        public static int GetCarId(ICollection<IPointToLaceProvider> response, IAmRgtRequest request)
        {
            int carId;
            int.TryParse(request.CarId.GetValue(), out carId);
            return carId > 0 ? carId :  ResponseDataMiner.Mine().ForCarId(response);
        }
    }
}
