using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Dto
{
    public class CompanyRequest
    {
        private readonly IAmLightstoneBusinessRequest _request;
        public CompanyRequest(IAmLightstoneBusinessRequest request)
        {
            _request = request;
        }

        public CompanyRequest Map()
        {
           // IdNumber = GetValue(_request.IdNumber);
            CompanyName = GetValue(_request.CompanyName);
            CompanyRegnum = GetValue(_request.CompanyRegistrationNumber);
            CompanyVatnumber = GetValue(_request.CompanyVatNumber);
            return this;
        }

        public CompanyRequest Validate()
        {
            IsValid = !string.IsNullOrEmpty(IdNumber);
            return this;
        }

        private static string GetValue(IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }

        public bool IsValid { get; private set; }

        public string IdNumber { get; private set; }

        public string CompanyName { get; private set; }

        public string CompanyRegnum { get; private set; }


        public string CompanyVatnumber { get; private set; }
    }
}
