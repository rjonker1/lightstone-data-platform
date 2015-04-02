using System;
using DataPlatform.Shared.Enums;
using Lace.Test.Helper.Builders.Buses;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Builders.Cmds
{
    public class WorkflowCommandBuilder
    {
        private readonly Guid _requestId;
        private readonly ISendWorkflowCommand _bus;
        private readonly Guid _packageId;
        private readonly Guid _contractId;
        private readonly Guid _userId;
        private readonly long _packageVersion;
        private readonly string _system;

        public WorkflowCommandBuilder(ISendWorkflowCommand bus, Guid packageId, Guid contractId, Guid userId, long packageVersion, Guid requestId, string system)
        {
            _requestId = requestId;
            _bus = bus;
            _packageId = packageId;
            _contractId = contractId;
            _userId = userId;
            _packageVersion = packageVersion;
            _system = system;
        }

        public WorkflowCommandBuilder ForRequestReceived()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.EntryPoint);
            queue.InitQueue(_bus)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Lace",
                    "none", DataProviderAction.Request,
                    DataProviderState.Successful);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallIvid()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Ivid);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider(DateTime.Now, "Web Service",
                    "https://secure1.ubiquitech.co.za/ivid/ws/hpiService.wsdl", DataProviderAction.Request,
                    DataProviderState.Successful)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Web Service",
                    "https://secure1.ubiquitech.co.za/ivid/ws/hpiService.wsdl", DataProviderAction.Response,
                    DataProviderState.Successful);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallLightstoneAuto()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.LightstoneAuto);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider(DateTime.Now, "Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallRgt()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Rgt);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider(DateTime.Now, "Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallRgtVin()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.RgtVin);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider(DateTime.Now, "Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Request,
                    DataProviderState.Successful)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Database",
                    "Data Source=.;Initial Catalog=Auto_Carstats;Integrated Security=True;", DataProviderAction.Response,
                    DataProviderState.Successful);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallAudatex()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.Audatex);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider(DateTime.Now, "Web Service",
                    "https://mobile.za.ax-aee.co.uk/audabridge/backofficeservice.asmx", DataProviderAction.Request,
                    DataProviderState.Successful)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Web Service",
                    "https://mobile.za.ax-aee.co.uk/audabridge/backofficeservice.asmx", DataProviderAction.Response,
                    DataProviderState.Successful);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulCallToIvidTitleHolder()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.IvidTitleHolder);
            queue.InitQueue(_bus)
                .SendRequestToDataProvider(DateTime.Now, "Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Request,
                    DataProviderState.Successful)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Web Service",
                    "https://secure1.ubiquitech.co.za:443/ivid/ws/", DataProviderAction.Response,
                    DataProviderState.Successful);
            return this;
        }

        public WorkflowCommandBuilder ForSuccessfulResponseToCaller()
        {
            var queue = new WorkflowQueueSender(DataProviderCommandSource.EntryPoint);
            queue.InitQueue(_bus)
                .ReceiveResponseFromDataProvider(DateTime.Now, "Lace",
                    "none", DataProviderAction.Response,
                    DataProviderState.Successful)
                .CreateTransaction(_packageId, _packageVersion, DateTime.Now, _userId, _requestId, _contractId, _system,
                    0, DataProviderState.Successful);
            return this;
        }
    }
}
