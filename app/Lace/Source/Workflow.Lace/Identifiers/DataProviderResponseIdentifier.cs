using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
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

        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid StreamId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public DataProviderTransactionIdentifier Request { get; set; }
    }
}
