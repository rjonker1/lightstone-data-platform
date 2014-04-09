using Lace.Models.Ivid.Dto;
using Lace.Models.IvidTitleHolder.Dto;
using Lace.Models.RgtVin.Dto;

namespace Lace.Response
{
    public interface ILaceResponse
    {
        IvidResponse IvidResponse { get; set; }
        ResponseHandled IvidResponseHandled { get; set; }

        IvidTitleHolderResponse IvidTitleHolderResponse { get; set; }
        ResponseHandled IvidTitleHolderResponseHandled { get; set; }

        RgtVinResponse RgtVinResponse { get; set; }
        ResponseHandled RgtVinResponseHandled { get; set; }


        //IDictionary<int, string> ErrorDictionary { get; }
    }
}
