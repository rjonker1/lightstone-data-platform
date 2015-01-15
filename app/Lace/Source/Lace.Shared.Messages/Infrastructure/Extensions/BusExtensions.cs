using System;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Infrastructure.Extensions
{
    internal static class BusExtensions
    {
        internal static void SendToBus<T>(this T message, IPublishCommandMessages publisher, ILog log) where T : class
        {
            Task.Run(() => SendMessagesAsync(message,publisher,log));
        }
        
        internal static DataProviderCommandEnvelope GetCommand(this string payload, Guid id, int subOrder,
            int executionOrder)
        {
            return
                new DataProviderCommandEnvelope(new CommandDto(id, MonitoringSource.Lace,
                    payload, DateTime.UtcNow, executionOrder, subOrder));
        }

        private static void SendMessagesAsync<T>(T message, IPublishCommandMessages publisher, ILog log) where T : class
        {
            try
            {
                publisher.SendToBus(message);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error sending message to Data Provider Message Bus: {0}", ex.Message);
            }
        }
    }
}
