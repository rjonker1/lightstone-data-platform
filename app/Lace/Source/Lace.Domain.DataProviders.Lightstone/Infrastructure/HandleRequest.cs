using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure
{
    public static class HandleRequest
    {
        public static bool IsSatisfied(IList<IPointToLaceProvider> response, IAmLightstoneAutoRequest request)
        {
            return !string.IsNullOrEmpty(GetVinNumber(response, request));
        }

        public static string GetVinNumber(IList<IPointToLaceProvider> response, IAmLightstoneAutoRequest request)
        {
            return string.IsNullOrEmpty(GetValue(request.VinNumber))
                ? ContinueWithIvid(response) ? response.OfType<IProvideDataFromIvid>().First().Vin : string.Empty
                : GetValue(request.VinNumber);
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }

        private static bool ContinueWithIvid(IList<IPointToLaceProvider> response)
        {
            return response.OfType<IProvideDataFromIvid>().Any() && response.OfType<IProvideDataFromIvid>().First() != null &&
                       response.OfType<IProvideDataFromIvid>().First().Handled;
        }
    }
}
