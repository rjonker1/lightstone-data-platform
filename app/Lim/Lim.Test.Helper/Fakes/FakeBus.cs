using System;
using System.Collections.Generic;
using System.Threading;
using EasyNetQ;
using Lim.Core;
using IMessage = Lim.Core.IMessage;

namespace Lim.Test.Helper.Fakes
{
    public class FakeBus : ISendCommand, IPublish
    {
        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();
        private readonly Dictionary<Type, List<Action<IMessage<IMessage>>>> _routeConsumers = new Dictionary<Type, List<Action<IMessage<IMessage>>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : IMessage
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(typeof (T), out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add((h => handler((T)h)));
        }

        public void RegisterConsumer<T>(Action<T> consumer) where T : IMessage<IMessage>
        {
            List<Action<IMessage<IMessage>>> handlers;
            if (!_routeConsumers.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessage<IMessage>>>();
                _routeConsumers.Add(typeof(T), handlers);
            }

            handlers.Add((h => consumer((T)h)));
        }

        public void Send<T>(T command) where T : Command
        {
            List<Action<IMessage>> handlers;
            if (_routes.TryGetValue(typeof (T), out handlers))
            {
                if(handlers.Count != 1) 
                    throw new InvalidOperationException("Cannot send message to more than one handler");
                handlers[0](command);
            }
            else
            {
                throw new InvalidOperationException("There is no handler registered to handle " + command.GetType());
            }
        }

        public void Publish<T>(T @event) where T : IMessage
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(@event.GetType(), out handlers));

            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    var handlerCopy = handler;
                    //handlerCopy(@event);
                    ThreadPool.QueueUserWorkItem(q => handlerCopy(@event));
                }
            }

            List<Action<IMessage<IMessage>>> consumers;
            if (!_routeConsumers.TryGetValue(@event.GetType(), out consumers)) return;
            foreach (var consumer in consumers)
            {
                var consumerCopy = consumer;
               // consumerCopy(new Message<EasyNetQ.IMessage>(@event));
                ThreadPool.QueueUserWorkItem(q => consumerCopy(new Message<IMessage>(@event)));
                Thread.Sleep(2000);
            }
        }
    }
}
