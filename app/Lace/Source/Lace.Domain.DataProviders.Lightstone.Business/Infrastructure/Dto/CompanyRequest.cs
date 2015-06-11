using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Dto
{
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
            CompanyName = GetValue(_request.CompanyName);
            CompanyRegnum = GetValue(_request.CompanyRegistrationNumber);
            CompanyVatnumber = GetValue(_request.CompanyVatNumber);
            return this;
        }

        public CompanyRequest Validate()
        {
            IsValid = !string.IsNullOrEmpty(CompanyName) || !string.IsNullOrEmpty(CompanyRegnum) || !string.IsNullOrEmpty(CompanyVatnumber);
            return this;
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }

        public bool IsValid { get; private set; }

        //public string IdNumber { get; private set; }

        public string CompanyName { get; private set; }

        public string CompanyRegnum { get; private set; }


        public string CompanyVatnumber { get; private set; }
    }
}
