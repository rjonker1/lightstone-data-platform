﻿
namespace PackageBuilder.Domain.Entities
{
    public interface IAction : INamedEntity, IEntity
    {
        ICriteria Criteria { get; }
    }
}