using Api.Verfication.Core.Contracts;

namespace Api.Verfication.Infrastructure.Commands
{
    public class VerifyPersonsFicaInformationCommand
    {
        public readonly IHaveFicaVerficationRequest Request;

        public VerifyPersonsFicaInformationCommand(IHaveFicaVerficationRequest request)
        {
            Request = request;
        }
    }
}