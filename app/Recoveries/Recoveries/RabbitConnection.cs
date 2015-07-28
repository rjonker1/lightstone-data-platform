using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace Recoveries
{
    public class RabbitConnection
    {
        public static IConnection FromOptions(IQueueOptions options)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = options.HostName,
                VirtualHost = options.VirtualHost,
                UserName = options.Username,
                Password = options.Password
            };

            try
            {
                return connectionFactory.CreateConnection();
            }
            catch (BrokerUnreachableException)
            {
                throw new EasyNetQException(
                    string.Format("The broker at '{0}', VirtualHost '{1}', is unreachable. This message can also be caused by incorrect credentials.",
                        options.HostName, options.VirtualHost));
            }
        }
    }
}