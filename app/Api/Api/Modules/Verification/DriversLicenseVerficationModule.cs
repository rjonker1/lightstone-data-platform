using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Infrastructure.Requests;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Fakes;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Dto;
using Api.Verfication.Infrastructure.Handlers.Contracts;
using AutoMapper;
using Billing.Api.Connector;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Shared.Extensions;
using Nancy.ModelBinding;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules.Verification
{
    public class DriversLicenseVerficationModule : VerificationSecureModule
    {
        public DriversLicenseVerficationModule(IPbApiClient packageBuilderApi,
            IHandleDriversLicenseVerficationRequests handler, IConnectToBilling billingConnector)
        {

            Get["/driversLicenseVerification"] =
                _ => new
                {
                    _request,
                    _response
                }.AsJsonString();

            Post["/driversLicenseVerification/{packageId}/{packageVersion}"] = _ =>
            {
                var token = Context.AuthorizationHeaderToken();


                //var packageResponse = packageBuilderApi.Get<DataPlatform.Shared.Dtos.Package>(token, string.Format("Packages/{0}/{1}", _.packageId,_.packageVersion));
                //test package id = "EB49A837-D9E3-4F2A-8DC9-2CB0BB5D48E2"
                var package = new FakePackageBuilderApi().PackageDatabase.First().Value;
                var request = this.Bind<DriversLicenseRequestDto>();

                handler.Handle(new DriversLicenseVerficationCommand(BuildLaceRequest(package, request)));


                //TODO: implement billing

                return handler.Response.AsJsonString();
            };
        }
        

        private static ILaceRequest BuildLaceRequest(IPackage package, IHaveDriversLicenseRequest request)
        {
            var laceRequest = new LaceRequest();
            laceRequest.DriversLicenseRequest(package,
                new DriversLicense(null, request.ScanData, request.UserId, request.Username),
                new Aggregation(Guid.NewGuid()));
            return laceRequest;
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

        private readonly IHaveDriversLicenseRequest _request = new DriversLicenseRequestDto(string.Empty, string.Empty,
            string.Empty, Guid.Empty);


    }
}