using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceTransformEvent
    {
        void PublishTransformationStartMessage(Guid aggerateId, LaceEventSource source);

        void PublishTransformationEndMessage(Guid aggerateId, LaceEventSource source);

        void PublishTransformationFailedMessage(Guid aggerateId, LaceEventSource source);
    }
}
