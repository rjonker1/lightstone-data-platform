using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public static class HandleRequest
    {
        public static string GetVinNumber(ICollection<IPointToLaceProvider> response, IAmRgtVinRequest request)
        {
            return !string.IsNullOrEmpty(GetValue(request.VinNumber)) ? GetValue(request.VinNumber) :  ResponseDataDigger.Dig().ForVin(response);
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }
    }
}