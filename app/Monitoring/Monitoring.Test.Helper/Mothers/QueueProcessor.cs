using System;

namespace Monitoring.Test.Helper.Mothers
{
    public class QueueProcessor
    {
        private readonly string _exchangeName;
        private readonly string _queueName;
        private readonly string _hostName;
        private readonly string _usernName;
        private readonly string _password;
        private readonly string _routingKeyName;

        public QueueProcessor(string exchangeName, string queueName, string hostName, string userName, string password, string routingKeyName)
        {
            _exchangeName = exchangeName;
            _queueName = queueName;
            _hostName = hostName;
            _usernName = userName;
            _password = password;
            _routingKeyName = routingKeyName;
        }

        private void ProcessQueue()
        {
            var consumer = new RabbitMqConsumer(_hostName,_usernName,_password,_exchangeName,_routingKeyName);
            consumer.ReadFromQueue(ProcessMessage, RaiseException, _exchangeName, _queueName, string.Empty);
        }

        private void ProcessMessage(string message, RabbitMqConsumer consumer, ulong deliveryTag)
        {
            
        }

        private void RaiseException(Exception ex, RabbitMqConsumer consumer, ulong deliveryTag)
        {
           
        }
    }
}
