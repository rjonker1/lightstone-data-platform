using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IEntityNoteRepository<T> : IRepository<T> where T : IEntityNote, IEntity
    {
        
    }
}