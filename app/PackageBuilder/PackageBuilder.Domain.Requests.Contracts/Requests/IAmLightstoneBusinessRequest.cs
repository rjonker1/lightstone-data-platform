using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmLightstoneBusinessRequest : IAmDataProviderRequest
    {
        IAmUserTokenRequestField UserToken { get; }
        IAmCompanyNameRequestField CompanyName { get; }
        IAmCompanyRegistrationNumberRequestField CompanyRegistrationNumber { get; }
        IAmCompanyVatNumberRequestField CompanyVatNumber { get; }
    }
}