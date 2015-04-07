﻿using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;

namespace Workflow.Lace.Messages.Events
{

    [Serializable]
    [DataContract]
    public class RequestToDataProvider : IPublishableMessage
    {
        public RequestToDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date, string connection, string connectionType, DataProviderState state, DataProviderAction action, string metaData, string payload, string message)
        {
            Id = id;
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            ConnectionType = connectionType;
            State = state;
            Action = action;
            MetaData = metaData;
            Message = message;
            Payload = payload;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public string ConnectionType { get; private set; }

        [DataMember]
        public string Connection { get; private set; }

        [DataMember]
        public DataProviderState State { get; private set; }
        [DataMember]
        public DataProviderAction Action { get; private set; }
        [DataMember]
        public string MetaData { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public string Message { get; private set; }
    }
}
