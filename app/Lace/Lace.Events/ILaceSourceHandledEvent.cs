using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceSourceHandledEvent
    {
        void PublishSourceIsBeingHandledMessage(Guid aggerateId, LaceEventSource source);

        void PublishSourceIsNotBeingHandledMessage(Guid aggerateId, LaceEventSource source);
    }
}
