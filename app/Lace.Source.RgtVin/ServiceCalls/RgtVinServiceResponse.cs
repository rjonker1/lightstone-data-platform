using Lace.Response;
using System.Collections.Generic;

namespace Lace.Source.RgtVin.ServiceCalls
{
    class RgtVinServiceResponse : ILaceResponse
    {
        public bool Handled { get; set; }
        public List<string> Response { get; set; }
    }
}
