using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestComapanyInformation : IHaveBusinessInformation
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
