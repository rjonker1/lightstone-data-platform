using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Dto
{
    public class IvidTitleHolderRequestMessage
    {
        private readonly ILaceRequest _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        public TitleholderQueryRequest TitleholderQueryRequest { get; private set; }


        public IvidTitleHolderRequestMessage(ILaceRequest request, ICollection<IPointToLaceProvider> response)
        {
            _request = request;
            _response = response;
            BuildRequest();
        }

        private bool CanContinue
        {
            get
            {
                return _response.OfType<IProvideDataFromIvid>().First() != null &&
                       _response.OfType<IProvideDataFromIvid>().First().Handled;
            }
        }

        private void BuildRequest()
        {
            TitleholderQueryRequest = new TitleholderQueryRequest()
            {
                requesterDetails = new RequesterDetailsElement()
                {
                    requesterEmail = _request.User.UserName ?? string.Empty,
                    requesterName = _request.User.UserFirstName ?? string.Empty,
                    requesterPhone = string.Empty
                },

                vin = CanContinue
                    ? _response.OfType<IProvideDataFromIvid>().First().Vin
                    : string.Empty
            };
        }
    }
}
