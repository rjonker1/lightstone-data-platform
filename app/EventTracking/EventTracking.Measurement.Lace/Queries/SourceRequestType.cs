
namespace EventTracking.Measurement.Lace.Queries
{
    public class SourceRequestType
    {
        public string Message  { get; private set; }
        public string Source { get; private set; }

        public SourceRequestType(string message, string source)
        {
            Message = message;
            Source = source;
        }

        public override string ToString()
        {
            return string.Format("Source:  {0}, Message: {1}", Source, Message);
        }

    }
}
