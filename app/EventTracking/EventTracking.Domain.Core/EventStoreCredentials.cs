using EventStore.ClientAPI.SystemData;

namespace EventTracking.Domain.Core
{
    public class EventStoreCredentials
    {
        private static readonly UserCredentials Credentials = new UserCredentials("admin", "changeit");

        public static UserCredentials Default { get { return Credentials; } }
    }
}
