using Lace.Models;
using Lace.Models.Ivid.Dto;
using Lace.Models.IvidTitleHolder.Dto;
using Lace.Models.RgtVin.Dto;

namespace Lace.Response
{
    public class LaceResponse : ILaceResponse
    {
        public IvidResponse IvidResponse { get; set; }
        public IResponseHandled IvidResponseHandled { get; set; }

        public IvidTitleHolderResponse IvidTitleHolderResponse { get; set; }
        public IResponseHandled IvidTitleHolderResponseHandled { get; set; }

        public RgtVinResponse RgtVinResponse { get; set; }
        public IResponseHandled RgtVinResponseHandled { get; set; }
    }
}
