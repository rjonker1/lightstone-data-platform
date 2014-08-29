using System;

namespace DataPlatform.Shared.Entities
{
    public interface IDataProvider : INamedEntity
    {
        Type ResponseType { get; }
    }
}