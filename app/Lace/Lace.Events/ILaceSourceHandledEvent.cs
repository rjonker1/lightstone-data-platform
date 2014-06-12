using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceSourceHandledEvent
    {
        void PublishSourceIsBeingHandledMessage(Guid aggerateId, ExternalSource source);

        void PublishSourceIsNotBeingHandledMessage(Guid aggerateId, ExternalSource source);
    }
}
