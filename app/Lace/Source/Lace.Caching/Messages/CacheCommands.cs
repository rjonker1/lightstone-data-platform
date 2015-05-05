using System;
using System.Runtime.Serialization;
using EasyNetQ;

namespace Lace.Caching.Messages
{
    [Queue("DataPlatform.DataProvider.Cache.Receiver", ExchangeName = "DataPlatform.DataProvider.Cache.Receiver")]
    [DataContract]
    public class ClearCacheCommand
    {
        public ClearCacheCommand(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }

    [Queue("DataPlatform.DataProvider.Cache.Receiver", ExchangeName = "DataPlatform.DataProvider.Cache.Receiver")]
    [DataContract]
    public class RefreshCacheCommand
    {
        public RefreshCacheCommand(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }

    [Queue("DataPlatform.DataProvider.Cache.Receiver", ExchangeName = "DataPlatform.DataProvider.Cache.Receiver")]
    [DataContract]
    public class RestartCacheDataStoreCommand
    {
        public RestartCacheDataStoreCommand(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
