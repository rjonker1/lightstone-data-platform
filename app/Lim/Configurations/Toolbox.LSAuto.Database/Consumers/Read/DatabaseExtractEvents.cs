using EasyNetQ;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Events;

namespace Toolbox.LightstoneAuto.Consumers.Read
{
    public class DatabaseExtractEventConsumer
    {
        private readonly IPersist<DatabaseExtractDto> _persist;
        private readonly IPublish _publisher;

        public DatabaseExtractEventConsumer(IPublish publisher, IPersist<DatabaseExtractDto> persist)
        {
            _publisher = publisher;
            _persist = persist;
        }

        public void Consume(IMessage<DatabaseExtractCreated> message)
        {
            message.Body.DatabaseExtract.Version = message.Body.Version;
            _persist.Persist(message.Body.DatabaseExtract);
        }

        public void Consume(IMessage<DatabaseExtractModified> message)
        {
            message.Body.DatabaseExtract.Version = message.Body.Version;
            _persist.Persist(message.Body.DatabaseExtract);
        }

        public void Consume(IMessage<DatabaseExtractDeActivated> message)
        {
            //_persist.Persist(message.Body.DataSet);
        }
    }
}
