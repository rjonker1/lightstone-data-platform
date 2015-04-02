namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmDriversLicenseRequest : IPointToLaceRequest
    {
        IHaveDriversLicenseInformation DriversLicense { get; }
    }
}
