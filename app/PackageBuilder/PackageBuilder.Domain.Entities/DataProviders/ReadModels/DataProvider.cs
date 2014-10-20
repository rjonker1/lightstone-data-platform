using System;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.DataProviders.ReadModels
{
    public class DataProvider : Entity
    {
        protected DataProvider() { }

        public DataProvider(Guid id, Guid dataProviderId, string name, double costOfSale, string description, string owner) : base(id)
        {
            DataProviderId = dataProviderId;
            Name = name;
            CostOfSale = costOfSale;
            Description = description;
            Owner = owner;
            Created = DateTime.UtcNow;
            Edited = Created;
            Version = 1;
        }

        public virtual Guid DataProviderId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual double CostOfSale { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual string Owner { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual DateTime Edited { get; protected set; }
        public virtual int Version { get; protected set; }
    }
}
