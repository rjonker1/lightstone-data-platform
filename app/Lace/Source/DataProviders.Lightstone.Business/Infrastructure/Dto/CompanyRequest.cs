using System.Runtime.Serialization;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Dto
{
    [DataContract]
    public class CompanyRequest
    {
        //const string idNumber = "7902065199085";
        //const string companyname = "lightstone";
        //const string company_reg = "2010/018608/07";
        //const string company_vat = "4740259769";

        private readonly IAmLightstoneBusinessCompanyRequest _request;
        public CompanyRequest(IAmLightstoneBusinessCompanyRequest request)
        {
            _request = request;
        }

        public CompanyRequest Map()
        {
            //IdNumber = GetValue(_request.IdNumber);
            CompanyName =_request.CompanyName.GetValue();
            CompanyRegnum = _request.CompanyRegistrationNumber.GetValue();
            CompanyVatnumber = _request.CompanyVatNumber.GetValue();
            return this;
        }

        public CompanyRequest Validate()
        {
            IsValid = !string.IsNullOrEmpty(CompanyName) || !string.IsNullOrEmpty(CompanyRegnum) || !string.IsNullOrEmpty(CompanyVatnumber);
            return this;
        }

        [DataMember]
        public bool IsValid { get; private set; }
        [DataMember]
        public string CompanyName { get; private set; }
        [DataMember]
        public string CompanyRegnum { get; private set; }
        [DataMember]
        public string CompanyVatnumber { get; private set; }
    }
}
