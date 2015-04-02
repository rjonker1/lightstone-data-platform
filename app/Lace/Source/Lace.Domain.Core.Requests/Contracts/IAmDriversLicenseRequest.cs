namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmDriversLicenseRequest : IPointToLaceRequest
    {
        IHaveDriversLicense DriversLicense { get; }
    }
}
