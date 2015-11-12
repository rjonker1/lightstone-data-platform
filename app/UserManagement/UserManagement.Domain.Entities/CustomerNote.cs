using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CustomerNote : Entity
    {
        public virtual Customer Customer { get; protected internal set; }
        public virtual Note Note { get; protected internal set; }

        protected CustomerNote() { }

        public CustomerNote(Customer customer, Note note, Guid id = new Guid()) : base(id)
        {
            Customer = customer;
            Note = note;
        }
    }
}