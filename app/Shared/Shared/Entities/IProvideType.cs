using System;

namespace DataPlatform.Shared.Entities
{
    public interface IProvideType
    {
        Type Type { get; }
        string TypeName { get; }
    }
}