using System.Collections.Generic;
using Lace.Request;
using Lace.Response;

namespace Lace
{
    public class LaceResponse
    {
        public IEnumerable<ILaceResponse> Responses { get; set; }
        public ILaceRequest Request { get; set; }
    }
}
