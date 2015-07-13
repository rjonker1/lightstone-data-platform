using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public static class HandleRequest
    {
        public static bool IsSatisfied(ICollection<IPointToLaceProvider> response, IAmRgtRequest request)
        {
            return !string.IsNullOrEmpty(GetVinNumber(response, request));
        }

        public static string GetVinNumber(ICollection<IPointToLaceProvider> response, IAmRgtRequest request)
        {
            return ContinueWithIvid(response) ? response.OfType<IProvideDataFromIvid>().First().Vin : string.Empty;
        }

        public static int GetCarId(IAmRgtRequest request)
        {
            int carId;
            int.TryParse(GetValue(request.CarId), out carId);
            return carId;
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }

        private static bool ContinueWithIvid(ICollection<IPointToLaceProvider> response)
        {
            return response != null && response.OfType<IProvideDataFromIvid>().Any() && response.OfType<IProvideDataFromIvid>().First() != null &&
                   response.OfType<IProvideDataFromIvid>().First().Handled;
        }
    }
}
