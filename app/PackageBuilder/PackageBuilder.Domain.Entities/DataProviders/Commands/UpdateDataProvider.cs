﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Helpers.Json;
using Newtonsoft.Json;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class UpdateDataProvider : DomainCommand
    {
        public readonly DataProviderName Name;
        public readonly string Description;
        public readonly decimal CostOfSale;
        public readonly Type ResponseType;
        public bool FieldLevelCostPriceOverride;
        public readonly State State;
        public readonly int Version;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly Type DataProviderType;
        [JsonConverter(typeof(JsonConcreteTypeConverter<IEnumerable<DataField>>))]
        public readonly IEnumerable<IDataField> DataFields;

        public UpdateDataProvider(Guid id, DataProviderName name, string description, decimal costOfSale, Type responseType, bool fieldLevelCostPriceOverride, State state, int version, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataField> dataFields)
            : base(id)
        {
            Name = name;
            Description = description;
            CostOfSale = costOfSale;
            ResponseType = responseType;
            FieldLevelCostPriceOverride = fieldLevelCostPriceOverride;
            State = state;
            EditedDate = editedDate;
            Version = version;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataFields = dataFields;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(Id, Name, GetType());
        }
    }
}
