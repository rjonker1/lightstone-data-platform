using System.Collections.Generic;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.MessageLog
{
    /// <summary>
    /// Exposes the message log for all events that the system processed.
    /// </summary>
    public interface IEventLogReader
    {
        IEnumerable<IEvent> Query(QueryCriteria criteria);
    }
}
