using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Lace.Models.Ivid;

namespace Lace.Response
{
    public interface ILaceResponse
    {
        IvidResponse IvidResponse { get; set; }
        ResponseHandled IvidResponseHandled { get; set; }


        //IDictionary<int, string> ErrorDictionary { get; }
    }
}
