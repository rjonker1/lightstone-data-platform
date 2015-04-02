using System;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveDriversLicenseInformation
    {
        string ScanData { get; }
        string RegistrationCode { get; }
        string Username { get; }
        Guid UserId { get; }
    }
}
