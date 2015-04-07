using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Dto
{
    public class GetBusinessRequest
    {
        private readonly IHaveBusiness _request;

        public bool RequestIsValid { get; private set; }

        public GetBusinessRequest(IHaveBusiness request)
        {
            _request = request;
        }

        public GetBusinessRequest Map()
        {
            UserToken = _request.UserToken;
            CompanyName = _request.CompanyName;
            CompanyRegnum = _request.CompanyRegNumber;
            CompanyVatnumber = _request.CompanyVatNumber;
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
