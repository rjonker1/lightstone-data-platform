using System;
using System.Runtime.Serialization;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Domain
{
    public class DataProviderTransaction
    {
        public DataProviderTransaction(DataProviderTransactionIdentifier transaction)
        {
            Transaction = transaction;
        }

        public DataProviderTransactionIdentifier Transaction { get; private set; }
    }

    public class DataProviderExecution
    {
        public DataProviderExecution(Guid requestId, CommandTypeIdentifier command, DataProviderIdentifier dataProvider,
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

    public class DataProviderRequestField
    {

        public DataProviderRequestField()
        {

        }

        public DataProviderRequestField(Guid requestId, DataProviderIdentifier dataProvider, RequestFieldTypeIdentifier requestField,
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

    public class DataProviderEvent
    {
        public DataProviderEvent(EventIndentifier command)
        {
            Command = command;
        }
        public EventIndentifier Command { get; private set; }
    }
}
