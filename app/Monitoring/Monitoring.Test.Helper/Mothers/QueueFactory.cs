using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Monitoring.Test.Helper.Mothers
{
    public class RabbitMqConsumer
    {
        public IModel Model { get; set; }
        public IConnection Connection { get; private set; }
        public string QueueName { get; private set; }

        private readonly string _hostName, _userName, _password, _exchangeName, _routingKeyName;

        public RabbitMqConsumer(string hostName, string username, string password, string exchangeName, string routingKeyName)
        {
            _hostName = hostName;
            _userName = username;
            _password = password;
            _exchangeName = exchangeName;
            _routingKeyName = routingKeyName;
        }


        public void ReadFromQueue(Action<string, RabbitMqConsumer, ulong> onDequeue,
            Action<Exception, RabbitMqConsumer, ulong> onError, string exchangeName, string queueName,
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
                ConnectToRabbitMq();
                ReadFromQueue(onDequeue, onError, exchangeName,queueName,routingKeyName);
            };

            Model.BasicConsume(queueName, false, consumer);

        }

        public void AddBindingToQueue(string queueToBindName)
        {
            ConnectToRabbitMq();
            Model.QueueBind(queueToBindName, _exchangeName, _routingKeyName);
        }

        public void PurgeQueue(string queueName)
        {
            ConnectToRabbitMq();
            Model.QueuePurge(queueName);
        }

        private void BindToQueue(string exchangeName, string queueName, string routingKeyName)
        {
            const bool durable = true, autoDelete = false, exclusive = false;
            Model.BasicQos(0,1,false);
            IDictionary<string,object> queueArgs = new Dictionary<string, object>
            {
                {"x-ha-policy","all"}
            };
            QueueName = Model.QueueDeclare(queueName, durable, exclusive, autoDelete, queueArgs);
            Model.QueueBind(queueName,exchangeName,routingKeyName);
        }

        public bool ConnectToRabbitMq()
        {
            var attempts = 0;
            while (attempts < 3)
            {
                attempts++;
                try
                {
                    var connectionFactory = new ConnectionFactory()
                    {
                        HostName = _hostName,
                        UserName = _userName,
                        Password = _password,
                        RequestedHeartbeat = 60
                    };

                    Connection = connectionFactory.CreateConnection();
                    CreateModel();
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

        private void CreateModel()
        {
            Model = Connection.CreateModel();
            Connection.AutoClose = true;
            // BasicQos(0="Dont send me a new message untill I’ve finshed",  1= "Send me one message at a time", false ="Apply to this Model only")
            Model.BasicQos(0,1,false);
            const bool durable = true, exchangeAutoDelete = true, queueAutoDelete = false, exclusive = false;

            if(string.IsNullOrWhiteSpace(_exchangeName))
                Model.ExchangeDeclare(_exchangeName, ExchangeType.Direct, durable, exchangeAutoDelete, null);

            IDictionary<string,object> queueArgs = new Dictionary<string, object>
                {
                    {"x-ha-policy", "all"}
                };
            Model.QueueDeclare(QueueName, durable, exclusive, queueAutoDelete, queueArgs);
            Model.QueueBind(QueueName, _exchangeName, _routingKeyName);
        }
    }

    
}
