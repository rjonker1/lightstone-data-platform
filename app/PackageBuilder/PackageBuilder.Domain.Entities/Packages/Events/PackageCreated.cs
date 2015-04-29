using System;
using System.Collections.Generic;
using PackageBuilder.Core.Events;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageCreated : DomainEvent
    {
        public readonly string Name;
        public readonly string Description;
        public readonly decimal CostPrice;
        public readonly decimal SalePrice;
        public string Notes;
        public readonly IEnumerable<Industry> Industries;
        public readonly State State;
        public readonly decimal DisplayVersion;
        public readonly string Owner;        
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly IEnumerable<IDataProviderOverride> DataProviderValueOverrides;

        public PackageCreated(Guid id, string name, string description, decimal costPrice, decimal salePrice, IEnumerable<Industry> industries, State state, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProviderOverride> dataProviderValueOverrides)
        {
            Id = id;
            Name = name;
            Description = description;
            Industries = industries;
            CostPrice = costPrice;
            SalePrice = salePrice;
            State = state;
            DisplayVersion = displayVersion;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataProviderValueOverrides = dataProviderValueOverrides;
        }
    }
}