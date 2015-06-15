using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Core.Entities
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required, Unique]
        public virtual string Name { get; protected internal set; }

        protected NamedEntity() { }

        protected NamedEntity(string name, Guid id = new Guid()) : base(id)
        {
            Name = name;
        }
    }
}