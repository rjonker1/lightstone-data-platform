﻿using System;
using CommonDomain.Core;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Events;

namespace Monitoring.DomainModel.DataProviders
{
    public class IvidMonitoringEvents : AggregateBase
    {
        private IvidMonitoringEvents(Guid id)
        {
            Id = id;
            Register<IvidExecutionHasStarted>(e => Id = id);
            Register<IvidExcutionHasEnded>(e => Id = id);
            Register<IvidDataSourceCallHasStarted>(e => Id = id);
            Register<IvidDataSourceCallHasEnded>(e => Id = id);
            Register<IvidSecurityFlag>(e => Id = id);
            Register<IvidConfigured>(e => Id = id);
            Register<IvidResponseTransformed>(e => Id = id);
        }

        public IvidMonitoringEvents(ICommand message) : this(message.Id)
        {
            
        }

        public void Apply(StartIvidExecution message)
        {
            RaiseEvent(new IvidExecutionHasStarted(message.Id, message.DataProviderCommandSource, message.Message,
                message.Payload, message.MetaData, message.Date, message.Category));
        }

        public void Apply(EndIvidExcution message)
        {
            RaiseEvent(new IvidExcutionHasEnded(message.Id, message.DataProviderCommandSource, message.Message,
                message.Payload, message.MetaData, message.Date, message.Category));
        }

        public void Apply(StartIvidDataSourceCall message)
        {
            RaiseEvent(new IvidDataSourceCallHasStarted(message.Id, message.DataProviderCommandSource, message.Message,
                message.Payload, message.MetaData, message.Date, message.Category));
        }


        public void Apply(EndIvidDataSourceCall message)
        {
            RaiseEvent(new IvidDataSourceCallHasEnded(message.Id, message.DataProviderCommandSource, message.Message,
                message.Payload, message.MetaData, message.Date, message.Category));
        }


        public void Apply(RaiseIvidSecurityFlag message)
        {
            RaiseEvent(new IvidSecurityFlag(message.Id, message.DataProviderCommandSource, message.Message,
                message.Payload, message.MetaData, message.Date, message.Category));
        }

        public void Apply(ConfigureIvid message)
        {
            RaiseEvent(new IvidConfigured(message.Id, message.DataProviderCommandSource, message.Message,
                message.Payload, message.MetaData, message.Date, message.Category));
        }

        public void Apply(TrasformIvidResponse message)
        {
            RaiseEvent(new IvidResponseTransformed(message.Id, message.DataProviderCommandSource, message.Message,
                message.Payload, message.MetaData, message.Date, message.Category));
        }


    }
}
