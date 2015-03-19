using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Business;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class ReturnCompaniesRequest
    {
        public ReturnCompaniesRequest()
        {
        }


        public ReturnCompaniesRequest(string userToken, string companyName, string companyRegnum,
            string companyVatNumber)
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
    public class ReturnCompaniesResponse : LightstoneBusinessResponse
    {

        public ReturnCompaniesResponse()
        {
            
        }

       

        /// <remarks />
       //[XmlType(AnonymousType = true)]
        [DataContract]
        public class Company : IRespondWithBusiness
        {
            /// <remarks />

            [DataMember]
            public uint CompanyId { get; set; }

            /// <remarks />
            [DataMember]
            public string CompanyName { get; set; }

            /// <remarks />
            [DataMember]
            public string CompanyRegNumber { get; set; }

            /// <remarks />
            [DataMember]
            public string VatNo { get; set; }

            /// <remarks />
            [DataMember]
            public byte StatusCode { get; set; }

            /// <remarks />
            [DataMember]
            public string Id { get; set; }

            /// <remarks />
            [DataMember]
            public byte RowOrder { get; set; }


            public Type Type { get; private set; }
            public string TypeName { get; private set; }
            //public DataSet Result { get; private set; }
        }

      

        public ReturnCompaniesResponse(IEnumerable<Company> result)
            
        {
            Result = result;
        }


        [DataMember]
        public IEnumerable<Company> Result { get; private set; }
    }
}
