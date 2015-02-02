using Api.Scans.Verfication.Infrastructure.Dto;

namespace Api.Scans.Verfication.Infrastructure.Commands
{
    public class DriversLicenseVerficationCommand
    {
        public readonly DriversLicenseRequestDto Request;

        public DriversLicenseVerficationCommand(DriversLicenseRequestDto request)
        {
            Request = request;
        }
    }
}