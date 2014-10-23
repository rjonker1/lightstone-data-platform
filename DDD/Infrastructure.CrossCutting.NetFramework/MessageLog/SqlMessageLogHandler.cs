﻿using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging.Handling;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.MessageLog
{
    /// <summary>
    /// The SQL version of the event log runs directly in-proc 
    /// and is implemented as an event and command handler instead of a 
    /// raw message listener.
    /// </summary>
    public class SqlMessageLogHandler : IEventHandler<IEvent>, ICommandHandler<ICommand>
    {
        private SqlMessageLog log;

        public SqlMessageLogHandler(SqlMessageLog log)
        {
            this.log = log;
        }

        public void Handle(IEvent @event)
        {
            log.Save(@event);
        }

        public void Handle(ICommand command)
        {
            log.Save(command);
        }
    }
}
