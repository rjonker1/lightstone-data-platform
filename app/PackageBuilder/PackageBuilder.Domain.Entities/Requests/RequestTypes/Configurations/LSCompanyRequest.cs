using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class LightstoneCompanyRequest : IAmLightstoneBusinessCompanyRequest
    {
        public LightstoneCompanyRequest(ICollection<IAmRequestField> requestFields)
        {
            CompanyName = requestFields.GetRequestField<IAmCompanyNameRequestField>();
            CompanyRegistrationNumber = requestFields.GetRequestField<IAmCompanyRegistrationNumberRequestField>();
            CompanyVatNumber = requestFields.GetRequestField<IAmCompanyVatNumberRequestField>();
        }
        public IAmCompanyNameRequestField CompanyName { get; private set; }
        public IAmCompanyRegistrationNumberRequestField CompanyRegistrationNumber { get; private set; }
        public IAmCompanyVatNumberRequestField CompanyVatNumber { get; private set; }
    }
}