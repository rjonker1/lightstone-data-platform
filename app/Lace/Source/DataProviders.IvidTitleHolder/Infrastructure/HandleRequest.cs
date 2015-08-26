using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public static class HandleRequest
    {
        public static TitleholderQueryRequest GetTitleholderQueryRequest(ICollection<IPointToLaceProvider> response, IAmIvidTitleholderRequest request)
        {
            return new TitleholderQueryRequest()
            {
                requesterDetails = new RequesterDetailsElement()
                {
                    requesterEmail = request.RequesterEmail.GetValue(),
                    requesterName = request.RequesterName.GetValue(),
                    requesterPhone = request.RequesterPhone.GetValue()
                },

                vin = !string.IsNullOrEmpty(request.VinNumber.GetValue()) ? request.VinNumber.GetValue() : ResponseDataMiner.Mine().ForVin(response)
            };
        }
    }
}