using System;
using System.Collections.Generic;
using System.Threading;
using Lim.Core;

namespace Lim.Test.Helper.Fakes
{
    public class FakeBus : ISendCommands, IPublish
    {
        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();

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

        public void Publish<T>(T @event) where T : LimEvent
        {
            List<Action<IMessage>> handlers;
            if(!_routes.TryGetValue(@event.GetType(), out handlers)) return;
            foreach (var handler in handlers)
            {
                var handlerCopy = handler;
               // handlerCopy(@event);
                ThreadPool.QueueUserWorkItem(q => handlerCopy(@event));
            }
        }
    }
}
