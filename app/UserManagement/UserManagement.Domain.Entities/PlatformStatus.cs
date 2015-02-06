using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class PlatformStatus : NamedEntity
    {
        public virtual string Value { get; set; }

        protected PlatformStatus() { }

        public PlatformStatus(Guid id, string val) : base(id, val)
        {
            Value = val;
        }
    }
}
