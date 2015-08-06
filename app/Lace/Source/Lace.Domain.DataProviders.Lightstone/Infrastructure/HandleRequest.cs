using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure
{
    public static class HandleRequest
    {
        public static string GetVinNumber(ICollection<IPointToLaceProvider> response, IAmLightstoneAutoRequest request)
        {
            return !string.IsNullOrEmpty(request.VinNumber.GetValue()) ? request.VinNumber.GetValue() : ResponseDataMiner.Mine().ForVin(response);
        }

        public static int GetCarId(IAmLightstoneAutoRequest request)
        {
            int carId;
            int.TryParse(request.CarId.GetValue(), out carId);
            return carId;
        }

        public static int GetYear(IAmLightstoneAutoRequest request)
        {
            int year;
            int.TryParse(request.Year.GetValue(), out year);
            return year;
        }
    }
}