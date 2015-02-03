using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;

namespace Api.Verfication.Infrastructure.Handlers.Contracts
{
    public interface IHandleDriversLicenseVerficationRequests
    {
        IHaveDriversLicenseResponse Response { get; }
        void Handle(DriversLicenseVerficationCommand command);
    }
}
