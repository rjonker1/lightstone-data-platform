namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Dto
{
    public class GetBusinessRequest
    {
        //TODO: Uncomment after updating package builder request contracts
        //private readonly IAmLightstoneBusinessRequest _request;

        public bool RequestIsValid { get; private set; }

        //public GetBusinessRequest(IAmLightstoneBusinessRequest request)
        //{
        //    _request = request;
        //}

        public GetBusinessRequest Map()
        {
            //UserToken = _request.UserToken.Field;
            //CompanyName = _request.CompanyName.Field;
            //CompanyRegnum = _request.CompanyRegistrationNumber.Field;
            //CompanyVatnumber = _request.CompanyVatNumber.Field;
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
