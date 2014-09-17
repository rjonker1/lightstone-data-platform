using Lace.Models.Responses.Sources;

namespace Lace.Models.Responses
{
    public interface ILaceResponse
    {
        IResponseFromIvid IvidResponse { get; set; }
        IResponseHandled IvidResponseHandled { get; set; }

        IResponseFromIvidTitleHolder IvidTitleHolderResponse { get; set; }
        IResponseHandled IvidTitleHolderResponseHandled { get; set; }

        IResponseFromRgtVin RgtVinResponse { get; set; }
        IResponseHandled RgtVinResponseHandled { get; set; }

        IResponseFromAudatex AudatexResponse { get; set; }
        IResponseHandled AudatexResponseHandled { get; set; }

        IResponseFromRgt RgtResponse { get; set; }
        IResponseHandled RgtResponseHandled { get; set; }

        IResponseFromLightstone LightstoneResponse { get; set; }
        IResponseHandled LightstoneResponseHandled { get; set; }

        IResponseFromAnpr AnprResponse { get; set; }
        IResponseHandled AnprResponseHandled { get; set; }

    }
}
