using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmLightstoneBusinessCompanyRequest : IAmDataProviderRequest
    {
        IAmIdentityNumberRequestField IdNumber { get; }
        IAmCompanyNameRequestField CompanyName { get; }
        IAmCompanyRegistrationNumberRequestField CompanyRegistrationNumber { get; }
        IAmCompanyVatNumberRequestField CompanyVatNumber { get; }
    }
}