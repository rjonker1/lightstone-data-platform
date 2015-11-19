using System;
using DataPlatform.Shared.Enums;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class Package : NamedEntity
    {
        [Unique]
        public virtual Guid PackageId { get; protected internal set; }
        public virtual bool IsActive { get; protected internal set; }
        public Package() { }

        public Package(string name, Guid packageId, Guid id = new Guid())
            : base(name, id)
        {
            PackageId = packageId;
        }
    }
}
