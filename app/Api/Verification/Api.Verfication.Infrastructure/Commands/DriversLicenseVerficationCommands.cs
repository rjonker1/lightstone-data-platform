using Lace.Domain.Core.Requests.Contracts;

namespace Api.Verfication.Infrastructure.Commands
{
    public class DriversLicenseVerficationCommand
    {
        //public readonly IHaveDriversLicenseRequest Request;
        //public readonly IPackage Package;
        public readonly ILaceRequest Request;

        public DriversLicenseVerficationCommand(ILaceRequest request)
        {
            Request = request;
        }
    }
}