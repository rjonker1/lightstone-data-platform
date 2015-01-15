﻿using System;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;
using NServiceBus.Features;

namespace Lace.Test.Helper.Builders.Buses
{
    public class BusBuilder
    {
        public static ISendCommandsToBus ForIvidCommands(Guid aggregateId)
        {
            var bus = BusFactory.NServiceRabbitMqBus();
            return new SendIvidCommands(bus, aggregateId, (int) ExecutionOrder.First);
        }
    }

    public class BusFactory
    {
        public static IBus NServiceRabbitMqBus()
        {
            var configuration = new BusConfiguration();
            
            configuration.UseTransport<RabbitMQTransport>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.EndpointName("DataPlatform.Monitoring.Host");
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Commands"));
            //.DefiningEventsAs(
            //    c => c.Namespace != null && c.Namespace.StartsWith("Monitoring.Domain.Messages.Events"))
            //.DefiningMessagesAs(
            //    m => m.Namespace != null && m.Namespace.StartsWith("Monitoring.Domain.Messages.Messages"));
            //configuration.EnableFeature<Sagas>();
            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
