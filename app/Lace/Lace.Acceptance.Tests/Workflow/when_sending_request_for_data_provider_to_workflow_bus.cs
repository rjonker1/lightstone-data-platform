using System;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Cmds;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Workflow
{
    public class when_sending_request_for_data_provider_to_workflow_bus : Specification
    {
        private readonly Guid _requestId;
        private readonly Guid _packageId;
        private readonly Guid _contractId;
        private readonly Guid _userId;
        private readonly long _packageVersion;
        private readonly string _system;
        private readonly string _accountNumber;
        private Exception _exception;
        private readonly ISendWorkflowCommand _bus;

        public when_sending_request_for_data_provider_to_workflow_bus()
        {
            _requestId = Guid.NewGuid();
            _packageId = new Guid("E2E91BEA-B301-4CAD-A58A-425BC613C22C");
            _contractId = new Guid("5B6DC4A1-C598-4751-8274-1AE366AC061A");
            _userId = new Guid("7A6E95C4-46B6-460A-89E6-259BA6792FD0");
            _packageVersion = 1;
            _system = "API";
            _accountNumber = "UNITTEST0001";
            _bus = WorkflowBusBuilder.ForWorkflowBus(_requestId);
        }

        public override void Observe()
        {
            try
            {
                new WorkflowCommandBuilder(_bus, _packageId, _contractId, _userId, _packageVersion, _requestId, _system, _accountNumber)
                    .ForRequestReceived()
                    .ForSuccessfulCallIvid()
                    .ForSuccessfulCallLightstoneAuto()
                    .ForSuccessfulCallToIvidTitleHolder()
                    .ForSuccessfulCallRgtVin()
                    .ForSuccessfulCallRgt()
                    .ForSuccessfulCallAudatex()
                    .ForSuccessfulResponseToCaller();
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Observation]
        public void lace_worflow_ivid_commands_must_be_sent_worflow_bus()
        {
            _exception.ShouldBeNull();
        }
    }
}
