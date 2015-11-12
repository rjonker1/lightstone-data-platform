using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Note : Entity
    {
        public virtual string NoteText { get; protected internal set; }
        public virtual User User { get; protected internal set; }

        protected Note() { }

        public Note(string noteText, User user, Guid id = new Guid()) : base(id)
        {
            NoteText = noteText;
            User = user;
        }
    }
}