using Monitoring.Sources.Lace;
namespace Lace.Events
{
    public interface ILaceSourceHandledEvent
    {
        void PublishSourceIsBeingHandledMessage(LaceEventSource source);

        void PublishSourceIsNotBeingHandledMessage(LaceEventSource source);
    }
}
