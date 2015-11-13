using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Helpers.Json;
using Newtonsoft.Json;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class CreateDataProvider : DomainCommand
    {
        [JsonConverter(typeof(JsonTypeResolverConverter))]
        public readonly DataProviderName Name;
        public readonly string Description;
        public readonly decimal CostOfSale;
        public readonly string Owner;
        public readonly DateTime CreatedDate;

        public CreateDataProvider(Guid id, DataProviderName name, decimal costOfSale, string owner, DateTime createdDate)
            : base(id)
        {
			Name = name;
            Description = name.ToString();
            CostOfSale = costOfSale;
            Owner = owner;
            CreatedDate = createdDate;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}