using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestComapanyInformation : IProvideBusinessInformationForRequest
    {

        public RequestComapanyInformation()
        {
         
        }


        public string UserToken { get; private set; }
        public string CompanyName { get; private set; }
        public string CompanyRegNumber { get; private set; }
        public string CompanyVatNumber { get; private set; }
    }
}
