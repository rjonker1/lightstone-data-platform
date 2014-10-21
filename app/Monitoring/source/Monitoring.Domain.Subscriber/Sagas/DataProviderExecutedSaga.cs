using Monitoring.Domain.Messages.Commands;
using Monitoring.Domain.Messages.Messages;
using Monitoring.Domain.Subscriber.Models;
using NServiceBus;
using NServiceBus.Saga;

namespace Monitoring.Domain.Subscriber.Sagas
{
    public class DataProviderExecutedSaga : Saga<DataProviderEvents>,
        IAmStartedByMessages<DataProviderExecutedCommand>, IHandleMessages<MessageConsumedCommand>,
        IHandleTimeouts<MessageConsumedCommand>
    {

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<DataProviderEvents> mapper)
        {
            mapper.ConfigureMapping<DataProviderExecutedCommand>(m => m.EventId).ToSaga(m => m.EventId);

            mapper.ConfigureMapping<DataProviderEvents>(s => s.EventNumber).ToSaga(s => s.EventNumber);
        }

        public void Handle(DataProviderExecutedCommand message)
        {
            Data.AggregateId = message.AggregateId;
            Data.Event = message.Data;
            Data.EventId = message.EventId;
        }

        public void Handle(MessageConsumedCommand message)
        {
            message.IsConsumed();

            Bus.Publish<CommandHasBeenConsumed>(y =>
            {
                y.AggregateId = message.AggregateId;
                y.EventId = message.EventId;
                y.IsTrue = message.HasBeenConsumed;
            });

            MarkAsComplete();
        }

        public void Timeout(MessageConsumedCommand state)
        {
            MarkAsComplete();

            state.IsNotConsumed();

            Bus.Publish<CommandHasBeenConsumed>(y =>
            {
                y.AggregateId = state.AggregateId;
                y.EventId = state.EventId;
                y.IsTrue = state.HasBeenConsumed;
            });
        }
    }
}
