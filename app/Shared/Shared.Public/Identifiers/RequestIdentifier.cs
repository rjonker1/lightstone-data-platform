using System;

namespace DataPlatform.Shared.Public.Identifiers
{
    public class RequestIdentifier
    {
        public RequestIdentifier()
        {
        }

        public RequestIdentifier(Guid id, SystemIdentifier system)
        {
            ID = id;
            System = system;
        }

        public Guid ID { get; private set; }
        public SystemIdentifier System { get; private set; }
    }
}