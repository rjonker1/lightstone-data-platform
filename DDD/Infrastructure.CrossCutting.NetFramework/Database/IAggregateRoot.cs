using System;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Database
{
    /// <summary>
    /// Represents an identifiable entity in the system.
    /// </summary>
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
