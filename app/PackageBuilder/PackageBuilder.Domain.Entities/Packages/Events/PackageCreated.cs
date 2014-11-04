﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageCreated : DomainEvent
    {
        public readonly string Name;
        public readonly string Description;
        public readonly double CostPrice;
        public readonly double SalePrice;
        public readonly string State;
        public readonly string Owner;        
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly IEnumerable<IDataProvider> DataProviders;

        public PackageCreated(Guid id,string name, string description, double costPrice, double salePrice, string state, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProvider> dataProviders)
        {
            Id = id;
            Name = name;
            Description = description;
            CostPrice = costPrice;
            SalePrice = salePrice;
            State = state;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataProviders = dataProviders;
        }
    }
}