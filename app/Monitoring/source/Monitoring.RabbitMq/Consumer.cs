using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Monitoring.CrossCutting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Monitoring.RabbitMq
{
    public class Consumer : IConsumeMessagesFromQueue
    {
        public IModel Model { get; set; }
        public IConnection Connection { get; private set; }
        public string QueueName { get; private set; }

        private readonly bool _useCredentials;

        private readonly string _hostName, _userName, _password; // _exchangeName, _routingKeyName;

        public Consumer(string hostName, string username, string password, bool useCredentials = false)
        {
            _hostName = hostName;
            _userName = username;
            _password = password;
            _useCredentials = useCredentials;
        }

        public void ReadFromQueue(Action<string, Consumer, ulong> onDequeue,
            Action<Exception, Consumer, ulong> onError, string exchangeName, string queueName,
            string routingKeyName)
        {
            BindToQueue(exchangeName, queueName, routingKeyName);

            var consumer = new EventingBasicConsumer(Model);

            consumer.Received += (o, e) =>
            {
                var queuedMessage = Encoding.ASCII.GetString(e.Body);
                onDequeue.Invoke(queuedMessage, this, e.DeliveryTag);
            };

            consumer.Shutdown += (o, e) =>
            {
                ConnectToRabbitMq(exchangeName, routingKeyName,queueName);
                ReadFromQueue(onDequeue, onError, exchangeName, queueName, routingKeyName);
            };

            Model.BasicConsume(queueName, false, consumer);

        }

        public void AddBindingToAQueue(DataProviderQueue bindingToQueue, string queueName, string exchangeName,
            string routingKeyName)
        {
            ConnectToRabbitMq(bindingToQueue.Exchange, bindingToQueue.RoutingKey, bindingToQueue.Name);
            BindToQueue(bindingToQueue.Exchange, bindingToQueue.Name, bindingToQueue.RoutingKey);
            Model.QueueBind(queueName, bindingToQueue.Exchange, bindingToQueue.RoutingKey);
        }

        public void PurgeQueue(string queueName, string exchangeName, string routingKeyName)
        {
            ConnectToRabbitMq(exchangeName, routingKeyName,queueName);
            BindToQueue(exchangeName, queueName, routingKeyName);
            Model.QueuePurge(queueName);
        }

        public void DeleteQueue(string queueName, string exchangeName, string routingKeyName)
        {
            ConnectToRabbitMq(exchangeName, routingKeyName,queueName);
            Model.QueueDelete(queueName);
            Model.ExchangeDelete(exchangeName);
        }

        public void AddQueue(string queueName, string exchangeName, string routingKeyName)
        {
            ConnectToRabbitMq(exchangeName, routingKeyName, queueName);
            BindToQueue(exchangeName, queueName, routingKeyName);
        }

        private void BindToQueue(string exchangeName, string queueName, string routingKeyName)
        {
            const bool durable = true, autoDelete = false, exclusive = false;
            Model.BasicQos(0, 1, false);
            //IDictionary<string, object> queueArgs = new Dictionary<string, object>
            //{
            //    {"x-ha-policy", "all"}
            //};
           QueueName = Model.QueueDeclare(queueName, durable, exclusive, autoDelete, null);
           Model.QueueBind(queueName, exchangeName, routingKeyName);
        }

        private bool ConnectToRabbitMq(string exchangeName, string routingKeyName, string queueName)
        {
            var attempts = 0;
            while (attempts < 3)
            {
                attempts++;
                try
                {

                    var connectionFactory = _useCredentials
                        ? new ConnectionFactory()
                        {
                            HostName = _hostName,
                            UserName = _userName,
                            Password = _password,
                            RequestedHeartbeat = 60
                        }
                        : new ConnectionFactory()
                        {
                            HostName = _hostName,
                            RequestedHeartbeat = 60
                        };

                    Connection = connectionFactory.CreateConnection();
                    CreateModel(exchangeName, routingKeyName, queueName);
                    return true;
                }
                catch (System.IO.EndOfStreamException ex)
                {
                    return false;
                }
                catch (BrokerUnreachableException ex)
                {
                    return false;
                }

                Thread.Sleep(1000);
            }

            if (Connection != null)
                Connection.Dispose();

            return false;
        }

        private void CreateModel(string exchangeName, string routingKeyName, string queueName)
        {
            Model = Connection.CreateModel();
            Connection.AutoClose = true;
            // BasicQos(0="Dont send me a new message untill I’ve finshed",  1= "Send me one message at a time", false ="Apply to this Model only")
            Model.BasicQos(0, 1, false);
            const bool durable = true, exchangeAutoDelete = false, queueAutoDelete = false, exclusive = false;

            if (!string.IsNullOrWhiteSpace(exchangeName))
                Model.ExchangeDeclare(exchangeName, ExchangeType.Fanout, durable, exchangeAutoDelete, null);

            IDictionary<string, object> queueArgs = new Dictionary<string, object>
            {
                {"x-ha-policy", "all"}
            };
            Model.QueueDeclare(queueName, durable, exclusive, queueAutoDelete, null);
            Model.QueueBind(queueName, exchangeName, routingKeyName);
        }
    }
}
