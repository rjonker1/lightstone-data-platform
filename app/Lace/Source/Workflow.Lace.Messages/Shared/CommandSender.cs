using System;
using DataPlatform.Shared.Enums;
using NServiceBus;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Workflow.Lace.Messages.Shared
{
    public class CommandSender : ISendCommandToBus
    {
        public ISendWorkflowCommand Workflow { get; private set; }
        public ISendMonitoringCommand Monitoring { get; private set; }

        public CommandSender(ISendWorkflowCommand workflow, ISendMonitoringCommand monitoring)
        {
            Workflow = workflow;
            Monitoring = monitoring;
        }

        public static CommandSender InitCommandSender(IBus bus, Guid requestId, int orderOfExecution,
            DataProviderCommandSource dataProvider)
        {
            return new CommandSender(new SendWorkflowCommands(bus, requestId),
                new SendMonitoringCommand(new MonitoringCommandBuilder(bus, requestId, orderOfExecution, dataProvider)));
        }
    }
}
