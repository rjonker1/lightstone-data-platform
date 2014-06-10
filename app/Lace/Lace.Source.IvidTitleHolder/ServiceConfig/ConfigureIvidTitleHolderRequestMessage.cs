using Lace.Request;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Source.IvidTitleHolder.ServiceConfig
{
    public class ConfigureIvidTitleHolderRequestMessage
    {
        private readonly ILaceRequest _request;
        public TitleholderQueryRequest TitleholderQueryRequest { get; private set; }

        public ConfigureIvidTitleHolderRequestMessage(ILaceRequest request)
        {
            _request = request;
            BuildIvidTitleHolderQueryRequest();
        }

        private void BuildIvidTitleHolderQueryRequest()
        {
            TitleholderQueryRequest = new TitleholderQueryRequest()
            {
                requesterDetails = new RequesterDetailsElement()
                {
                    requesterEmail = _request.User.UserEmail ?? string.Empty,
                    requesterName = _request.User.UserFirstName ?? string.Empty,
                    requesterPhone = _request.User.UserPhone ?? string.Empty
                },

                vin = _request.Vehicle.Vin ?? string.Empty
            };
        }
    }
}
