using Lace.Domain.Core.Requests.Contracts;

namespace Api.Domain.Verification.Infrastructure.Commands
{
    public class DriversLicenseVerficationCommand
    {
        public readonly ILaceRequest Request;

        public DriversLicenseVerficationCommand(ILaceRequest request)
        {
            Request = request;
        }
    }
}