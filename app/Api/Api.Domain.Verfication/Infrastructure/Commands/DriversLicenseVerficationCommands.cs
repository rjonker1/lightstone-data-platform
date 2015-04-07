using Lace.Domain.Core.Requests.Contracts;

namespace Api.Domain.Verification.Infrastructure.Commands
{
    public class DriversLicenseVerficationCommand
    {
        public readonly IAmDriversLicenseRequest Request;

        public DriversLicenseVerficationCommand(IAmDriversLicenseRequest request)
        {
            Request = request;
        }
    }
}