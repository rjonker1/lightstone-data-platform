﻿using System.Collections.Generic;
using System.Text;
using Common.Logging;
using EasyNetQ;
using RabbitMQ.Client.Exceptions;
using Recoveries.Core;
using Recoveries.Domain.Base;

namespace Recoveries
{
    public class QueueRetrieval : IQueueRetrieval
    {
        private readonly ILog _log = LogManager.GetLogger<QueueRetrieval>();

        public IEnumerable<RecoveryMessage> GetMessagesFromQueue(IQueueOptions options)
        {
            using (var connection = RabbitConnection.FromOptions(options))
            using (var channel = connection.CreateModel())
            {
                try
                {
                    channel.QueueDeclarePassive(options.ErrorQueueName);
                }
                catch (OperationInterruptedException exception)
                {
                    _log.ErrorFormat("Error Occurred Getting a message from queue because {0}", exception, exception.Message);
                    yield break;
                }

                var count = 0;
                while (count++ < options.MaxNumberOfMessagesToRetrieve)
                {
                    var basicGetResult = channel.BasicGet(options.ErrorQueueName, noAck: options.RequireHandshake);
                    if (basicGetResult == null) break; // no more messages on the queue

                    var properties = new MessageProperties(basicGetResult.BasicProperties);
                    var info = new MessageReceivedInfo(
                        "recoveries",
                        basicGetResult.DeliveryTag,
                        basicGetResult.Redelivered,
                        basicGetResult.Exchange,
                        basicGetResult.RoutingKey,
                        options.ErrorQueueName);

                    yield return new RecoveryMessage(Encoding.UTF8.GetString(basicGetResult.Body), properties, info);
                }
            }
        }
    }
}