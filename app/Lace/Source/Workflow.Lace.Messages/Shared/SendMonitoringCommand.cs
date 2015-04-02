using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Workflow.Lace.Messages.Shared
{
    public class SendMonitoringCommand : ISendMonitoringCommand
    {
        private readonly IBuildMonitoringCommands _monitoring;

        public SendMonitoringCommand(IBuildMonitoringCommands monitoring)
        {
            _monitoring = monitoring;
        }

        public void Begin(dynamic payload, DataProviderStopWatch stopWatch)
        {
            _monitoring.Begin(payload, new MetadataContainer(), DisplayOrder.FirstThing);
            stopWatch.Start();
        }

        public void End(dynamic payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            _monitoring.End(payload, new PerformanceMetadata(stopWatch.ToObject()), DisplayOrder.FirstThing);
        }

        public void StartCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            _monitoring.StartCall(payload, new MetadataContainer(), DisplayOrder.FirstThing);
            stopWatch.Start();
        }

        public void EndCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            _monitoring.EndCall(payload, new PerformanceMetadata(stopWatch.ToObject()), DisplayOrder.FirstThing);
        }

        public void Send(CommandType commandType, dynamic payload, dynamic metadata)
        {
            _monitoring.SendToBus(payload, metadata, commandType);
        }
    }
}
