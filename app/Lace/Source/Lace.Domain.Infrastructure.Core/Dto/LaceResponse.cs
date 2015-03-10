using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Infrastructure.Core.Dto
{
    public class LaceResponse : IProvideResponseFromLaceDataProviders
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

        public IProvideDataFromJis JisResponse { get; set; }
        public IResponseProviderHandled JisResponseHandled { get; set; }


        public IProvideDataFromPCubedFicaVerfication FicaVerficationResponse { get; set; }
        public IResponseProviderHandled FicaVerficationResponseHandled { get; set; }

        public IProvideDataFromSignioDriversLicenseDecryption SignioDriversLicenseDecryptionResponse { get; set; }
        public IResponseProviderHandled SignioDriversLicenseDecryptionResponseHandled { get; set; }
        public IProvideDataFromLsp LspResponse { get; set; }
        public IResponseProviderHandled LspResponseHandled { get; set; }
    }
}
