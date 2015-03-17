using System;
namespace Workflow.Lace.Identifiers
{
    public class DataProviderResponseIdentifier
    {
        public DataProviderResponseIdentifier()
        {
            
        }

        public DataProviderResponseIdentifier(Guid id, Guid streamId, DateTime date, DataProviderTransactionIdentifier request)
        {
            Id = id;
            StreamId = streamId;
            Date = date;
            Request = request;
        }

        public Guid Id { get; set; }
        public Guid StreamId { get; private set; }
        public DateTime Date { get; private set; }
        public DataProviderTransactionIdentifier Request { get; set; }
    }
}
