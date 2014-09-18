using Lace.Models;
using Lace.Models.RgtVin.DataObject;
using Lace.Request;

namespace Lace.Source.RgtVin.ServiceConfig
{
    public class ConfigureRgtVinRequestMessage
    {
        public RgtVinRequest RgtVinRequest { get; private set; }
        private readonly ILaceRequest _request;
        private readonly IProvideLaceResponse _response;


        public ConfigureRgtVinRequestMessage(ILaceRequest request, IProvideLaceResponse response)
        {
            _request = request;
            _response = response;
        }

        public ConfigureRgtVinRequestMessage Build()
        {
            RgtVinRequest = new RgtVinRequest(_response.IvidResponse != null && _response.IvidResponseHandled.Handled
                ? _response.IvidResponse.Vin
                : string.Empty, _request.Context.SecurityCode);


            return this;
        }
    }
}
