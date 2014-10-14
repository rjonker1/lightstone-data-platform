using System;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging
{
    /// <summary>
    /// Represents an event message.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Gets the identifier of the source originating the event.
        /// </summary>
        Guid SourceId { get; }
    }
}
