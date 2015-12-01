using System.Text;
using EasyNetQ;
using Monitoring.Domain;
using Monitoring.Domain.Identifiers;
using Monitoring.Domain.Repository;
using Workflow.Lace.Messages.Indicators;

namespace Workflow.Transactions.Receiver.Service.Handlers
{
    public class IndicatorReceiver
    {
        private readonly IMonitoringRepository _monitoring;

        public IndicatorReceiver(IMonitoringRepository monitoring)
        {
            _monitoring = monitoring;
        }

        public void Consume(IMessage<ExecutionDetailForDataProvider> message)
        {
            var indicator = new MonitoringDataProviderExecution(
                new DataProviderCommandIdentifier(message.Body.Command.Id, message.Body.Command.Name),
                new DataProviderIdentifier(message.Body.RequestId, "", message.Body.DataProvider.Name, (short) message.Body.DataProvider.Id),
                message.Body.ElapsedTime);
            _monitoring.Add(indicator);
        }

        public void Consume(IMessage<RequestFieldsForDataProvider> message)
        {
            var indicator = new MonitoringDataProviderRequestField(
                new DataProviderIdentifier(message.Body.RequestId, message.Body.PackageName, message.Body.DataProvider.Name, (short)message.Body.DataProvider.Id),
                new RequestFieldIdentifier(Encoding.UTF8.GetBytes(message.Body.RequestField.Payload ?? "{}")));
            _monitoring.Add(indicator);
        }
    }
}
