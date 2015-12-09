using System;
using Lim.Domain.Events;

namespace Toolbox.LightstoneAuto.Domain.Events
{
    public class ViewImportDeActivated : LimEvent
    {
        public ViewImportDeActivated(Guid viewId, Guid correlationId)
        {
            AggregateId = viewId;
            ViewId = viewId;
            CorrelationId = correlationId;
        }

        public Guid ViewId { get; private set; }
    }
}