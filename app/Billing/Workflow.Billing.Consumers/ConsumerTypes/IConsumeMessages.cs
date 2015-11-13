using EasyNetQ;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public interface IConsumeMessages<in T> where T : class
    {
        void Consume(IMessage<T> message);
    }
}