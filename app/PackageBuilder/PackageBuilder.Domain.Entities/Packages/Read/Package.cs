using System;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Domain.Entities.Packages.Read
{
    public class Package : Entity
    {
        public virtual Guid PackageId { get; protected internal set; }
        public virtual string Name { get; protected internal set; }
        public virtual string Description { get; protected internal set; }
        public virtual State State { get; protected internal set; }
        public virtual int Version { get; protected internal set; }
        public virtual decimal DisplayVersion { get; protected internal set; }
        public virtual string Owner { get; protected internal set; }
        public virtual DateTime CreatedDate { get; protected internal set; }
        public virtual DateTime? EditedDate { get; protected internal set; }
        public virtual bool IsDeleted { get; protected internal set; }
        public virtual DateTime? DeletedDate { get; protected internal set; }

        protected Package() { }

        public Package(Guid id, string name, string description, State state, int version, decimal displayVersion, string owner, DateTime createdDateDate, DateTime? editedDateDate)
            : base(Guid.NewGuid())
        {
            PackageId = id;
            Name = name;
            Description = description;
            State = state;
            Version = version;
            DisplayVersion = displayVersion;
            Owner = owner;
            CreatedDate = createdDateDate;
            EditedDate = editedDateDate;
        }

        public virtual void DeletePackage()
        {
            IsDeleted = true;
            DeletedDate = DateTime.UtcNow;
        }
    }
}
