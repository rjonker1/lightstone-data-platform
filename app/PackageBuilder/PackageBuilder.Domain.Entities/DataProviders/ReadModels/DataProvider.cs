using System;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.DataProviders.ReadModels
{
    public class DataProvider : Entity
    {
        public virtual Guid DataProviderId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual double CostPrice { get; protected set; }
        public virtual int Version { get; protected set; }
        public virtual string Owner { get; protected set; }
        public virtual DateTime CreatedDate { get; protected set; }
        public virtual DateTime EditedDate { get; protected set; }

        protected DataProvider() { }

        public DataProvider(Guid dataProviderId, string name, string description, double costPrice, int version, string owner, DateTime createdDate, DateTime editedDate) : base(Guid.NewGuid())
        {
            DataProviderId = dataProviderId;
            Name = name;
            Description = description;
            CostPrice = costPrice;
            Version = version;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
        }
    }
}
