using System;
using System.Collections.Generic;
using System.Reflection;
using Api.Domain.Infrastructure.Dto;
using Api.Domain.Infrastructure.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NHibernate.Linq.Functions;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Api.Domain.Infrastructure.Extensions
{
    public static class PackageExtensions
    {
        public static Package ToPackage(this string json)
        {
            try
            {

                var actionConverter = new ActionDataConverter(typeof (Action));
                var criteriaConverter = new CriteriaDataConverter(typeof (Criteria));
                var dataFieldConverter = new DataFieldDataConverter(typeof (DataField));
                var dataProviderConverter =
                    new DataProviderDataConverter(
                        typeof (PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider));
                var contractResolver = new DefaultContractResolver();
                contractResolver.DefaultMembersSearchFlags |= BindingFlags.NonPublic;

                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    Converters = new List<JsonConverter>()
                    {
                        actionConverter,
                        criteriaConverter,
                        dataFieldConverter,
                        dataProviderConverter
                    }
                };
                //settings.Converters.Add(actionConverter);
                //settings.Converters.Add(criteriaConverter);
                //settings.Converters.Add(dataFieldConverter);
                //settings.Converters.Add(dataProviderConverter);

                var dto = JsonConvert.DeserializeObject<PackageResponseDto>(
                    json, settings);

                return new Package(dto.Id, dto.Name, dto.Action, dto.DataProviders);
            }
            catch
            {
                return null;
            }
        }

        private class Action : IAction
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public ICriteria Criteria { get; set; }
        }

        public static ILaceRequest ToLicensePlateSearchRequest(this Package package, Guid userId, string userName,
            string searchTerm, string firstName, Guid requestId)
        {
            var request = new LaceRequest();

            request.LicensePlateNumberRequest(package,
                new Requests.User(userId, userName, firstName), new Context(package.Name, null),
                new Vehicle(string.Empty, searchTerm, string.Empty, string.Empty, string.Empty,
                    string.Empty),
                new Aggregation(requestId));

            return request;
        }

        public static ILaceRequest ToPropertySearchRequest(this Package package, Guid userId, string idNumber,
            int rowsToReturn, string trackingNumber, Guid requestId)
        {
            var request = new LaceRequest();
            request.PropertyRequest(package, new Api.Domain.Infrastructure.Requests.User(userId, string.Empty, string.Empty),
                new Property(trackingNumber, rowsToReturn, userId, idNumber), new Aggregation(requestId));
            return request;
        }
    }

    public class EntityConverter : CustomCreationConverter<PackageBuilder.Core.Entities.IEntity>
    {
        public Type Type { get; private set; }

        public EntityConverter(Type type)
        {
            Type = type;
        }

        public override IEntity Create(Type objectType)
        {
            return (IEntity) Activator.CreateInstance(Type);
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
            return (ICriteria) Activator.CreateInstance(Type);
        }
    }

    public class DataFieldDataConverter :
        CustomCreationConverter<IDataField>
    {
        public Type Type { get; private set; }

        public DataFieldDataConverter(Type type)
        {
            Type = type;
        }

        public override IDataField Create(Type objectType)
        {
            return (IDataField) Activator.CreateInstance(Type);
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
            return
                (PackageBuilder.Domain.Entities.DataProviders.WriteModels.IDataProvider) Activator.CreateInstance(Type);
        }
    }
}
