using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Commands;

namespace Api.Domain.Verification.Infrastructure.Handlers.Contracts
{
    public interface IHandleDriversLicenseVerficationRequests
    {
        IHaveDriversLicenseResponse Response { get; }
        void Handle(DriversLicenseVerficationCommand command);
    }
}
