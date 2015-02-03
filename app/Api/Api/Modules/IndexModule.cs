using System;
using System.Linq;
using Api.Infrastructure.Requests;
using AutoMapper;
using Billing.Api.Connector;
using Billing.Api.Dtos;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Identifiers;
using Lace.Request.Entry;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Modules
{
    public class IndexModule : SecureModule
    {
        public IndexModule(IPbApiClient pbApiClient, IEntryPoint entryPoint, IConnectToBilling billingConnector)
        {
            Get["/"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var metaData = pbApiClient.Get<ApiMetaData>(token, "getUserMetaData");

                return Response.AsJson(metaData);
            };

            Post["/action/{action}"] = parameters =>
            {
                var token = Context.AuthorizationHeaderToken();
                var packageResponse = pbApiClient.Get<Package>(token, "package/" + parameters.action);

                var package = Mapper.DynamicMap<IPackage>(packageResponse);
                var vehicle = this.Bind<Vechicle>();
                var request = new LicensePlateNumberRequest(package, new User(), new Context(), vehicle, new AggregationInformation());
                var responses = entryPoint.GetResponsesFromLace(request);

                var packageIdentifier = new PackageIdentifier(packageResponse.Id, new VersionIdentifier(1));
                var requestIdentifier = new RequestIdentifier(Guid.NewGuid(), SystemIdentifier.CreateApi());
                var userIdentifier = new UserIdentifier(((IEntity)Context.CurrentUser).Id);
                var transactionContext = new TransactionContext(Guid.NewGuid(), userIdentifier, requestIdentifier);
                var createTransaction = new CreateTransaction(packageIdentifier, transactionContext);
                billingConnector.CreateTransaction(createTransaction);

                return Response.AsJson(responses.First().Response);
            };
        }
    }
}