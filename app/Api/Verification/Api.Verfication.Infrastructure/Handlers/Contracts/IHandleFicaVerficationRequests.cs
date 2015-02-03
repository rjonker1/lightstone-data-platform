using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;

namespace Api.Verfication.Infrastructure.Handlers.Contracts
{
    public interface IHandleFicaVerficationRequests
    {
        IHaveFicaVerficationResponse FicaVerficationResponse { get; }
        void Handle(VerifyPersonsFicaInformationCommand command);
    }
}
