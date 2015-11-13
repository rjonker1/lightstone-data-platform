using System;

namespace UserManagement.Domain.Core.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
