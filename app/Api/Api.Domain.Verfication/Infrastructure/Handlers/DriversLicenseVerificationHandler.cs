using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Commands;
using Api.Domain.Verification.Infrastructure.Handlers.Contracts;

namespace Api.Domain.Verification.Infrastructure.Handlers
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