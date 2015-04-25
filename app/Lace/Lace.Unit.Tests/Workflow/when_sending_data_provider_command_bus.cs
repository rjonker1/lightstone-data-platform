using System;
using System.Runtime.Serialization;
using EasyNetQ;
using Workflow.DataProvider.Bus;
using Workflow.DataProvider.Bus.Domain.Publisher;
using Xunit.Extensions;
using BusFactory = Workflow.BuildingBlocks.BusFactory;

namespace Lace.Unit.Tests.Workflow
{
    public class when_sending_data_provider_command_bus : Specification
    {
        private readonly SendRequestToDataProviderCommand _command;
        private readonly IAdvancedBus _bus;
        private Exception _exception; 

       
        public when_sending_data_provider_command_bus()
        {
            _command = new SendRequestToDataProviderCommand(Guid.NewGuid(), DateTime.Now);
            _bus = BusFactory.CreateAdvancedBus("workflow/dataprovider/queue");
        }
        public override void Observe()
        {
            try
            {
                new DataProviderEventBus(_bus).Send(_command, "DataPlatform.DataProvider.Commands", "DataPlatform.DataProvider.Commands");
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Observation]
        public void then_message_should_be_published_to_bus()
        {
            _exception.ShouldBeNull();
        }
    }
}
