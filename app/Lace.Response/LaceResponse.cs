using Lace.Models;
using Lace.Models.Ivid;
using Lace.Models.IvidTitleHolder;
using Lace.Models.IvidTitleHolder.Dto;
using Lace.Models.RgtVin;
using Lace.Models.RgtVin.Dto;

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
    }
}
