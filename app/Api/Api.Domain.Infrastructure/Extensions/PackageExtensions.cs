using System;
using Api.Domain.Infrastructure.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
                var settings = new JsonSerializerSettings();
                var actionConverter = new ActionDataConverter(typeof (PackageBuilder.Domain.Entities.Action));
                var criteriaConverter = new CriteriaDataConverter(typeof (Criteria));
                var dataFieldConverter = new DataFieldDataConverter(typeof (DataField));
                var dataProviderConverter =
                    new DataProviderDataConverter(
                        typeof (PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider));

                settings.Converters.Add(actionConverter);
                settings.Converters.Add(criteriaConverter);
                settings.Converters.Add(dataFieldConverter);
                settings.Converters.Add(dataProviderConverter);

                return JsonConvert.DeserializeObject<Package>(
                    json, settings);

            }
            catch
            {
                return null;
            }
        }

        public static ILaceRequest ToLicensePlateSearchRequest(this Package package, Guid userId, string userName, string searchTerm, string firstName)
        {
            var request = new LaceRequest();

            request.LicensePlateNumberRequest(package,
                new Requests.User(userId, userName, firstName), new Context(package.Name, null),
                new Vehicle(string.Empty, searchTerm, string.Empty, string.Empty, string.Empty,
                    string.Empty),
                new Aggregation(Guid.NewGuid()));

            return request;
        }
    }

    internal class ActionDataConverter : CustomCreationConverter<IAction>
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

    internal class CriteriaDataConverter : CustomCreationConverter<ICriteria>
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

    internal class DataFieldDataConverter :
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

    internal class DataProviderDataConverter :
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
