
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmXdsIdentificationVerificationRequest : IAmDataProviderRequest
    {
        IAmIdentityNumberRequestField IdNumber { get; }
        IAmCellularNumberRequestField CellularNumber { get; }
        IAmAccountNumberRequestField AccountNumber { get; }
    }
}
