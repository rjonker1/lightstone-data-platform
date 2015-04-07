using System;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveDriversLicense
    {
        string ScanData { get; }
        string RegistrationCode { get; }
        string Username { get; }
        Guid UserId { get; }
    }
}
