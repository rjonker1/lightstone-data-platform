using System;
using System.Runtime.Serialization;
using CommonDomain;
using CommonDomain.Core;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
using Workflow.Billing.Messages.Publishable;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Events;

namespace Workflow.Lace.Domain.Aggregates
{
    [DataContract]
    public class Request : AggregateBase, IAggregate
    {
        private Request(Guid id)
        {
            Id = id;
            Register<Request>(e => e.Id = id);
            Register<EntryPointReceivedRequest>(e => e.Id = id);
            Register<EntryPointReturnedResponse>(e => e.Id = id);

            Register<RequestToDataProvider>(e => e.Id = id);
            Register<ResponseFromDataProvider>(e => e.Id = id);
            Register<BillTransactionMessage>(e => e.TransactionId = id);

            Register<DataProviderCallStarted>(e => e.Id = id);
            Register<DataProviderCallEnded>(e => e.Id = id);
            Register<SecurityFlagRaised>(e => e.Id = id);
            Register<DataProviderConfigured>(e => e.Id = id);
            Register<DataProviderResponseTransformed>(e => e.Id = id);
            Register<DataProviderError>(e => e.Id = id);
        }

        public Request()
        {
            
        }

        public Request(Guid requestId, DataProviderIdentifier dataProvider, DateTime date,
            ConnectionTypeIdentifier connection, PayloadIdentifier payload)
            : this(requestId)
        {
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            Payload = payload;
            CommandType = CommandType.BeginExecution;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = (DataProviderCommandSource) dataProvider.Id;

            RaiseEvent(new RequestToDataProvider(Guid.NewGuid(), requestId, dataProvider, date, connection, payload));
        }

        public Request(Guid requestId, DateTime date, SearchRequestIndentifier request,
            PayloadIdentifier payload) : this(requestId)
        {

            RequestId = requestId;
            DataProvider = new DataProviderIdentifier();
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = payload;
            CommandType = CommandType.BeginExecution;
            State = new StateIdentifier();
            RequestContext = request;
            DataProviderId = DataProviderCommandSource.EntryPoint;

            RaiseEvent(new EntryPointReceivedRequest(Guid.NewGuid(), date, requestId, payload, request));
        }

        public Request(Guid requestId, DateTime date, StateIdentifier state,
            PayloadIdentifier payload, SearchRequestIndentifier request) : this(requestId)
        {

            RequestId = requestId;
            DataProvider = new DataProviderIdentifier();
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = payload;
            CommandType = CommandType.EndExecution;
            State = state;
            RequestContext = request;
            DataProviderId = DataProviderCommandSource.EntryPoint;

            RaiseEvent(new EntryPointReturnedResponse(Guid.NewGuid(), requestId, date, payload, state, request));
        }

        public void StartCall(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {

            RequestId = requestId;
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Request,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData,payload,message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = dataProvider;

            RaiseEvent(new DataProviderCallStarted(Guid.NewGuid(), requestId, dataProvider, date, commandType,
                new PayloadIdentifier(metaData,payload,message)));
        }

        public void EndCall(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {

            RequestId = requestId;
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Response,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = dataProvider;

            RaiseEvent(new DataProviderCallEnded(Guid.NewGuid(), requestId, dataProvider, date, commandType,
               new PayloadIdentifier(metaData,payload,message)));
        }

        public void RaiseSecurityFlag(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
            RequestId = requestId;
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Response,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = dataProvider;

            RaiseEvent(new SecurityFlagRaised(Guid.NewGuid(), requestId, dataProvider, date, commandType, new PayloadIdentifier(metaData, payload, message)));
        }

        public void Configuration(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
            RequestId = requestId;
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Request,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = dataProvider;

            RaiseEvent(new DataProviderConfigured(Guid.NewGuid(), requestId, dataProvider, date, commandType, new PayloadIdentifier(metaData, payload, message)));
        }

        public void Transformation(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
            RequestId = requestId;
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Request,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = dataProvider;

            RaiseEvent(new DataProviderResponseTransformed(Guid.NewGuid(), requestId, dataProvider, date, commandType, new PayloadIdentifier(metaData, payload, message)));
        }

        public void Error(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
            RequestId = requestId;
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Request,
                DataProviderState.Failed);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = dataProvider;

            RaiseEvent(new DataProviderError(Guid.NewGuid(), requestId, dataProvider, date, commandType, new PayloadIdentifier(metaData, payload, message)));
        }


        public void EntryPointRequest(Guid requestId, DateTime date, SearchRequestIndentifier request,
            PayloadIdentifier payload)
        {

            RequestId = requestId;
            DataProvider = new DataProviderIdentifier(DataProviderCommandSource.EntryPoint, DataProviderAction.Request,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = payload;
            CommandType = CommandType.BeginExecution;
            State = new StateIdentifier();
            RequestContext = request;
            DataProviderId = DataProviderCommandSource.EntryPoint;

            RaiseEvent(new EntryPointReceivedRequest(Guid.NewGuid(), date, requestId, payload, request));
        }

        public void EntryPointResponse(Guid requestId, DateTime date, StateIdentifier state,
            PayloadIdentifier payload, SearchRequestIndentifier request)
        {
            RequestId = requestId;
            DataProvider = new DataProviderIdentifier(DataProviderCommandSource.EntryPoint, DataProviderAction.Response,
                (DataProviderState) state.Id);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = payload;
            CommandType = CommandType.EndExecution;
            State = state;
            RequestContext = request;
            DataProviderId = DataProviderCommandSource.EntryPoint;

            RaiseEvent(new EntryPointReturnedResponse(Guid.NewGuid(), requestId, date, payload, state, request));
        }

        public void RequestSentToDataProvider(Guid requestId, DataProviderIdentifier dataProvider, DateTime date,
            ConnectionTypeIdentifier connection, PayloadIdentifier payload)
        {
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            Payload = payload;
            CommandType = CommandType.StartSourceCall;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = (DataProviderCommandSource)dataProvider.Id;

            RaiseEvent(new RequestToDataProvider(Guid.NewGuid(), requestId, dataProvider, date, connection, payload));
        }

        public void ResponseReceivedFromDataProvider(Guid requestId, DataProviderIdentifier dataProvider, DateTime date,
            ConnectionTypeIdentifier connection, PayloadIdentifier payload)
        {
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            Payload = payload;
            CommandType = CommandType.EndSourceCall;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = (DataProviderCommandSource)dataProvider.Id;

            RaiseEvent(new ResponseFromDataProvider(Guid.NewGuid(), requestId, dataProvider, date, connection, payload));
        }

        public void CreateTransaction(Guid id, Guid packageId, long packageVersion, DateTime date, Guid userId,
            Guid requestId,
            Guid contractId,
            string system, long contractVersion, DataProviderState state, string accountNumber)
        {
            RequestId = requestId;
            DataProvider = new DataProviderIdentifier();
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier();
            CommandType = CommandType.EndExecution;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            DataProviderId = DataProviderCommandSource.EntryPoint;
            Package = new PackageIdentifier(packageId, new VersionIdentifier(packageVersion));

            RaiseEvent(
                new BillTransactionMessage(new PackageIdentifier(packageId, new VersionIdentifier(packageVersion)),
                    new UserIdentifier(userId), new RequestIdentifier(requestId, new SystemIdentifier(system)), date, id,
                    new StateIdentifier((int) state, state.ToString()),
                    new ContractIdentifier(contractId, new VersionIdentifier(contractVersion)),new AccountIdentifier(accountNumber)));
        }

        public static Request ReceiveRequest(Guid requestId, DataProviderIdentifier dataProvider, DateTime date,
            ConnectionTypeIdentifier connection, PayloadIdentifier payload)
        {
            return new Request(requestId, dataProvider, date, connection, payload);
        }

        public static Request ReceiveRequest(Guid requestId, DateTime date, SearchRequestIndentifier request,
            PayloadIdentifier payload)
        {
            return new Request(requestId,date,request,payload);
        }

        public static Request ReceiveRequest(Guid requestId, DateTime date, StateIdentifier state,
            PayloadIdentifier payload, SearchRequestIndentifier request)
        {
            return new Request(requestId, date, state, payload, request);
        }

     
        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderIdentifier DataProvider { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public ConnectionTypeIdentifier Connection { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }

        [DataMember]
        public CommandType CommandType { get; private set; }

        [DataMember]
        public StateIdentifier State { get; private set; }

        [DataMember]
        public SearchRequestIndentifier RequestContext { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProviderId { get; private set; }

        [DataMember]
        public PackageIdentifier Package { get; private set; }
    }
}
