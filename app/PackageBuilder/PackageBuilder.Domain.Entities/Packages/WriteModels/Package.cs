using System;
using System.Collections.Generic;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.Packages.Events;

namespace PackageBuilder.Domain.Entities.Packages.WriteModels
{
    public class Package : AggregateBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double CostPrice { get; private set; }
        public double SalePrice { get; private set; }
        public string State { get; private set; }
        public string Owner { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime EditedDate { get; private set; }
        public IEnumerable<IDataProvider> DataProviders { get; private set; }

        private Package(Guid id)
        {
            Id = id;
        }

        protected Package() { }

        public Package(Guid id, string name, string description, double costPrice, double salePrice, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataProvider> dataProviders)
            : this(id)
        {
            RaiseEvent(new PackageCreated(id, name, description, costPrice, salePrice, state,  owner, createdDate, editedDate, dataProviders));
        }

        private void Apply(PackageCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostPrice = @event.CostPrice;
            SalePrice = @event.CostPrice;
            State = @event.State;
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
            EditedDate = @event.EditedDate;
            DataProviders = @event.DataProviders;
        }
    }
}
