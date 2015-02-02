using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Core.Contracts
{
    public interface IHandleFicaVerficationRequests
    {
        FicaVerficationResponseDto FicaVerficationResponse { get; }
        void Handle(VerifyPersonsFicaInformationCommand command);
    }
}
