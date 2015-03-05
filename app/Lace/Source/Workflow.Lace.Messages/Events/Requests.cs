﻿using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;

namespace Workflow.Lace.Messages.Events
{
    [Serializable]
    [DataContract]
    public class RequestReceived : IPublishableMessage
    {
        public RequestReceived(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }

    [Serializable]
    [DataContract]
    public class RequestSentToDataProvider : IPublishableMessage
    {
        public RequestSentToDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date)
        {
            Id = id;
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
