using EasyNetQ;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Events;

namespace Toolbox.LightstoneAuto.Consumers.Read
{
    public class ViewImportEventConsumer
    {
        private readonly IPersist<ViewDto> _persist;
        private readonly IPublish _publisher;

        public ViewImportEventConsumer(IPublish publisher, IPersist<ViewDto> persist)
        {
            _publisher = publisher;
            _persist = persist;
        }

        public void Consume(IMessage<ViewImportCreated> message)
        {
            _persist.Persist(message.Body.View);
        }

        public void Consume(IMessage<ViewImportModified> message)
        {
            _persist.Persist(message.Body.View);
        }

        public void Consume(IMessage<ViewImportReloaded> message)
        {
            _persist.Persist(message.Body.View);
        }

        public void Consume(IMessage<ViewImportDeActivated> message)
        {
           // _persist.Persist(message.Body.View);
        }
    }
}