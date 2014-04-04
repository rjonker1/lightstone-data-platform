using System.Collections.Generic;
using Lace.Response;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class IvidServiceResponse : ILaceResponse
    {
        public bool Handled { get; set; }
        public List<string> Response { get; set; }
    }
}
