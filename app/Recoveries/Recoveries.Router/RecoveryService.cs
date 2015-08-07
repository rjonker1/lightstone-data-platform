using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Consumer;
using EasyNetQ.Topology;
using Recoveries.Core;
using Recoveries.ErrorQueues;
using Recoveries.ErrorQueues.Messages;
using Recoveries.Router.Consumers;

namespace Recoveries.Router
{
    public interface IRecoveryService
    {
        void Start();
        void Stop();
    }

    public class RecoveryService : IRecoveryService
    {
        private readonly ILog _log = LogManager.GetLogger<RecoveryService>();
        private readonly IHandleErrorMessageRecovery _errorMessageRecoveryHandler;
        private readonly IAdvancedBus _bus;
        private readonly IQueue _queue;
        private readonly IExchange _exchange;
        private readonly IWindsorContainer _container;

        private readonly string _queueName = AppSettingsReader.GetString("dataplatform/queues/recoveries/receiver", () => "Dataplatform.DataProvider.Recoveries.Reciever");
        private readonly string _exchangeName = AppSettingsReader.GetString("dataplatform/queues/recoveries/exchange", () => "Dataplatform.DataProvider.Recoveries.Reciever");

        public RecoveryService(IAdvancedBus bus, IWindsorContainer container)
        {
            _bus = bus;
            _container = container;
            _queue = _bus.QueueDeclare(_queueName);
            _exchange = _bus.ExchangeDeclare(_exchangeName, ExchangeType.Fanout);
        }

        private RecoveryService(IHandleErrorMessageRecovery errorMessageRecoveryHandler)
        {
            _errorMessageRecoveryHandler = errorMessageRecoveryHandler;
        }

        public void Start()
        {
            _log.InfoFormat("Starting Recovery Service");
            
            var service = new RecoveryService(ErrorMessageRecoveryHandler.Create());
            service.ProcessExisting();

            BindQueues();
            BindConsumers();

            _log.InfoFormat("Recovery Service Started");
        }

        private void ProcessExisting()
        {
            _errorMessageRecoveryHandler.HandleAll(ConfigurationReader.Configurations);
        }

        private void BindQueues()
        {
            _bus.Bind(_exchange, _queue, string.Empty);
        }

        private void BindConsumers()
        {
            //_bus.Consume(_queue,
            //    consumers => consumers
            //        .Add<RetryErrorsOnAllQueuesMessage>((message, info) => new RetryErrorsOnAllQueuesConsumer())
            //        .Add<RetryErrorsOnAQueueMessage>((message, info) => new RetryErrorsOnAQueuesConsumer()));
            _bus.Consume(_queue,
                consumers => consumers
                    .Add<RetryErrorsOnAllQueuesMessage>((message, info) => new ConsumerFactory<RetryErrorsOnAllQueuesMessage>(message, _container))
                    .Add<RetryErrorsOnAQueueMessage>((message, info) => new ConsumerFactory<RetryErrorsOnAQueueMessage>(message, _container)));
        }

        public void Stop()
        {

        }
    }
}