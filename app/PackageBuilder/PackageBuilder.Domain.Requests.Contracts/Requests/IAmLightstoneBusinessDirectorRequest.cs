using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmLightstoneBusinessDirectorRequest : IAmDataProviderRequest
    {
        IAmIdentityNumberRequestField IdNumber { get; }
        IAmFirstNameRequestField FirstName { get; }
        IAmSurnameRequestField Surname { get; }
        IAmCompanyVatNumberRequestField CompanyVatNumber { get; }
    }
}