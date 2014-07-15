using System.Collections.Generic;
using EventStore.ClientAPI;

namespace EventTracking.Tests.Helper.Fakes.EventStore
{
    public static class FakeDatabase
    {
        public static Dictionary<string, EventData> Events = new Dictionary<string, EventData>();
    }
}
