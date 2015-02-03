using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Handlers.Contracts;

namespace Api.Verfication.Infrastructure.Handlers
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