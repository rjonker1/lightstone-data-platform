using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Contracts
{
    public interface IProvideResponseFromLaceDataProviders
    {
        IProvideDataFromIvid IvidResponse { get; set; }
        IProvideDataFromIvidTitleHolder IvidTitleHolderResponse { get; set; }
        IProvideDataFromRgtVin RgtVinResponse { get; set; }
        IProvideDataFromAudatex AudatexResponse { get; set; }
        IProvideDataFromRgt RgtResponse { get; set; }
        IProvideDataFromLightstoneAuto LightstoneResponse { get; set; }
        IProvideDataFromAnpr AnprResponse { get; set; }
        IProvideDataFromJis JisResponse { get; set; }
        IProvideDataFromPCubedFicaVerfication FicaVerficationResponse { get; set; }
        IProvideDataFromSignioDriversLicenseDecryption SignioDriversLicenseDecryptionResponse { get; set; }
        IProvideDataFromLightstoneProperty LightstonePropertyResponse { get; set; }
    }
}
