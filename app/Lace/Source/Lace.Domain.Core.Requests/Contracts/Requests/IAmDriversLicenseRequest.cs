namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmDriversLicenseRequest : IPointToLaceRequest
    {
        IHaveDriversLicense DriversLicense { get; }
    }
}
