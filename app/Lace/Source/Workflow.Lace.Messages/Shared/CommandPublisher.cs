using System;
using Common.Logging;
using NServiceBus;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Shared
{
    public class WorkflowCommandPublisher : IPublishCommandMessages
    {
        private readonly IBus _bus;
        private readonly ILog _log;

        public WorkflowCommandPublisher(IBus bus, ILog log)
        {
            _bus = bus;
            _log = log;
        }

        public void SendToBus<T>(T message) where T : class
        {
            try
            {
                _bus.Send(message);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error sending message to Data Provider Workflow Bus: {0}", ex.Message);
            }
        }
    }
}
