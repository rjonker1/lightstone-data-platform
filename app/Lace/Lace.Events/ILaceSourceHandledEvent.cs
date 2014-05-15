using System;
using Lace.Shared.Enums;

namespace Lace.Events
{
    public interface ILaceSourceHandledEvent
    {
        void PublishSourceIsBeingHandledMessage(Guid aggerateId, EventSource source);

        void PublishSourceIsNotBeingHandledMessage(Guid aggerateId, EventSource source);
    }
}
