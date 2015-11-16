using System;

namespace UserManagement.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
