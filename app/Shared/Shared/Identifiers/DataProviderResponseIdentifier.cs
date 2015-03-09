using System;
namespace DataPlatform.Shared.Identifiers
{
    public class DataProviderResponseIdentifier
    {
        public DataProviderResponseIdentifier()
        {
            
        }

        public DataProviderResponseIdentifier(Guid id, DataProviderRequestIdentifier request)
        {
            Id = id;
            Request = request;
        }

        public Guid Id { get; set; }
        public DataProviderRequestIdentifier Request { get; set; }
    }
}
