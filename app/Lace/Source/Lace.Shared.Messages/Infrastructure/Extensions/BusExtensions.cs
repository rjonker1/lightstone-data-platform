using System;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Infrastructure.Extensions
{
    public static class BusExtensions
    {
        public static void SendToBus<T>(this T message, IPublishCommandMessages publisher, ILog log) where T : class
        {
            Task.Run(() => SendMessagesAsync(message,publisher,log));
        }

        //public static ExecutingDataProviderMonitoringCommand GetCommand(this string payload, Guid id, int subOrder,
        //    int executionOrder)
        //{
        //    return
        //        new ExecutingDataProviderMonitoringCommand(new CommandDto(id, MonitoringSource.Lace,
        //            payload, DateTime.UtcNow, executionOrder, subOrder));
        //}

        public static CommandDto GetCommandDto(this string payload, Guid id, int subOrder,
            int executionOrder)
        {
            return
                new CommandDto(id, MonitoringSource.Lace,
                    payload, DateTime.UtcNow, executionOrder, subOrder);
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
