using System;
using System.Linq;
using Api.Domain.Infrastructure.Dto;
using Api.Domain.Infrastructure.Requests;
using AutoMapper;
using Billing.Api.Connector;
using Billing.Api.Dtos;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Identifiers;
using Lace.Domain.Infrastructure.Core.Contracts;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class IndexModule : SecureModule
    {
        public IndexModule(IPackageBuilderApiClient packageBuilderApi, IEntryPoint entryPoint,
            IConnectToBilling billingConnector, IUserManagementApiClient userManagementApi)
        {
            Get["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = packageBuilderApi.Get<ApiMetaData>(token, "getUserMetaData");

                return Response.AsJson(metaData);
            };

            Post["/action/SearchUsingLicensePlateNumber"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();

                if (string.IsNullOrEmpty(token))
                    return Response.AsJson(new {});

                var apiRequest = this.Bind<ApiRequestDto>();

                var packageDetails = userManagementApi.Post<ContractResponse>(token, "/Contracts/GetPackage",
                    new {ContractId = apiRequest.ContractId});

                if (packageDetails == null)
                    return Response.AsJson(new {});

                var packageResponse = packageBuilderApi.Get(token, "Packages/Package/" + packageDetails.Package.Id);

                //TODO: Mapping is not working
                var package = Mapper.DynamicMap<IPackage>(packageResponse);
                //var vehicle = this.Bind<Vehicle>();
                var request = new LaceRequest();

                request.LicensePlateNumberRequest(package,
                    new User("pennyl@lightstone.co.za", "Penny", new Guid("4A17B499-845F-43E2-AA2F-CFCB06920AB6"), null,
                        null, null), new Context(package.Name, null, "c99ef6d2-fdea-4a81-b15f-ff8251ac9050"),
                    new Vehicle(string.Empty, apiRequest.SearchTerm, string.Empty, string.Empty, string.Empty,
                        string.Empty),
                    new Aggregation(Guid.NewGuid()));

                var responses = entryPoint.GetResponsesFromLace(request);

                var packageIdentifier = new PackageIdentifier(package.Id, new VersionIdentifier(1));
                var requestIdentifier = new RequestIdentifier(Guid.NewGuid(), SystemIdentifier.CreateApi());
                var userIdentifier = new UserIdentifier(((IEntity) Context.CurrentUser).Id);
                var transactionContext = new TransactionContext(Guid.NewGuid(), userIdentifier, requestIdentifier);
                var createTransaction = new CreateTransaction(packageIdentifier, transactionContext);


                billingConnector.CreateTransaction(createTransaction);

                return Response.AsJson(responses.First().Response);
            };
        }
    }
}