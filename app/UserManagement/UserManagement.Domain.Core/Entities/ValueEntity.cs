using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Core.Entities
{
    public abstract class ValueEntity : Entity, IValueEntity
    {
        [Required, Unique]
        public virtual string Value { get; protected internal set; }

        protected ValueEntity() { }

        protected ValueEntity(string value, Guid id = new Guid())
            : base(id)
        {
            Value = value;
        }
    }
}