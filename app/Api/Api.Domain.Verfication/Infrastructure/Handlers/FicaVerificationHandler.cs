using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Commands;
using Api.Domain.Verification.Infrastructure.Handlers.Contracts;

namespace Api.Domain.Verification.Infrastructure.Handlers
{
    public class FicaVerificationHandler : IHandleFicaVerficationRequests
    {
        public IHaveFicaVerficationResponse FicaVerficationResponse { get; private set; }

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