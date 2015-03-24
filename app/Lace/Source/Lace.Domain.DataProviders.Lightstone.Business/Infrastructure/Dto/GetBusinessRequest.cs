using System.Xml.Schema;
using System.Xml.Serialization;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Dto
{
    public class GetBusinessRequest
    {
        private readonly ILaceRequest _request;

        public bool RequestIsValid { get; private set; }

        public GetBusinessRequest(ILaceRequest request)
        {
            _request = request;
        }

        public GetBusinessRequest Map()
        {
            UserToken = _request.Business.UserToken;
            CompanyName = _request.Business.CompanyName;
            CompanyRegnum = _request.Business.CompanyRegNumber;
            CompanyVatnumber = _request.Business.CompanyVatNumber;
            return this;
        }

        public GetBusinessRequest Validate()
        {
            RequestIsValid = !string.IsNullOrEmpty(UserToken);
            return this;
        }


        public string UserToken { get; private set; }


        public string CompanyName { get; private set; }


        public string CompanyRegnum { get; private set; }


        public string CompanyVatnumber { get; private set; }
    }
}
