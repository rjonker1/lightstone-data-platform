using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Handlers.Contracts;

namespace Api.Verfication.Infrastructure.Handlers
{
    public class DriversLicenseVerificationHandler : IHandleDriversLicenseVerficationRequests
    {
        public IHaveDriversLicenseResponse Response { get; private set; }

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