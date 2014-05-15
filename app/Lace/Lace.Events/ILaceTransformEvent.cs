using System;
using Lace.Shared.Enums;

namespace Lace.Events
{
    public interface ILaceTransformEvent
    {
        void PublishTransformationStartMessage(Guid aggerateId, EventSource source);

        void PublishTransformationEndMessage(Guid aggerateId, EventSource source);

        void PublishTransformationFailedMessage(Guid aggerateId, EventSource source);
    }
}
