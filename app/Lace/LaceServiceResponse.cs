using Lace.Request;
using Lace.Response;

namespace Lace
{
    public class LaceServiceResponse
    {
        public ILaceResponse Response { get; set; }
        public ILaceRequest Request { get; set; }
    }
}
