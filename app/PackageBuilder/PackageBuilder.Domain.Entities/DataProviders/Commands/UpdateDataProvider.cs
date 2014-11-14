using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;
using IDataField = PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class UpdateDataProvider : DomainCommand
    {
        public readonly DataProviderName Name;
        public readonly string Description;
        public readonly double CostOfSale;
        public readonly string SourceURL;
        public readonly Type ResponseType;
        public bool FieldLevelCostPriceOverride;
        public readonly State State;
        public readonly int Version;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly Type DataProviderType;
        public readonly IEnumerable<IDataField> DataFields;

        public UpdateDataProvider(Guid id, DataProviderName name, string description, double costOfSale, string sourceUrl, Type responseType, bool fieldLevelCostPriceOverride, State state, int version, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataField> dataFields)       
        {
            Id = id;
            Name = name;
            Description = description;
            CostOfSale = costOfSale;
            SourceURL = sourceUrl;
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
    }
}
