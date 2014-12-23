using System;
using System.Collections.Generic;
using CommonDomain;

namespace Monitoring.Test.Helper.Fakes.EventStore
{
    public static class FakeDatabase
    {
        public static Dictionary<Guid, IAggregate> Events = new Dictionary<Guid, IAggregate>();
    }

    //public class StreamData
    //{
    //    public string StreamName { get; private set; }
    //    public IAggregate Aggregate { get; private set; }

    //    public StreamData(string streamName, IAggregate data)
    //    {
    //        StreamName = streamName;
    //        Aggregate = data;
    //    }
    //}
}
