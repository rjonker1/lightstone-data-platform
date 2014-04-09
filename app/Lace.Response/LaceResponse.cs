using Lace.Models.Ivid.Dto;
using Lace.Models.IvidTitleHolder.Dto;
using Lace.Models.RgtVin.Dto;

namespace Lace.Response
{
    public class LaceResponse : ILaceResponse
    {
        public IvidResponse IvidResponse { get; set; }
        public ResponseHandled IvidResponseHandled { get; set; }

        public IvidTitleHolderResponse IvidTitleHolderResponse { get; set; }
        public ResponseHandled IvidTitleHolderResponseHandled { get; set; }

        public RgtVinResponse RgtVinResponse { get; set; }
        public ResponseHandled RgtVinResponseHandled { get; set; }
    }
}
