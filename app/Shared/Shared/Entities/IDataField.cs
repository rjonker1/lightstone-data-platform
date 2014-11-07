using System;
using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IDataField : INamedEntity
    {
        Type Type { get; }
        IEnumerable<IDataField> DataFields { get; }
    }
}