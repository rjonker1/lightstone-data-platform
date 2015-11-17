using System;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class CustomerNote : EntityNote
    {
        [Unique]
        public virtual Customer Entity { get; protected internal set; }
        [Unique]
        public virtual Note Note { get; protected internal set; }

        protected CustomerNote() { }

        public CustomerNote(Customer customer, Note note, Guid id = new Guid()) : base(customer, note, id)
        {
            Entity = customer;
            Note = note;
        }
    }
}