using Api.Scans.Verfication.Core.Contracts;
using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Infrastructure.Handlers
{
    public class DriversLicenseVerificationHandler : IHandleDriversLicenseVerficationRequests
    {
        public DriversLicenseResponseDto Response { get; private set; }

        private readonly ICallDriversLicenseVerification _service;

        public DriversLicenseVerificationHandler(ICallDriversLicenseVerification service)
        {
            _service = service;
        }

        public void Handle(DriversLicenseVerficationCommand command)
        {
            Response = _service.DecodeDriversLincenseFromScan(command.Request);
        }
    }
}