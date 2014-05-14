using System;
using Lace.Events.Messages;
using Lace.Shared.Enums;

namespace Lace.Events
{
    public interface ILaceEvent
    {
        void PublishMessage(LaceEventMessage message);

        void PublishMessage(Guid aggerateId, string message, EventSource source);

        void PublishStartServiceConfigurationMessage(Guid aggerateId, EventSource source);

        void PublishEndServiceConfigurationMessage(Guid aggerateId, EventSource source);

        void PublishStartServiceCallMessage(Guid aggerateId, EventSource source);

        void PublishEndServiceCallMessage(Guid aggerateId, EventSource source);

        void PublishFailedServiceCallMessaage(Guid aggerateId, EventSource source);

        void PublishNoResponseFromServiceMessage(Guid aggerateId, EventSource source);

        void PublishServiceRequestMessage(Guid aggerateId, EventSource source, string request);

        void PublishServiceResponseMessage(Guid aggerateId, EventSource source, string response);

    }
}
