using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;

namespace Workflow.Reporting.Consumers.ConsumerTypes
{
    public class ReportConsumer
    {
        public void Consume(IMessage<ReportMessage> message)
        {
            
        } 
    }
}