using System;

namespace DataPlatform.Shared.Entities
{
    public interface IDataField : INamedEntity
    {
        Type Type { get; }
    }
}