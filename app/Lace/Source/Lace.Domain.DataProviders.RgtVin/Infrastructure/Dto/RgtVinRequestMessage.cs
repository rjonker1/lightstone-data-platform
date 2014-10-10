using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto
{
    public class RgtVinRequestMessage
    {
        public string Vin { get; private set; }
        private readonly IProvideResponseFromLaceDataProviders _response;
        
        public RgtVinRequestMessage(IProvideResponseFromLaceDataProviders response)
        {
            _response = response;
        }

        public RgtVinRequestMessage Build()
        {
            Vin = _response.IvidResponse != null && _response.IvidResponseHandled.Handled
                ? _response.IvidResponse.Vin
                : string.Empty;

            return this;
        }
    }
}
