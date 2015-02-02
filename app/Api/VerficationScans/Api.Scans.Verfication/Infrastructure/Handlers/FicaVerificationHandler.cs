using Api.Scans.Verfication.Core.Contracts;
using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Infrastructure.Handlers
{
    public class FicaVerificationHandler : IHandleFicaVerficationRequests
    {
        public FicaVerficationResponseDto FicaVerficationResponse { get; private set; }

        private readonly ICallFicaVerification _service;

        public FicaVerificationHandler(ICallFicaVerification service)
        {
            _service = service;
        }

        public void Handle(VerifyPersonsFicaInformationCommand command)
        {
            FicaVerficationResponse = _service.GetFicaInformationForPerson(command.Request);
        }
    }
}