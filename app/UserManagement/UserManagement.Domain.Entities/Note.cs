using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Entities
{
    public class Note : Entity
    {
        [Required]
        public virtual string NoteText { get; protected internal set; }

        protected Note() { }

        public Note(string noteText, Guid id = new Guid()) : base(id)
        {
            NoteText = noteText;
        }
    }
}