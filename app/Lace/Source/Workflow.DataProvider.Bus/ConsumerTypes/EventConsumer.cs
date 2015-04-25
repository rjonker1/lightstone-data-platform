using System;
using EasyNetQ.AutoSubscribe;

namespace Workflow.DataProvider.Bus.ConsumerTypes
{
    public class EventConsumer : IConsume<RequestToDataProvider>
    {
        public void Consume(RequestToDataProvider message)
        {
            Console.WriteLine("Received the event");
        }
    }
}
