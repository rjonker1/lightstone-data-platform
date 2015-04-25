using System;
using Castle.Windsor;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Monitoring.Domain.Repository;

namespace Workflow.DataProvider.Bus.ConsumerTypes
{

    public class CommandConsumers<T>
    {
        public CommandConsumers(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<SendRequestToDataProviderCommand>) container.Resolve<CommandConsumer>().Consume(message as IMessage<SendRequestToDataProviderCommand>);
        }
    }

    public class CommandConsumer //: IConsume<SendRequestToDataProviderCommand>
    {

        public CommandConsumer()
        {

        }

        public void Consume(IMessage<SendRequestToDataProviderCommand> message)
        {
            Console.WriteLine("Received the command");
            Request.ReceiveRequest(message.Body.Id, message.Body.Date);
            Console.WriteLine("Sent event to queue");
        }

        //public void Consume(SendRequestToDataProviderCommand message)
        //{
        //    Console.WriteLine("Received the command");
        //    Request.ReceiveRequest(message.Id, message.Date);
        //    Console.WriteLine("Sent event to queue");
        //}
    }
}
