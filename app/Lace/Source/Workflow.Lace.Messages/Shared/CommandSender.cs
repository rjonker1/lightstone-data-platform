﻿using System;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Shared
{
    public class CommandSender : ISendCommandToBus
    {
        public ISendWorkflowCommand Workflow { get; private set; }

        public CommandSender(ISendWorkflowCommand workflow)
        {
            Workflow = workflow;
        }

        public static CommandSender InitCommandSender(IAdvancedBus bus, Guid requestId,
            DataProviderCommandSource dataProvider)
        {
            return new CommandSender(new SendWorkflowCommands(bus, requestId));
        }
    }
}
