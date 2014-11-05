﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.Packages.Events
{
    public class PackageCreated : DomainEvent
    {
        public readonly string Name;
        public readonly string Description;
        public readonly double CostPrice;
        public readonly double SalePrice;
        public readonly State State;
        public readonly decimal DisplayVersion;
        public readonly string Owner;        
        public readonly DateTime CreatedDate;
        public readonly DateTime? EditedDate;
        public readonly IEnumerable<IDataProvider> DataProviders;

        public PackageCreated(Guid id, string name, string description, double costPrice, double salePrice, State state, decimal displayVersion, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataProvider> dataProviders)
        {
            Id = id;
            Name = name;
            Description = description;
            CostPrice = costPrice;
            SalePrice = salePrice;
            State = state;
            DisplayVersion = displayVersion;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataProviders = dataProviders;
        }
    }
}