using System;
using Lace.Test.Helper.Builders.Cmds;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Events
{
    public class when_publlishing_lace_ivid_monitoring_commands_to_bus : Specification
    {
        private readonly Guid _aggregateId;
        private Exception _exception;

        public when_publlishing_lace_ivid_monitoring_commands_to_bus()
        {
            _aggregateId = Guid.NewGuid();
        }

        public override void Observe()
        {
            try
            {
                new MonitoringCommandBuilder(_aggregateId)
              .ForIvid();
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
          
        }

        [Observation]
        public void lace_ivid_monitoring_data_provider_must_be_sent_to_message_queue()
        {
            _exception.ShouldBeNull();
        }
    }
}

