using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Commands;

namespace Api.Domain.Verification.Infrastructure.Handlers.Contracts
{
    public interface IHandleFicaVerficationRequests
    {
        IHaveFicaVerficationResponse FicaVerficationResponse { get; }
        void Handle(VerifyPersonsFicaInformationCommand command);
    }
}
