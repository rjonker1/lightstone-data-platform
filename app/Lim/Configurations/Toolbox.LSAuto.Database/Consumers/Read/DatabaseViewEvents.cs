using EasyNetQ;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Events;

namespace Toolbox.LightstoneAuto.Consumers.Read
{
    public class DatabaseViewEventConsumer
    {
        private readonly IPersist<DatabaseViewDto> _persist;
        private readonly IPublish _publisher;

        public DatabaseViewEventConsumer(IPublish publisher, IPersist<DatabaseViewDto> persist)
        {
            _publisher = publisher;
            _persist = persist;
        }

        public void Consume(IMessage<DatabaseViewLoaded> message)
        {
            _persist.Persist(message.Body.DatabaseView);
        }

        public void Consume(IMessage<DatabaseViewModified> message)
        {
            _persist.Persist(message.Body.DatabaseView);
        }
    }
}