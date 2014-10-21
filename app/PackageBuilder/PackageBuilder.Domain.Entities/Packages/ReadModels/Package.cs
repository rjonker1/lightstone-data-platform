using System;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.Packages.ReadModels
{
    public class Package : Entity
    {
        protected Package() { }

        public Package(Guid id, Guid dataProviderId, string name, string description, string owner, DateTime created)
        {
            Id = id;
            DataProviderId = dataProviderId;
            Name = name;
            Description = description;
            Owner = owner;
            Created = created;
            Version = 1;
        }

        public virtual Guid Id { get; protected set; }
        public virtual Guid DataProviderId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual string Owner { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual DateTime Edited { get; protected set; }
        public virtual int Version { get; protected set; }
    }
}
