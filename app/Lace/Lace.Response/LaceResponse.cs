using Lace.Models;
using Lace.Models.Responses;
using Lace.Models.Responses.Sources;

namespace Lace.Response
{
    public class LaceResponse : IProvideLaceResponse
    {
        public IProvideDataFromIvid IvidResponse { get; set; }
        public IResponseProviderHandled IvidResponseHandled { get; set; }

        public IProvideDataFromIvidTitleHolder IvidTitleHolderResponse { get; set; }
        public IResponseProviderHandled IvidTitleHolderResponseHandled { get; set; }

        public IProvideDataFromRgtVin RgtVinResponse { get; set; }
        public IResponseProviderHandled RgtVinResponseHandled { get; set; }

        public IProvideDataFromAudatex AudatexResponse { get; set; }
        public IResponseProviderHandled AudatexResponseHandled { get; set; }

        public IProvideDataFromRgt RgtResponse { get; set; }
        public IResponseProviderHandled RgtResponseHandled { get; set; }

        public IProvideDataFromLightstone LightstoneResponse { get; set; }
        public IResponseProviderHandled LightstoneResponseHandled { get; set; }

        public IProvideDataFromAnpr AnprResponse { get; set; }
        public IResponseProviderHandled AnprResponseHandled { get; set; }

    }
}
