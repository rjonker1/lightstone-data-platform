using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto
{
    public class RgtVinRequestMessage
    {
        public RgtVinRequest RgtVinRequest { get; private set; }
        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _response;


        public RgtVinRequestMessage(ILaceRequest request, IProvideResponseFromLaceDataProviders response)
        {
            _request = request;
            _response = response;
        }

        public RgtVinRequestMessage Build()
        {
            RgtVinRequest = new RgtVinRequest(_response.IvidResponse != null && _response.IvidResponseHandled.Handled
                ? _response.IvidResponse.Vin
                : string.Empty, _request.Context.SecurityCode);


            return this;
        }
    }
}
