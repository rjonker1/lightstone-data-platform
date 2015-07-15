using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public static class HandleRequest
    {
        public static string GetVinNumber(ICollection<IPointToLaceProvider> response, IAmRgtRequest request)
        {
            return ResponseDataDigger.Dig().ForVin(response);
        }

        public static int GetCarId(ICollection<IPointToLaceProvider> response, IAmRgtRequest request)
        {
            int carId;
            int.TryParse(GetValue(request.CarId), out carId);
            return carId > 0 ? carId :  ResponseDataDigger.Dig().ForCarId(response);
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }
    }
}
