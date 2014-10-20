using System;
using FluentNHibernate.Data;


namespace PackageBuilder.Domain.Entities.Packages.ReadModels
{
    public class Package : Entity
    {
        public Package(Guid id, Guid dataProviderId, string name, string description, string owner)
        {
            Id = id;
            DataProviderId = dataProviderId;
            Name = name;
            Description = description;
            Owner = owner;
            Created = DateTime.UtcNow;
            Version = 1;
        }

        public Guid Id { get; private set; }
        public Guid DataProviderId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Owner { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Edited { get; private set; }
        public int Version { get; private set; }
    }
}
