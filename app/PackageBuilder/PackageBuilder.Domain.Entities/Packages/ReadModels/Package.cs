using System;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.Packages.ReadModels
{
    public class Package : Entity
    {
        public virtual Guid PackageId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual State State { get; protected set; }
        public virtual int Version { get; protected set; }
        public virtual string Owner { get; protected set; }
        public virtual DateTime CreatedDate { get; protected set; }
        public virtual DateTime? EditedDate { get; protected set; }

        protected Package() { }

        public Package(Guid id, string name, string description, State state, int version, string owner, DateTime createdDateDate, DateTime? editedDateDate) : base(Guid.NewGuid())
        {
            PackageId = id;
            Name = name;
            Description = description;
            State = state;
            Version = version;
            Owner = owner;
            CreatedDate = createdDateDate;
            EditedDate = editedDateDate;
        }
    }
}
