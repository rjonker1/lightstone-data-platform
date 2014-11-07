using System;
using DataPlatform.Shared.Enums;

namespace DataPlatform.Shared.Entities
{
    public interface IDataProvider 
    {
        DataProviderName Name { get; }
        Type ResponseType { get; }
    }
}