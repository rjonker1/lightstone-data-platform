namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideDriversLicenseInformationForRequest
    {
        string ScanData { get; }
        string RegistrationCode { get; }
        string Username { get; }
        string UserId { get; }
    }
}
