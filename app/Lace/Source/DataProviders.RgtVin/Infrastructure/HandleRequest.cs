using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public static class HandleRequest
    {
        public static string GetVinNumber(ICollection<IPointToLaceProvider> response, IAmRgtVinRequest request)
        {
            return !string.IsNullOrEmpty(request.VinNumber.GetValue())
                ? request.VinNumber.GetValue()
                : new ResponseDataMiningFactory().MineVinNumber(response);
        }
    }
}