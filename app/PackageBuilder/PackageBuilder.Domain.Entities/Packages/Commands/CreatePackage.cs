using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Helpers.Json;
using Newtonsoft.Json;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.Packages.Commands
{
    public class CreatePackage : DomainCommand
    {
        public readonly string Name;
        public readonly string Description;
        public readonly decimal CostPrice;
        public readonly decimal SalePrice;
        public readonly string Notes;
        public readonly PackageEventType? PackageEventType;
        public readonly IEnumerable<Industry> Industries;
        public readonly State State;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        [JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataProviderOverride>>))]
        public readonly IEnumerable<IDataProviderOverride> DataProviderValueOverrides;

        public CreatePackage(Guid id, string name, string description, decimal costPrice, decimal salePrice, string notes, PackageEventType? packageEventType, IEnumerable<Industry> industries, State state, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviderValueOverrides)
            : base(id)
        {
            Name = name;
            Description = description;
            CostPrice = costPrice;
            SalePrice = salePrice;
            Notes = notes;
            PackageEventType = packageEventType;
            Industries = industries;
            State = state;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataProviderValueOverrides = dataProviderValueOverrides;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}