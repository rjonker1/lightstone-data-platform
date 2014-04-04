using System.Collections.Generic;

namespace Lace.Response
{
    public interface ILaceResponse
    {
        bool Handled { get; set; }
        List<string> Response { get; set; }
    }
}
