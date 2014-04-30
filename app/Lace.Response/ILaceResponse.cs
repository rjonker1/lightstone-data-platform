using Lace.Models;
using Lace.Models.Audatex;
using Lace.Models.Ivid;
using Lace.Models.IvidTitleHolder;
using Lace.Models.Lightstone;
using Lace.Models.Rgt;
using Lace.Models.RgtVin;

namespace Lace.Response
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
        IResponseHandled LighResponseHandled { get; set; }
    }
}
