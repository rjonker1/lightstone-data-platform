﻿using EasyNetQ.AutoSubscribe;
using Lace.Events.Messages;

namespace Lace.Events.Tests.Consumers
{
    public class LaceEventMessageConsumer : IConsume<ILaceEventMessage>
    {
        public bool WasInvoked { get; private set; }

        public void Consume(ILaceEventMessage message)
        {
            WasInvoked = true;
           
        }
    }
}
