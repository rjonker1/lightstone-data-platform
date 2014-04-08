using Lace.Models.Ivid;

namespace Lace.Response
{
    class LaceResponse : ILaceResponse
    {
        public IvidResponse IvidResponse { get; set; }
        public ResponseHandled IvidResponseHandled { get; set; }
    }
}
