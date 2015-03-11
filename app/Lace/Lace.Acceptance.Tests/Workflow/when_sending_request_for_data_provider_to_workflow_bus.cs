using System;
using Lace.Test.Helper.Builders.Cmds;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Workflow
{
    public class when_sending_request_for_data_provider_to_workflow_bus : Specification
    {
        private readonly Guid _requestId;
        private Exception _exception;

        public when_sending_request_for_data_provider_to_workflow_bus()
        {
            _requestId = Guid.NewGuid();
        }

        public override void Observe()
        {
            try
            {
                new WorkflowCommandBuilder(_requestId).ForIvid();
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
