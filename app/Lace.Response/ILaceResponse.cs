using Lace.Models;
using Lace.Models.Ivid;
using Lace.Models.IvidTitleHolder;
using Lace.Models.RgtVin;

namespace Lace.Response
{
    public interface ILaceResponse
    {
        IResponseFromIvid IvidResponse { get; set; }
        IResponseHandled IvidResponseHandled { get; set; }

        IResponseFromIvidTitleHolder IvidTitleHolderResponse { get; set; }
        IResponseHandled IvidTitleHolderResponseHandled { get; set; }

        IResponseFromRgtVin RgtVinResponse { get; set; }
        IResponseHandled RgtVinResponseHandled { get; set; }


        //IDictionary<int, string> ErrorDictionary { get; }
    }
}
