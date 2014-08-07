using System;
using System.Collections.Generic;
using EventStore.ClientAPI;

namespace Monitoring.Test.Helper.Fakes.EventStore
{
    public static class FakeDatabase
    {
        public static Dictionary<Guid, StreamData> Events = new Dictionary<Guid, StreamData>();
    }

    public class StreamData
    {
        public string StreamName { get; private set; }
        public EventData Event { get; private set; }

        public StreamData(string streamName, EventData data)
        {
            StreamName = streamName;
            Event = data;
        }
    }
}
