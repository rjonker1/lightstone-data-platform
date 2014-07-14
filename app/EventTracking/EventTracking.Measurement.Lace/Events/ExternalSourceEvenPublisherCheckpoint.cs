namespace EventTracking.Measurement.Lace.Events
{
    public class ExternalSourceEvenPublisherCheckpoint
    {
        public int LastProcessedEvent { get; private set; }

        public ExternalSourceEvenPublisherCheckpoint(int eventNumber)
        {
            LastProcessedEvent = eventNumber;
        }
    }
}
