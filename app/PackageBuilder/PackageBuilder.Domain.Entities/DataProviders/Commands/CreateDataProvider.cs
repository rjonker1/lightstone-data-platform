using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Helpers.Json;
using Lace.Domain.Core.Contracts.Requests;
using Newtonsoft.Json;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class CreateDataProvider : DomainCommand
    {
        [JsonConverter(typeof(JsonTypeResolverConverter))]
        public IPointToLaceProvider DataProvider { get; set; }
        public readonly DataProviderName Name;
        public readonly string Description;
        public readonly decimal CostOfSale;
        public readonly Type ResponseType;
        public readonly State State;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly Type DataProviderType;

        public CreateDataProvider(IPointToLaceProvider dataProvider, Guid id, DataProviderName name, string description, decimal costOfSale, Type responseType, string owner, DateTime createdDate)
            : base(id)
        {
            DataProvider = dataProvider;
			Name = name;
            Description = description;
            CostOfSale = costOfSale;
            ResponseType = responseType;
            Owner = owner;
            CreatedDate = createdDate;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}