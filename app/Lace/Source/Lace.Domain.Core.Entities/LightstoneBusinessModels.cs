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
    public class Company : IRespondWithBusiness
    {

        public Company()
        {

        }

        public Company(uint companyId, string companyName, string companyRegNumber, byte statusCode, string id, byte rowOrder, Type type, string typeName)
        {
            TypeName = typeName;
            Type = type;
            RowOrder = rowOrder;
            Id = id;
            StatusCode = statusCode;
            CompanyRegNumber = companyRegNumber;
            CompanyName = companyName;
            CompanyId = companyId;
        }

        /// <remarks />

        [DataMember]
        public uint CompanyId { get; private set; }

        /// <remarks />
        [DataMember]
        public string CompanyName { get; private set; }

        /// <remarks />
        [DataMember]
        public string CompanyRegNumber { get; private set; }

        /// <remarks />
        [DataMember]
        public string VatNo { get; set; }

        /// <remarks />
        [DataMember]
        public byte StatusCode { get; private set; }

        /// <remarks />
        [DataMember]
        public string Id { get; private set; }

        /// <remarks />
        [DataMember]
        public byte RowOrder { get; private set; }

        [DataMember]
        public Type Type { get; private set; }
        [DataMember]
        public string TypeName { get; private set; }
    }


    [Serializable]
    [DataContract]
    public class ReturnCompaniesResponse : IRespondWithBusiness
    {

        public ReturnCompaniesResponse()
        {
            
        }

       
      

        public ReturnCompaniesResponse(IEnumerable<Company> result)
            
        {
            Result = result;
        }


        [DataMember]
        public IEnumerable<Company> Result { get; private set; }

        public Type Type { get; private set; }
        public string TypeName { get; private set; }
    }
}
