using System;
using Workflow.Lace.Domain;

namespace Workflow.Lace.Identifiers
{
    public class DataProviderResponseIdentifier
    {
        public DataProviderResponseIdentifier()
        {
            
        }

        public DataProviderResponseIdentifier(Guid id, DateTime date, DataProviderRequestIdentifier request)
        {
            Id = id;
            Date = date;
            Request = request;
        }

        public Guid Id { get; set; }
        public DateTime Date { get; private set; }
        public DataProviderRequestIdentifier Request { get; set; }
    }
}
