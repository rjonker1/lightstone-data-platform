using System.Collections.Generic;
using Lace.Response;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    class IvidTitleHolderServiceResponse : ILaceResponse
    {
        public bool Handled { get; set; }
        public List<string> Response { get; set; }
    }
}
