using System;
namespace EventTracking.Domain
{
    public interface IMemento
    {
        Guid Id { get; set; }
        int Version { get; set; }
    }
}
