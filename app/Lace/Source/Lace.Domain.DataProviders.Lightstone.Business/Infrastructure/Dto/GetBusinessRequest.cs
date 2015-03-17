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

            // TODO: _request.Business.user_token and the other fields;
            //UserToken = _request.Business.UserToken;
           
            return this;
        }

        public GetBusinessRequest Validate()
        {
            // TODO
            //RequestIsValid = !string.IsNullOrEmpty(user_token) && !string.IsNullOrEmpty(IdCkOfOwner) &&
            //                 !string.IsNullOrEmpty(TrackingNumber);
            return this;
        }


        public string UserToken { get; private set; }

       
        public string CompanyName { get; private set; }

       
        public string CompanyRegnum { get; private set; }

       
        public string CompanyVatnumber { get; private set; }



      
    }

   
}
