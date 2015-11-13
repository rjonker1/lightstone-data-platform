
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public interface IEntityNote : IEntity
    {
        Entity Entity { get; }
        Note Note { get; }
    }
}