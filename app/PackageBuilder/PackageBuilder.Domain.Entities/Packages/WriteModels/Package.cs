using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.Packages.Events;

namespace PackageBuilder.Domain.Entities.Packages.WriteModels
{
    [DataContract]
    public class Package : AggregateBase
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        [DataMember]
        public double CostPrice { get; private set; }
        [DataMember]
        public double SalePrice { get; private set; }
        [DataMember]
        public string State { get; private set; }
        [DataMember]
        public string Owner { get; private set; }
        [DataMember]
        public DateTime CreatedDate { get; private set; }
        [DataMember]
        public DateTime EditedDate { get; private set; }
        [DataMember]
        public IEnumerable<IDataProvider> DataProviders { get; private set; }

        //Used by NEventstore
        private Package(Guid id)
        {
            Id = id;
        }

        //Used for serialization
        protected Package() { }

        public Package(Guid id, string name, string description, double costPrice, double salePrice, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataProvider> dataProviders)
            : this(id)
        {
            RaiseEvent(new PackageCreated(id, name, description, costPrice, salePrice, state,  owner, createdDate, editedDate, dataProviders));
        }

        public void CreatePackageRevision(Guid id, string name, string description, double costPrice, double salePrice, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataProvider> dataProviders)
        {
            RaiseEvent(new PackageUpdated(id, name, description, costPrice, salePrice, state, owner, createdDate, editedDate, dataProviders));
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

        private void Apply(PackageUpdated @event)
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
