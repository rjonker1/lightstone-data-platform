using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Domain.Aggregates
{
    [DataContract]
    public class Request
    {
        private Request(Guid requestId)
        {
            RequestId = requestId;
        }

        public Request StartCall(Guid id,  DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Request,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            return this;
        }

        public Request EndCall(Guid id, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {

          
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Response,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();

            return this;
        }

        public Request RaiseSecurityFlag(Guid id, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Response,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            return this;
        }

        public Request Configuration(Guid id, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
        
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Request,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            return this;
        }

        public Request Transformation(Guid id, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
          
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Request,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();

            return this;
        }

        public Request Error(Guid id, DataProviderCommandSource dataProvider,
            DateTime date, CommandType commandType, string metaData, string payload, string message)
        {
           
            DataProvider = new DataProviderIdentifier(dataProvider, DataProviderAction.Request,
                DataProviderState.Failed);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier(metaData, payload, message);
            CommandType = commandType;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            return this;
        }


        public Request EntryPointRequest(DateTime date, SearchRequestIndentifier request,
            PayloadIdentifier payload)
        {
            DataProvider = new DataProviderIdentifier(DataProviderCommandSource.EntryPoint, DataProviderAction.Request,
                DataProviderState.Successful);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = payload;
            CommandType = CommandType.BeginExecution;
            State = new StateIdentifier();
            RequestContext = request;

            return this;
        }

        public Request EntryPointResponse(DateTime date, StateIdentifier state,
            PayloadIdentifier payload, SearchRequestIndentifier request)
        {
          
            DataProvider = new DataProviderIdentifier(DataProviderCommandSource.EntryPoint, DataProviderAction.Response,
                (DataProviderState)state.Id);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = payload;
            CommandType = CommandType.EndExecution;
            State = state;
            RequestContext = request;
            return this;
        }

        public Request RequestSentToDataProvider(DataProviderIdentifier dataProvider, DateTime date,
            ConnectionTypeIdentifier connection, PayloadIdentifier payload)
        {
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            Payload = payload;
            CommandType = CommandType.StartSourceCall;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            return this;
        }

        public Request ResponseReceivedFromDataProvider(DataProviderIdentifier dataProvider, DateTime date,
            ConnectionTypeIdentifier connection, PayloadIdentifier payload)
        {
            DataProvider = dataProvider;
            Date = date;
            Connection = connection;
            Payload = payload;
            CommandType = CommandType.EndSourceCall;
            State = new StateIdentifier();
            RequestContext = new SearchRequestIndentifier();
            return this;
        }

        public Request CreateTransaction(Guid packageId, long packageVersion, DateTime date, Guid userId,
            Guid contractId,
            string system, long contractVersion, DataProviderState state, string accountNumber, double packageCostPrice, double packageRecommendedPrice)
        {
            DataProvider = new DataProviderIdentifier(DataProviderCommandSource.EntryPoint, DataProviderAction.Response, state);
            Date = date;
            Connection = new ConnectionTypeIdentifier();
            Payload = new PayloadIdentifier();
            CommandType = CommandType.Accounting;
            State = new StateIdentifier((int) state, state.ToString());
            RequestContext = new SearchRequestIndentifier();
            Package = new PackageIdentifier(packageId, new VersionIdentifier(packageVersion));
            //Package.PackageCostPrice = packageCostPrice;
            //Package.PackageRecommendedPrice = packageRecommendedPrice;
            return this;
        }

        public static Request InitRequest(Guid requestId)
        {
            return new Request(requestId);
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
        public PackageIdentifier Package { get; private set; }
    }
}
