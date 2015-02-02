using System;
using Api.Scans.Verfication.Core.Contracts;
using Api.Scans.Verfication.Core.Extensions;
using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;
using Nancy.ModelBinding;

namespace Api.Scans.Verfication.Modules
{
    public class DriversLicenseVerficationModule : SecureModule
    {
        public DriversLicenseVerficationModule(IHandleDriversLicenseVerficationRequests handler)
        {

            Get["/driversLicenseVerification"] =
                _ =>
                    _metaData;

            Post["/driversLicenseVerification/"] = _ =>
            {
                var request = this.Bind<DriversLicenseRequestDto>();
                handler.Handle(new DriversLicenseVerficationCommand(request));
                return handler.Response.AsJsonString();
            };
        }

        private readonly Func<DriversLicenseResponseDto> _metaData = () =>
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