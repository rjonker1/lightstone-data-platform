using Api.Verfication.Core.Contracts;

namespace Api.Verfication.Infrastructure.Commands
{
    public class DriversLicenseVerficationCommand
    {
        public readonly IHaveDriversLicenseRequest Request;

        public DriversLicenseVerficationCommand(IHaveDriversLicenseRequest request)
        {
            Request = request;
        }
    }
}