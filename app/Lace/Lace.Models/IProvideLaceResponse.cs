using Lace.Models.Responses.Sources;
namespace Lace.Models
{
    public interface IProvideLaceResponse
    {
        IProvideDataFromIvid IvidResponse { get; set; }
        IResponseProviderHandled IvidResponseHandled { get; set; }

        IProvideDataFromIvidTitleHolder IvidTitleHolderResponse { get; set; }
        IResponseProviderHandled IvidTitleHolderResponseHandled { get; set; }

        IProvideDataFromRgtVin RgtVinResponse { get; set; }
        IResponseProviderHandled RgtVinResponseHandled { get; set; }

        IProvideDataFromAudatex AudatexResponse { get; set; }
        IResponseProviderHandled AudatexResponseHandled { get; set; }

        IProvideDataFromRgt RgtResponse { get; set; }
        IResponseProviderHandled RgtResponseHandled { get; set; }

        IProvideDataFromLightstone LightstoneResponse { get; set; }
        IResponseProviderHandled LightstoneResponseHandled { get; set; }

        IProvideDataFromAnpr AnprResponse { get; set; }
        IResponseProviderHandled AnprResponseHandled { get; set; }

    }
}
