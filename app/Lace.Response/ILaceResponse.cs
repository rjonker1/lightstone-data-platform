using Lace.Models;
using Lace.Models.Ivid.Dto;
using Lace.Models.IvidTitleHolder.Dto;
using Lace.Models.RgtVin.Dto;

namespace Lace.Response
{
    public interface ILaceResponse
    {
        IvidResponse IvidResponse { get; set; }
        IResponseHandled IvidResponseHandled { get; set; }

        IvidTitleHolderResponse IvidTitleHolderResponse { get; set; }
        IResponseHandled IvidTitleHolderResponseHandled { get; set; }

        RgtVinResponse RgtVinResponse { get; set; }
        IResponseHandled RgtVinResponseHandled { get; set; }


        //IDictionary<int, string> ErrorDictionary { get; }
    }
}
