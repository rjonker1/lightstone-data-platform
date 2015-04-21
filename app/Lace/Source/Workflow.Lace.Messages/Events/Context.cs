using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Events
{
    [Serializable]
    [DataContract]
    public class SecurityFlagRaised : IPublishableMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProviderId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public CommandType CommandType { get; private set; }
        
        [DataMember]
        public PayloadObjectIdentifier Payload { get; private set; }
      
        public SecurityFlagRaised(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date,
            CommandType commandType, PayloadObjectIdentifier payload)
        {
            Id = id;
            RequestId = requestId;
            DataProviderId = dataProvider;
            Date = date;
            CommandType = commandType;
            Payload = payload;
        }
    }

    [Serializable]
    [DataContract]
    public class DataProviderConfigured : IPublishableMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProviderId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public CommandType CommandType { get; private set; }
        [DataMember]
        public PayloadObjectIdentifier Payload { get; private set; }

        public DataProviderConfigured(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date,
            CommandType commandType, PayloadObjectIdentifier payload)
        {
            Id = id;
            RequestId = requestId;
            DataProviderId = dataProvider;
            Date = date;
            CommandType = commandType;
            Payload = payload;
        }
    }

    [Serializable]
    [DataContract]
    public class DataProviderResponseTransformed : IPublishableMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProviderId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public CommandType CommandType { get; private set; }
        [DataMember]
        public PayloadObjectIdentifier Payload { get; private set; }

        public DataProviderResponseTransformed(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, PayloadObjectIdentifier payload)
        {
            Id = id;
            RequestId = requestId;
            DataProviderId = dataProvider;
            Date = date;
            CommandType = commandType;
            Payload = payload;
        }
    }

    [Serializable]
    [DataContract]
    public class DataProviderError : IPublishableMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProviderId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public CommandType CommandType { get; private set; }
        [DataMember]
        public PayloadObjectIdentifier Payload { get; private set; }

        public DataProviderError(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date,
            CommandType commandType, PayloadObjectIdentifier payload)
        {
            Id = id;
            RequestId = requestId;
            DataProviderId = dataProvider;
            Date = date;
            CommandType = commandType;
            Payload = payload;
        }
    }

    [Serializable]
    [DataContract]
    public class DataProviderCallStarted : IPublishableMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProviderId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public CommandType CommandType { get; private set; }

        [DataMember]
        public PayloadObjectIdentifier Payload { get; private set; }

        public DataProviderCallStarted(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date,
            CommandType commandType, PayloadObjectIdentifier payload)
        {
            Id = id;
            RequestId = requestId;
            DataProviderId = dataProvider;
            Date = date;
            CommandType = commandType;
            Payload = payload;
        }
    }

    [Serializable]
    [DataContract]
    public class DataProviderCallEnded : IPublishableMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProviderId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public CommandType CommandType { get; private set; }

        [DataMember]
        public PayloadObjectIdentifier Payload { get; private set; }

        public DataProviderCallEnded(Guid id, Guid requestId, DataProviderCommandSource dataProvider, DateTime date,
            CommandType commandType, PayloadObjectIdentifier payload)
        {
            Id = id;
            RequestId = requestId;
            DataProviderId = dataProvider;
            Date = date;
            CommandType = commandType;
            Payload = payload;
        }
    }
}