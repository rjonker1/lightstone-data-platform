﻿using System;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Dto;
using Api.Verfication.Infrastructure.Handlers.Contracts;
using Lace.Shared.Extensions;
using Nancy.ModelBinding;

namespace Api.Modules.Verification
{
    public class DriversLicenseVerficationModule : VerificationSecureModule
    {
        public DriversLicenseVerficationModule(IHandleDriversLicenseVerficationRequests handler)
        {

            Get["/driversLicenseVerification"] =
                _ => new
                {
                    _request,
                    _response
                }.AsJsonString();

            Post["/driversLicenseVerification/"] = _ =>
            {
                var request = this.Bind<DriversLicenseRequestDto>();
                handler.Handle(new DriversLicenseVerficationCommand(request));
                return handler.Response.AsJsonString();
            };
        }

        private readonly IHaveDriversLicenseResponse _response =
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

        private readonly IHaveDriversLicenseRequest _request = new DriversLicenseRequestDto(string.Empty, string.Empty, string.Empty, Guid.Empty);
    }
}