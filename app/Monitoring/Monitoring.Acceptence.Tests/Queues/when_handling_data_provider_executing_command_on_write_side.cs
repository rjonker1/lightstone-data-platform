using Lace.Domain.Core.Requests.Contracts;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Publisher;
using Lace.Shared.Monitoring.Messages.RabbitMQ;
using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;
using Monitoring.Test.Helper.Builder.DataProviderRequests;
using Monitoring.Test.Helper.Messages;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Queues
{
    public class when_handling_data_provider_executing_command_on_write_side : Specification
    {

        private readonly RabbitMqMessageQueueing _messageQueue;
        private readonly IHaveQueueActions _setup;
        private readonly DataProviderExecutingCommand _command;
        private readonly ILaceRequest _request;
        private readonly DataProviderMessagePublisher _publisher;

        public when_handling_data_provider_executing_command_on_write_side()
        {
            _messageQueue = new RabbitMqMessageQueueing();
            _setup = new QueueActions(_messageQueue.Consumer);
            _setup.DeleteAllQueues();
            _setup.AddAllQueues();
            _request = new DataProviderLicensePlateNumberRequest();
            _publisher = new DataProviderMessagePublisher(Test.Helper.Mothers.BusFactory.NServiceRabbitMqBus());
        }


        public override void Observe()
        {
           
        }

        [Observation]
        public void then_start_executing_ivid_data_provider_request_should_be_handled()
        {
           
        }
    }
}
