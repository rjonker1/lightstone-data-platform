using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Messaging;
using EasyNetQ;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Messages.Indicators
{
    [Queue("DataPlatform.DataProvider.Receiver", ExchangeName = "DataPlatform.DataProvider.Receiver")]
    [DataContract]
    public class RequestFieldsForDataProvider : IPublishableMessage
    {
        public RequestFieldsForDataProvider()
        {

        }

        public RequestFieldsForDataProvider(Guid requestId, DataProviderIdentifier dataProvider, RequestFieldTypeIdentifier requestField,
            string packageName)
        {
            RequestId = requestId;
            DataProvider = dataProvider;
            RequestField = requestField;
            PackageName = packageName;
        }

        [DataMember]
        public Guid RequestId { get; private set; }
        [DataMember]
        public DataProviderIdentifier DataProvider { get; private set; }

        [DataMember]
        public RequestFieldTypeIdentifier RequestField { get; private set; }

        [DataMember]
        public string PackageName { get; private set; }

    }

    [Queue("DataPlatform.DataProvider.Receiver", ExchangeName = "DataPlatform.DataProvider.Receiver")]
    [DataContract]
    public class ExecutionDetailForDataProvider
    {
        public ExecutionDetailForDataProvider()
        {
            
        }
        public ExecutionDetailForDataProvider(Guid requestId, CommandTypeIdentifier command, DataProviderIdentifier dataProvider,
            string elapsedTime = "00:00:00")
        {
            RequestId = requestId;
            Command = command;
            DataProvider = dataProvider;
            ElapsedTime = elapsedTime;
        }

        [DataMember]
        public Guid RequestId { get; private set; }
        [DataMember]
        public DataProviderIdentifier DataProvider { get; private set; }
        [DataMember]
        public CommandTypeIdentifier Command { get; private set; }
        [DataMember]
        public string ElapsedTime { get; private set; }
    }
}
