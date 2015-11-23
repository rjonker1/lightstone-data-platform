using System;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class EntityNote : Entity, IEntityNote
    {
        [DoNotMap]
        public virtual Entity Entity { get; protected internal set; }
        [DoNotMap]
        public virtual Note Note { get; protected internal set; }
        [DoNotMap]
        public virtual bool Deleted { get; protected internal set; }

        protected EntityNote() { }

        protected EntityNote(Entity entity, Note note, Guid id = new Guid()) : base(id)
        {
            Entity = entity;
            Note = note;
        }

        public virtual void Delete()
        {
            Deleted = true;
        }
    }
}