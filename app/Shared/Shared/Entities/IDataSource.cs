using System;

namespace DataPlatform.Shared.Entities
{
    public interface IDataSource : INamedEntity
    {
        // ToDo: Remove (Only for testing purposes in sliver implementation)
        Guid Id { get; set; } 
    }
}