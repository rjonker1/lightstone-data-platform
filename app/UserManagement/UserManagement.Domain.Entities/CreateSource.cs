using System;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class CreateSource : ValueEntity
    {
        [DomainSignature]
        public virtual CreateSourceType CreateSourceType { get; protected internal set; }
        protected CreateSource() { }

        public CreateSource(string value, CreateSourceType createSourceType)
            : base(value, Guid.NewGuid())
        {
            Value = value;
            CreateSourceType = createSourceType;
        }
    }
}
