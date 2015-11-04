using System.Collections.Generic;
using System.Text;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.SystemMessages;
using RabbitMQ.Client.Exceptions;
using Recoveries.Core;
using Recoveries.Domain.Base;

namespace Recoveries
{
    public class ErrorRetry : IErrorRetry
    {
        private readonly ISerializer _serializer;
        private static readonly ILog Log = LogManager.GetLogger<ErrorRetry>();

        public ErrorRetry(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void RetryErrors(IEnumerable<RecoveryMessage> rawErrorMessages, IQueueOptions options)
        {
            foreach (var rawErrorMessage in rawErrorMessages)
            {
                var error = _serializer.BytesToMessage<Error>(Encoding.UTF8.GetBytes(rawErrorMessage.Body));
                RepublishError(error, options);
            }
        }


        public void RepublishError(Error error, IQueueOptions options)
        {
            using (var connection = RabbitConnection.FromOptions(options))
            using (var model = connection.CreateModel())
            {
                try
                {
                    if (error.Exchange != string.Empty)
                    {
                        model.ExchangeDeclarePassive(error.Exchange);
                    }

                    var properties = model.CreateBasicProperties();
                    error.BasicProperties.CopyTo(properties);

                    var body = Encoding.UTF8.GetBytes(error.Message);

                    model.BasicPublish(error.Exchange, error.RoutingKey, properties, body);
                }
                catch (OperationInterruptedException)
                {
                    Log.ErrorFormat("The exchange, '{0}', described in the error message does not exist on '{1}', '{2}'",
                        error.Exchange, options.HostName, options.VirtualHost);
                }
            }
        }
    }
}