using EasyNetQ.AutoSubscribe;

namespace Workflow.Billing.Consumers
{
    public class SqlServerConnectionController<TMessage> where TMessage : class
    {
        private readonly IConsume<TMessage> nextConsumer;

        public SqlServerConnectionController(IConsume<TMessage> nextConsumer)
        {
            this.nextConsumer = nextConsumer;
        }
    }
}