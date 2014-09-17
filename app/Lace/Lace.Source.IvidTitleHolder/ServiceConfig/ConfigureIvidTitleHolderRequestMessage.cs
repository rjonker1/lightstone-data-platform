using Lace.Models;
using Lace.Request;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Source.IvidTitleHolder.ServiceConfig
{
    public class ConfigureIvidTitleHolderRequestMessage
    {
        private readonly ILaceRequest _request;
        private readonly IProvideLaceResponse _response;
        public TitleholderQueryRequest TitleholderQueryRequest { get; private set; }

      
        public ConfigureIvidTitleHolderRequestMessage(ILaceRequest request, IProvideLaceResponse response)
        {
            _request = request;
            _response = response;
        }

        private bool CanContinue
        {
            get
            {
                return _response.IvidResponseHandled.Handled && _response.IvidResponse != null;
            }
        }

        public ConfigureIvidTitleHolderRequestMessage Build()
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

            return this;
        }

    }
}
