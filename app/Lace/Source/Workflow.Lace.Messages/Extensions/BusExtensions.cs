using System;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Extensions
{
    public static class BusExtensions
    {
        public static void SendToBus<T>(this T message, IPublishCommandMessages publisher, ILog log) where T : class
        {
            Task.Run(() => SendMessagesAsync(message, publisher, log));
            //SendMessagesAsync(message, publisher, log);
        }

        private static void SendMessagesAsync<T>(T message, IPublishCommandMessages publisher, ILog log) where T : class
        {
            try
            {
                publisher.SendToBus(message);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error sending message to Data Provider Workflow Bus: {0}", ex.Message);
            }
        }
    }
}
