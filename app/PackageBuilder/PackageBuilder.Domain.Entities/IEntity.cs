using System;

namespace PackageBuilder.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; } 
    }
}