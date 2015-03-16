using System;
using System.Runtime.Serialization;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class ReturnCompaniesRequest 
    {
        public ReturnCompaniesRequest()
        {
            
        }


        public ReturnCompaniesRequest(string userToken, string companyName, string companyRegnum, string companyVatNumber)
        {
            UserToken = userToken;
            CompanyName = companyName;
            CompanyRegnum = companyRegnum;
            CompanyVatnumber = companyVatNumber;
        }

        [DataMember]
        public string UserToken { get; private set; }

        [DataMember]
        public string CompanyName { get; private set; }

        [DataMember]
        public string CompanyRegnum { get; private set; }

        [DataMember]
        public string CompanyVatnumber { get; private set; }
        
    }

    [Serializable]
    [DataContract]
    public class ReturnCompaniesResponse
    {
        
        // Default Constructor
        public ReturnCompaniesResponse()
        {
            
        }


        public ReturnCompaniesResponse(string result)
        {
            Result = result;
        }

       

        [DataMember]
        public string Result { get; private set; }
    }
}
