using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.Security;
using User = Api.Domain.Infrastructure.Requests.User;

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


                //var package = Mapper.DynamicMap<IPackage>(packageResponse);
                var actionConverter = new ActionDataConverter(typeof(Api.Modules.Action));
                var criteriaConverter = new CriteriaDataConverter(typeof(Api.Modules.Criteria));
                var dataFieldConverter = new DataFieldDataConverter(typeof(Api.Modules.DataField));
                var dataProviderConverter = new DataProviderDataConverter(typeof(Api.Modules.DataProvider));

                var deserializationSettings = new JsonSerializerSettings();
                deserializationSettings.Converters.Add(actionConverter);
                deserializationSettings.Converters.Add(criteriaConverter);
                deserializationSettings.Converters.Add(dataFieldConverter);
                deserializationSettings.Converters.Add(dataProviderConverter);

                var package =
                    JsonConvert.DeserializeObject<PackageBuilder.Domain.Entities.Packages.WriteModels.Package>(
                        packageResponse, deserializationSettings);

                if (package == null)
                    throw new Exception("Package could not be resolved in the API");

                var request = new LaceRequest();

                request.LicensePlateNumberRequest(package,
                    new User("pennyl@lightstone.co.za", "Penny", new Guid("4A17B499-845F-43E2-AA2F-CFCB06920AB6"), null,
                        null, null), new Context(package.Name, null, "c99ef6d2-fdea-4a81-b15f-ff8251ac9050"),
                    new Vehicle(string.Empty, apiRequest.SearchTerm, string.Empty, string.Empty, string.Empty,
                        string.Empty),
                    new Aggregation(Guid.NewGuid()));

                var responses = entryPoint.GetResponsesFromLace(request);

                var packageIdentifier = new PackageIdentifier(package.Id, new VersionIdentifier(package.Version));
                var requestIdentifier = new RequestIdentifier(Guid.NewGuid(), SystemIdentifier.CreateApi());
                var userIdentifier = new UserIdentifier(new Guid(token));
                var transactionContext = new TransactionContext(Guid.NewGuid(), userIdentifier, requestIdentifier);
                var createTransaction = new CreateTransaction(packageIdentifier, transactionContext);


                billingConnector.CreateTransaction(createTransaction);

                return Response.AsJson(responses.First().Response);
            };
        }
    }

    public class ActionDataConverter : CustomCreationConverter<IAction>
    {
        public Type Type { get; private set; }
        public ActionDataConverter(Type type)
        {
            Type = type;
        }

        public override IAction Create(Type objectType)
        {
            return (IAction) Activator.CreateInstance(Type);
        }
    }

    public class CriteriaDataConverter : CustomCreationConverter<ICriteria>
    {
        public Type Type { get; private set; }
        public CriteriaDataConverter(Type type)
        {
            Type = type;
        }

        public override ICriteria Create(Type objectType)
        {
            return (ICriteria)Activator.CreateInstance(Type);
        }
    }

    public class DataFieldDataConverter :
        CustomCreationConverter<PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField>
    {
        public Type Type { get; private set; }

        public DataFieldDataConverter(Type type)
        {
            Type = type;
        }

        public override PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField Create(Type objectType)
        {
            return (PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField) Activator.CreateInstance(Type);
        }
    }

    public class DataProviderDataConverter :
        CustomCreationConverter<PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider>
    {
        public Type Type { get; private set; }

        public DataProviderDataConverter(Type type)
        {
            Type = type;
        }

        public override PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider Create(Type objectType)
        {
            return (PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider)Activator.CreateInstance(Type);
        }
    }

    public class Action : IAction
    {
        public ICriteria Criteria { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }

    public class Criteria : ICriteria
    {
        public IEnumerable<PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField> Fields { get; set; }
    }

    public class DataField : PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField
    {
        public double CostOfSale { get; set; }
        public IEnumerable<PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField> DataFields { get; set; }

        public string Definition { get; set; }

        public IEnumerable<PackageBuilder.Domain.Entities.Industries.WriteModels.Industry> Industries { get; set; }

        public bool? IsSelected { get; set; }

        public string Label { get; set; }

        public string Namespace { get; set; }

        public int Order { get; set; }

        public void OverrideValuesFromPackage(double costPrice, bool? selected)
        {
            
        }

        public Type Type { get; set; }

        public string Name { get; set; }
    }

    public class DataProvider : PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider
    {

        public double CostOfSale { get; set; }

        public DateTime CreatedDate { get; set; }

        public IEnumerable<PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField> DataFields { get; set; }

        public string Description { get; set; }

        public DateTime? EditedDate { get; set; }

        public bool FieldLevelCostPriceOverride { get; set; }

        public Guid Id { get; set; }

        public DataPlatform.Shared.Enums.DataProviderName Name { get; set; }

        public void OverrideCostValuesFromPackage(double costOfSale)
        {
            
        }

        public string Owner { get; set; }

        public Type ResponseType { get; set; }

        public PackageBuilder.Domain.Entities.DataProviders.WriteModels.SourceConfiguration SourceConfiguration { get; set; }

        public int Version { get; set; }
    }
}