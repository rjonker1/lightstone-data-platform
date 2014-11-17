using System;

namespace PackageBuilder.Domain.Entities
{
    public interface INamedEntity
    {
        string Name { get; }
    }
}