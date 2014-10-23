using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Serialization;

namespace Infrastructure.Sql.Messaging
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class EventBus : IEventBus
    {
        private readonly IMessageSender _sender;
        private readonly ITextSerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBus"/> class.
        /// </summary>
        /// <param name="serializer">The serializer to use for the message body.</param>
        public EventBus(IMessageSender sender, ITextSerializer serializer)
        {
            _sender = sender;
            _serializer = serializer;
        }

        /// <summary>
        /// Sends the specified event.
        /// </summary>
        public void Publish(Envelope<IEvent> @event)
        {
            var message = BuildMessage(@event);

            this._sender.Send(message);
        }

        /// <summary>
        /// Publishes the specified events.
        /// </summary>
        public void Publish(IEnumerable<Envelope<IEvent>> events)
        {
            var messages = events.Select(e => BuildMessage(e));

            this._sender.Send(messages);
        }

        private Message BuildMessage(Envelope<IEvent> @event)
        {
            using (var payloadWriter = new StringWriter())
            {
                this._serializer.Serialize(payloadWriter, @event.Body);
                return new Message(payloadWriter.ToString(), correlationId: @event.CorrelationId);
            }
        }
    }
}
