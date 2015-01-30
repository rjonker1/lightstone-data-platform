﻿using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Dto
{
    public class IvidTitleHolderRequestMessage
    {
        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _response;
        public TitleholderQueryRequest TitleholderQueryRequest { get; private set; }


        public IvidTitleHolderRequestMessage(ILaceRequest request, IProvideResponseFromLaceDataProviders response)
        {
            _request = request;
            _response = response;
            BuildRequest();
        }

        private bool CanContinue
        {
            get
            {
                return _response.IvidResponseHandled.Handled && _response.IvidResponse != null;
            }
        }

        private void BuildRequest()
        {
            TitleholderQueryRequest = new TitleholderQueryRequest()
            {
                requesterDetails = new RequesterDetailsElement()
                {
                    requesterEmail = _request.User.UserEmail ?? string.Empty,
                    requesterName = _request.User.UserFirstName ?? string.Empty,
                    requesterPhone = _request.User.UserPhone ?? string.Empty
                },

                vin = CanContinue
                    ? _response.IvidResponse.Vin
                    : string.Empty
            };
        }
    }
}
