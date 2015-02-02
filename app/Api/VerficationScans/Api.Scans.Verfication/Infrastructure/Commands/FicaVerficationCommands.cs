using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Infrastructure.Commands
{
    public class VerifyPersonsFicaInformationCommand
    {
        public readonly FicaVerficationRequestDto Request;

        public VerifyPersonsFicaInformationCommand(FicaVerficationRequestDto request)
        {
            Request = request;
        }
    }
}