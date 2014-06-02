using System;
using Monitoring.Sources;

namespace Lace.Events
{
    public interface ILaceSourceHandledEvent
    {
        void PublishSourceIsBeingHandledMessage(Guid aggerateId, FromSource source);

        void PublishSourceIsNotBeingHandledMessage(Guid aggerateId, FromSource source);
    }
}
