using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class UpdateDataProvider : DomainCommand
    {
        public readonly DataProviderName Name;
        public readonly string Description;
        public readonly double CostOfSale;
        public readonly string SourceURL;
        public readonly Type ResponseType;
        public readonly State State;
        public readonly int Version;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime EditedDate;
        public readonly Type DataProviderType;
        public readonly IEnumerable<IDataField> DataFields;

        public UpdateDataProvider(Guid id, DataProviderName name, string description, double costOfSale, string sourceUrl, Type responseType, State state, int version, string owner, DateTime createdDate, IEnumerable<IDataField> dataFields)
            
        {
            Id = id;
            Name = name;
            Description = description;
            CostOfSale = costOfSale;
            SourceURL = sourceUrl;
            ResponseType = responseType;
            State = state;
            Version = version;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = createdDate;
            DataFields = dataFields;
        }
    }
}
