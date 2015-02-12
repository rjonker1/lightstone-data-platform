using Api.Domain.Verification.Core.Contracts;
namespace Api.Domain.Verification.Infrastructure.Commands
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