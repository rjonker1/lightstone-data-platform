using System;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; } 
    }
}