using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IDataProvider : INamedEntity
    {
        Type ResponseType { get; }
    }
}