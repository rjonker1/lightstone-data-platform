using System;
using Lace.Shared.Enums;

namespace Lace.Events
{
    public interface ILaceExternalSourceEvent
    {
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
