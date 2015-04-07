using System;
using System.Collections.Generic;
using System.Reflection;
using Api.Domain.Infrastructure.Dto;
using Api.Domain.Infrastructure.Requests;
using Lace.Domain.Core.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NHibernate.Util;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts;
using PackageBuilder.Domain.Entities.Contracts.Actions;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Write;

namespace Api.Domain.Infrastructure.Extensions
{
    public static class PackageExtensions
    {
        public static IPackage ToPackage(this string json)
        {
            try
            {
                var contractResolver = new DefaultContractResolver();
                contractResolver.DefaultMembersSearchFlags |= BindingFlags.NonPublic;

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Converters = new List<JsonConverter>
                    {
                        new CustomConverter<IAction, Action>(),
                        new CustomConverter<IIndustry, Industry>(),
                        new CustomConverter<ICriteria, Criteria>(),
                        new CustomConverter<IDataField, DataField>(),
                        new CustomConverter<IDataProvider, DataProvider>(),
                    }
                };

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

        public static IPointToLaceRequest ToLicensePlateSearchRequest(this IPackage package, Guid userId,
            string userName,
            string searchTerm, string firstName, Guid requestId, string accountNumber, long contractVersion,
            Guid contractId, DeviceTypes fromDevice, string ipAddress, string osVersion, SystemType system)
        {
            var request = new LicensePlateRequest(new User(userId, userName, firstName),
                new Vehicle(string.Empty, searchTerm, string.Empty, string.Empty, string.Empty, string.Empty),
                new Contract(contractVersion, accountNumber, contractId),
                new RequestPackage(package.Action.Name, GetDataProviderNames(package.DataProviders), package.Id,
                    package.Name, (long) package.DisplayVersion),
                new RequestContext(requestId, fromDevice, ipAddress, osVersion, system)
                , DateTime.Now);

            return request;
        }

        public static IPointToLaceRequest ToPropertySearchRequest(this IPackage package, Guid userId, string idNumber,
            int rowsToReturn, string trackingNumber, Guid requestId, string accountNumber, long contractVersion,
            Guid contractId, DeviceTypes fromDevice, string ipAddress, string osVersion, SystemType system)
        {
            var request = new PropertyRequest(
                new Property(trackingNumber, rowsToReturn, userId, idNumber),
                new User(userId, string.Empty, string.Empty),
                new Contract(contractVersion, accountNumber, contractId),
                new RequestPackage(package.Action.Name, GetDataProviderNames(package.DataProviders), package.Id,
                    package.Name,
                    (long) package.DisplayVersion),
                new RequestContext(requestId, fromDevice, ipAddress, osVersion, system), DateTime.Now);
            return request;
        }

        public static IPointToLaceRequest ToBusinessSearchRequest(this Package package, string userToken,
            string companyName, string companyRegNumber, string companyVatNumber, Guid requestId)
        {
            var request = new BusinessRequest();
            return request;
        }

        private static DataProviderName[] GetDataProviderNames(IEnumerable<IDataProvider> dataProviders)
        {
            var names = new List<DataProviderName>();
            dataProviders
                .ForEach(f => names.Add(f.Name));
            return names.ToArray();
        }
    }

    public class CustomConverter<I, T> : CustomCreationConverter<I>
    {
        public override I Create(Type objectType)
        {
            return (I) Activator.CreateInstance(typeof (T));
        }
    }
}
