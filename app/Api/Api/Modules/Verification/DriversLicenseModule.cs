using System;
using System.Linq;
using Api.Domain.Infrastructure.Requests;
using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Fakes;
using Api.Domain.Verification.Infrastructure.Commands;
using Api.Domain.Verification.Infrastructure.Dto;
using Api.Domain.Verification.Infrastructure.Handlers.Contracts;
using Billing.Api.Connector;
using Billing.Api.Dtos;
using DataPlatform.Shared.Identifiers;
using Lace.Domain.Core.Requests.Contracts;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules.Verification
{
    public class DriversLicenseModule : VerificationModule
    {
        public DriversLicenseModule(IPbApiClient packageBuilderApi,
            IHandleDriversLicenseVerficationRequests handler, IConnectToBilling billingConnector)
        {

            Get["/driversLicense"] =
                _ => Response.AsJson(new
                {
                    _request,
                    _response
                });

            Post["/driversLicense/{packageId}/{packageVersion}"] = _ =>
            {
                var token = Context.AuthorizationHeaderToken();

                if (string.IsNullOrEmpty(token))
                    return Response.AsJson(new {});

                //var package = packageBuilderApi.Get<DataPlatform.Shared.Dtos.Package>(token, string.Format("Packages/{0}/{1}", _.packageId,_.packageVersion));
                var package = new FakePackageBuilderApi().PackageDatabase.First().Value;
                var request = this.Bind<DriversLicenseRequestDto>();

                handler.Handle(new DriversLicenseVerficationCommand(BuildLaceRequest(package, request)));

                var packageIdentifier = new PackageIdentifier(package.Id, new VersionIdentifier(1));
                var requestIdentifier = new RequestIdentifier(Guid.NewGuid(), SystemIdentifier.CreateApi());
                var userIdentifier = new UserIdentifier(new Guid(token));
                var transactionContext = new TransactionContext(Guid.NewGuid(), userIdentifier, requestIdentifier);
                var createTransaction = new CreateTransaction(packageIdentifier, transactionContext);
                billingConnector.CreateTransaction(createTransaction);


                return Response.AsJson(handler.Response);
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