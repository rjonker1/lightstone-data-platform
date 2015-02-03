using System;
using Api.Extensions;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Dto;
using Api.Verfication.Infrastructure.Handlers.Contracts;
using Nancy.ModelBinding;

namespace Api.Modules.Verification
{
    public class DriversLicenseVerficationModule : VerificationSecureModule
    {
        public DriversLicenseVerficationModule(IHandleDriversLicenseVerficationRequests handler)
        {

            Get["/driversLicenseVerification"] =
                _ =>
                    _metaData;

            Post["/driversLicenseVerification/"] = _ =>
            {
                var request = this.Bind<IHaveDriversLicenseRequest>();
                handler.Handle(new DriversLicenseVerficationCommand(request));
                return handler.Response.AsJsonString();
            };
        }

        private readonly Func<IHaveDriversLicenseResponse> _metaData = () =>
            new DriversLicenseResponseDto(new DrivingLicenseCard(new IdentityDocument(string.Empty, string.Empty),
                new Person(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty),
                new DrivingLicense(string.Empty, string.Empty),
                new Card(string.Empty, string.Empty, string.Empty),
                new ProfessionalDrivingPermit(string.Empty, string.Empty),
                new VehicleClass(string.Empty, string.Empty, string.Empty),
                new VehicleClass(string.Empty, string.Empty, string.Empty),
                new VehicleClass(string.Empty, string.Empty, string.Empty),
                new VehicleClass(string.Empty, string.Empty, string.Empty),
                string.Empty, string.Empty, string.Empty), string.Empty);
    }
}