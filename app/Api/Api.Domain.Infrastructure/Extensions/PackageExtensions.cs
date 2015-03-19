using System;
using System.Collections.Generic;
using System.Reflection;
using Api.Domain.Infrastructure.Dto;
using Api.Domain.Infrastructure.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts;
using PackageBuilder.Domain.Entities.Contracts.Actions;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Write;

namespace Api.Domain.Infrastructure.Extensions
{
    public static class PackageExtensions
    {
        public static Package ToPackage(this string json)
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

    public class CustomConverter<I, T> : CustomCreationConverter<I>
    {
        public override I Create(Type objectType)
        {
            return (I) Activator.CreateInstance(typeof(T));
        }
    }
}
