using System;
using CommonDomain.Core;
using FluentNHibernate.Data;

namespace PackageBuilder.Domain.Entities.Packages.WriteModels
{
    public class Package : AggregateBase
    {
        protected Package() { }

        public Package(Guid id, string name, string description, string owner)
        {
            Id = id;
            Name = name;
            Description = description;
            Owner = owner;
            Created = DateTime.UtcNow;
            Version = 1;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Owner { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Edited { get; private set; }
        public int Version { get; private set; }
    }
}
