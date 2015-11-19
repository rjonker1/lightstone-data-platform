using NHibernate;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public class EntityNoteRepository<T> : Repository<T>, IEntityNoteRepository<T> where T : IEntityNote, IEntity
    {
        public EntityNoteRepository(ISession session) : base(session) { }
    }
}