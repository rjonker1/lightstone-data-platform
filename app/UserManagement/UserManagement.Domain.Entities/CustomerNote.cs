using System;

namespace UserManagement.Domain.Entities
{
    public class CustomerNote : EntityNote
    {
        public virtual Customer Entity { get; protected internal set; }
        public virtual Note Note { get; protected internal set; }

        protected CustomerNote() { }

        public CustomerNote(Customer customer, Note note, Guid id = new Guid()) : base(customer, note, id)
        {
            Entity = customer;
            Note = note;
        }
    }
}