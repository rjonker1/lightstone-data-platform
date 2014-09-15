using Lace.Models;
using Lace.Models.Anpr;
using Lace.Models.Audatex;
using Lace.Models.Ivid;
using Lace.Models.IvidTitleHolder;
using Lace.Models.Lightstone;
using Lace.Models.Rgt;
using Lace.Models.RgtVin;

namespace Lace.Response
{
    public class LaceResponse : ILaceResponse
    {
        public IResponseFromIvid IvidResponse { get; set; }
        public IResponseHandled IvidResponseHandled { get; set; }

        public IResponseFromIvidTitleHolder IvidTitleHolderResponse { get; set; }
        public IResponseHandled IvidTitleHolderResponseHandled { get; set; }

        public IResponseFromRgtVin RgtVinResponse { get; set; }
        public IResponseHandled RgtVinResponseHandled { get; set; }

        public IResponseFromAudatex AudatexResponse { get; set; }
        public IResponseHandled AudatexResponseHandled { get; set; }

        public IResponseFromRgt RgtResponse { get; set; }
        public IResponseHandled RgtResponseHandled { get; set; }

        public IResponseFromLightstone LightstoneResponse { get; set; }
        public IResponseHandled LightstoneResponseHandled { get; set; }


        public IResponseFromAnpr AnprResponse { get; set; }

        public IResponseHandled AnprResponseHandled { get; set; }

    }
}
