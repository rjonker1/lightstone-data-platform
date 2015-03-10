using Lace.Shared.Monitoring.Messages.Infrastructure;

namespace Lace.Shared.Monitoring.Messages.Core
{
    public interface ISendMonitoringCommandsToBus
    {
        void Begin(dynamic payload,
            DataProviderStopWatch stopWatch);

        void End(dynamic payload,
            DataProviderStopWatch stopWatch);

        void StartCall(dynamic payload,
            DataProviderStopWatch stopWatch);

        void EndCall(dynamic payload,
            DataProviderStopWatch stopWatch);

        void Send(CommandType commandType, dynamic payload, dynamic metadata);
    }
}
