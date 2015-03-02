using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Core.Entities
{
    public abstract class ValueEntity : Entity, IValueEntity
    {
        [Required]
        public virtual string Value { get; protected internal set; }

        protected ValueEntity() { }

        protected ValueEntity(string value, Guid id = new Guid())
            : base(id)
        {
            Value = value;
        }
    }
}