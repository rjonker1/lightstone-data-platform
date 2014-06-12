using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceExternalSourceEvent
    {
        void PublishStartServiceConfigurationMessage(Guid aggerateId, ExternalSource source);

        void PublishEndServiceConfigurationMessage(Guid aggerateId, ExternalSource source);

        void PublishStartServiceCallMessage(Guid aggerateId, ExternalSource source);

        void PublishEndServiceCallMessage(Guid aggerateId, ExternalSource source);

        void PublishFailedServiceCallMessaage(Guid aggerateId, ExternalSource source);

        void PublishNoResponseFromServiceMessage(Guid aggerateId, ExternalSource source);

        void PublishServiceRequestMessage(Guid aggerateId, ExternalSource source, string request);

        void PublishServiceResponseMessage(Guid aggerateId, ExternalSource source, string response);
    }
}
