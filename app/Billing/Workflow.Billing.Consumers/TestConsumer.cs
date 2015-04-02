using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using EasyNetQ.AutoSubscribe;
using Workflow.Billing.Domain;
using Workflow.Billing.Messages;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumers
{
    public class TestConsumer : IConsume<TestMessage>
    {

        public void Consume(TestMessage message)
        {
        }
    }
}
