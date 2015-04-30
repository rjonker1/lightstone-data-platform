using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Dto
{
    public class IvidTitleHolderRequestMessage
    {
        private readonly IAmIvidTitleholderRequest _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        public TitleholderQueryRequest TitleholderQueryRequest { get; private set; }


        public IvidTitleHolderRequestMessage(IAmIvidTitleholderRequest request, ICollection<IPointToLaceProvider> response)
        {
            _request = request;
            _response = response;
            BuildRequest();
        }

        private bool ContinueWithIvid
        {
            get
            {
                return _response.OfType<IProvideDataFromIvid>().Any() && _response.OfType<IProvideDataFromIvid>().First() != null &&
                       _response.OfType<IProvideDataFromIvid>().First().Handled;
            }
        }

        private void BuildRequest()
        {
            TitleholderQueryRequest = new TitleholderQueryRequest()
            {
                requesterDetails = new RequesterDetailsElement()
                {
                    requesterEmail = GetValue(_request.RequesterEmail),
                    requesterName = GetValue(_request.RequesterName),
                    requesterPhone = GetValue(_request.RequesterPhone)
                },

                vin = GetVinNumber()
            };
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }

        private string GetVinNumber()
        {
            return string.IsNullOrEmpty(GetValue(_request.VinNumber))
                ? ContinueWithIvid ? _response.OfType<IProvideDataFromIvid>().First().Vin : string.Empty
                : GetValue(_request.VinNumber);
        }
    }
}
