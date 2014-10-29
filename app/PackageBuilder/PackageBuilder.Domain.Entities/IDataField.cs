using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IDataField : INamedEntity
    {
        Type Type { get; }
    }
}