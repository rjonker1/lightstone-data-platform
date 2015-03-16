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


        public ReturnCompaniesRequest(string userToken, string companyname, string companyregnum, string companyvatnumber)
        {
            user_token = userToken;
            company_name = companyname;
            company_regnum = companyregnum;
            company_vatnumber = companyvatnumber;
        }

        [DataMember]
        public string user_token { get; private set; }

        [DataMember]
        public string company_name { get; private set; }

        [DataMember]
        public string company_regnum { get; private set; }

        [DataMember]
        public string company_vatnumber { get; private set; }
        
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
