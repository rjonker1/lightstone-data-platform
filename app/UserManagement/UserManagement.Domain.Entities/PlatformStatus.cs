using System;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class PlatformStatus : ValueEntity
    {
        [DomainSignature]
        public virtual PlatformStatusType PlatformStatusType { get; protected internal set; }
        protected PlatformStatus() { }

        public PlatformStatus(string value, PlatformStatusType platformStatusType)
            : base(value, Guid.NewGuid())
        {
            Value = value;
            PlatformStatusType = platformStatusType;
        }
    }
}
