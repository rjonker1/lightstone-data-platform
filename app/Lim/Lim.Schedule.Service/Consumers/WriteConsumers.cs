using System;
using System.Collections.Generic;
using Castle.Windsor;
using EasyNetQ;
using Lim.Domain.Messaging.Messages;
using Lim.Domain.Sender.Handlers;
using Toolbox.LightstoneAuto.Consumers.Write;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Toolbox.LightstoneAuto.Domain.Commands.View;
using Toolbox.LIVE.Infrastructure.Consumers.Write;
using Toolbox.LIVE.Shared.Commands;

namespace Lim.Schedule.Service.Consumers
{
    public class WriteConsumers<T>
    {
        public static WriteConsumers<T> New(IMessage<T> message, IWindsorContainer container)
        {
            return new WriteConsumers<T>(message, container);
        }

        private WriteConsumers(IMessage<T> message, IWindsorContainer container)
        {
           Action<IWindsorContainer,IMessage<T>> consumer;
           if (_consumers.TryGetValue(typeof(T), out consumer))
                consumer(container, message);
        }

        private readonly Dictionary<Type, Action<IWindsorContainer, IMessage<T>>> _consumers = new Dictionary<Type, Action<IWindsorContainer, IMessage<T>>>
        {
            {typeof(PackageResponseMessage), (container,message) =>  container.Resolve<ResponseFromPackageConsumer>().Consume((IMessage<PackageResponseMessage>)message)},
            {typeof(SendExecutedPackage), (container, message) => container.Resolve<SendExecutedPackageConsumer>().Consume((IMessage<SendExecutedPackage>)message)},

            {typeof(CreateDataExtract), (container, message)=> container.Resolve<DatabaseExtractCommandConsumer>().Consume((IMessage<CreateDataExtract>)message)},
            {typeof(ModifyDataExtract), (container, message)=> container.Resolve<DatabaseExtractCommandConsumer>().Consume((IMessage<ModifyDataExtract>)message)},
            {typeof(DeActivateDataExtract), (container, message)=> container.Resolve<DatabaseExtractCommandConsumer>().Consume((IMessage<DeActivateDataExtract>)message)},

            {typeof(LoadView), (container, message)=> container.Resolve<DatabaseViewCommandConsumer>().Consume((IMessage<LoadView>)message)},
            {typeof(ModifyView), (container, message)=> container.Resolve<DatabaseViewCommandConsumer>().Consume((IMessage<ModifyView>)message)}

        };
    }
}