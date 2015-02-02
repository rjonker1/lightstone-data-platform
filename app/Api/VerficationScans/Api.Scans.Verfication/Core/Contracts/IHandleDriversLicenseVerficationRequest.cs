using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Core.Contracts
{
    public interface IHandleDriversLicenseVerficationRequests
    {
        DriversLicenseResponseDto Response { get; }
        void Handle(DriversLicenseVerficationCommand command);
    }
}
