using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Monitoring.Queuing.Configuration;
using Monitoring.Queuing.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Monitoring.Queuing.RabbitMq
{
    public class RabbitConsumer : IConsumeQueue, IDisposable
    {
        public IModel Model { get; set; }
        public IConnection Connection { get; private set; }
        public string QueueName { get; private set; }

        private readonly bool _useCredentials;

        private readonly string _hostName, _userName, _password; // _exchangeName, _routingKeyName;

        private const bool Durable = true,
            AutoDelete = false,
            Exclusive = false,
            ExchangeAutoDelete = false,
            QueueAutoDelete = false;

        public RabbitConsumer()
        {

        }

        public RabbitConsumer(string hostName, string username, string password, bool useCredentials = false)
        {
            _hostName = hostName;
            _userName = username;
            _password = password;
            _useCredentials = useCredentials;
        }

        public void ReadFromQueue(Action<string, RabbitConsumer, ulong> onDequeue,
            Action<Exception, RabbitConsumer, ulong> onError, string exchangeName, string queueName,
            string routingKeyName, string exchangeType)
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
                ConnectToRabbitMq(exchangeName, routingKeyName, queueName, exchangeType);
                ReadFromQueue(onDequeue, onError, exchangeName, queueName, routingKeyName, exchangeType);
            };

            Model.BasicConsume(queueName, false, consumer);

        }

        public void AddBindingToAQueue(MonitoringQueue bindingToQueue, string queueName, string exchangeName,
            string routingKeyName, string exchangeType)
        {
            ConnectToRabbitMq(bindingToQueue.ExchangeName, bindingToQueue.RoutingKey, bindingToQueue.QueueName,
                exchangeType);
            BindToQueue(bindingToQueue.ExchangeName, bindingToQueue.QueueName, bindingToQueue.RoutingKey);
            Model.QueueBind(queueName, bindingToQueue.ExchangeName, bindingToQueue.RoutingKey);
        }

        public void AddExchangeBindingToQueue(MonitoringQueue bindingToQueue, string exchangeName,
            string routingKeyName)
        {
            ConnectToRabbitMq(bindingToQueue.ExchangeName, bindingToQueue.RoutingKey, bindingToQueue.QueueName,
                bindingToQueue.ExchangeType);
            BindToQueue(bindingToQueue.ExchangeName, bindingToQueue.QueueName, bindingToQueue.RoutingKey);
            //Model.ExchangeBind(bindingToQueue.QueueName,exchangeName,routingKeyName);
            Model.QueueBind(bindingToQueue.QueueName, exchangeName, routingKeyName);
        }

        public void PurgeQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType)
        {
            ConnectToRabbitMq(exchangeName, routingKeyName, queueName, exchangeType);
            BindToQueue(exchangeName, queueName, routingKeyName);
            Model.QueuePurge(queueName);
        }

        public void DeleteQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType)
        {
            ConnectToRabbitMq(exchangeName, routingKeyName, queueName, exchangeType);
            Model.QueueDelete(queueName);
            Model.ExchangeDelete(exchangeName);
        }

        public void AddQueue(string queueName, string exchangeName, string routingKeyName, string exchangeType)
        {
            ConnectToRabbitMq(exchangeName, routingKeyName, queueName, exchangeType);
            BindToQueue(exchangeName, queueName, routingKeyName);
        }

        public int MessageCount(string queueName, string exchangeName, string routingKeyName, string exchangeType)
        {
            Model.BasicQos(0, 1, false);
            var result = Model.QueueDeclare(queueName, Durable, Exclusive, AutoDelete, null);
            return result != null ? (int) result.MessageCount : 0;
        }

        public void DeleteExchange(string exchangeName, string exchangeType)
        {
            ConnectToRabbitMq(exchangeName, null, null, exchangeType,true);
            Model.ExchangeDelete(exchangeName);
        }

        public void AddExchange(string exchangeName, string exchangeType)
        {
            ConnectToRabbitMq(exchangeName, null, null, exchangeType, true);
        }

        private void BindToQueue(string exchangeName, string queueName, string routingKeyName)
        {
            Model.BasicQos(0, 1, false);
            //IDictionary<string, object> queueArgs = new Dictionary<string, object>
            //{
            //    {"x-ha-policy", "all"}
            //};
            QueueName = Model.QueueDeclare(queueName, Durable, Exclusive, AutoDelete, null);
            Model.QueueBind(queueName, exchangeName, routingKeyName);
        }

        private bool ConnectToRabbitMq(string exchangeName, string routingKeyName, string queueName, string exchangeType, bool exchangeOnly = false)
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

                    if (!exchangeOnly)
                        CreateModel(exchangeName, routingKeyName, queueName, exchangeType);
                    else
                        CreateModel(exchangeName, exchangeType);

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

        private void CreateModel(string exchangeName, string exchangeType)
        {
            Model = Connection.CreateModel();
            Connection.AutoClose = true;
            Model.BasicQos(0, 1, false);

            if (!string.IsNullOrWhiteSpace(exchangeName))
                Model.ExchangeDeclare(exchangeName, exchangeType, Durable, ExchangeAutoDelete, null);
        }

        private void CreateModel(string exchangeName, string routingKeyName, string queueName, string exchangeType)
        {
            Model = Connection.CreateModel();
            Connection.AutoClose = true;
            // BasicQos(0="Dont send me a new message untill I’ve finshed",  1= "Send me one message at a time", false ="Apply to this Model only")
            Model.BasicQos(0, 1, false);

            if (!string.IsNullOrWhiteSpace(exchangeName))
                Model.ExchangeDeclare(exchangeName, exchangeType, Durable, ExchangeAutoDelete, null);

            IDictionary<string, object> queueArgs = new Dictionary<string, object>
            {
                {"x-ha-policy", "all"}
            };
            Model.QueueDeclare(queueName, Durable, Exclusive, QueueAutoDelete, null);
            Model.QueueBind(queueName, exchangeName, routingKeyName);
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();

            if (Model != null)
                Model.Abort();
        }
    }
}
