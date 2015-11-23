using System;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class UserNote : EntityNote
    {
        [Unique]
        public virtual User Entity { get; protected internal set; }
        [Unique]
        public virtual Note Note { get; protected internal set; }
        public override bool Deleted { get; protected internal set; }

        protected UserNote() { }

        public UserNote(User user, Note note, Guid id = new Guid())
            : base(user, note, id)
        {
            Entity = user;
            Note = note;
        }
    }
}