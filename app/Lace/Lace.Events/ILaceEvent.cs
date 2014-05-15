using System;
using Lace.Shared.Enums;

namespace Lace.Events
{
    public interface ILaceEvent : ILaceExternalSourceEvent, ILaceSourceHandledEvent, ILaceTransformEvent
    {
        void PublishMessage(ILaceEventMessage message);

        void PublishMessage(Guid aggerateId, string message, EventSource source);
    }
}
