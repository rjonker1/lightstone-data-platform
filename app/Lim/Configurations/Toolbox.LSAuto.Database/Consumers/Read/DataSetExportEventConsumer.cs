using EasyNetQ;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Events;

namespace Toolbox.LightstoneAuto.Consumers.Read
{
    public class DataSetExportEventConsumer
    {
        private readonly IPersist<DataSetDto> _persist;
        private readonly IPublish _publisher;

        public DataSetExportEventConsumer(IPublish publisher, IPersist<DataSetDto> persist)
        {
            _publisher = publisher;
            _persist = persist;
        }

        public void Consume(IMessage<DataSetExportCreated> message)
        {
            message.Body.DataSet.Version = message.Body.Version;
            _persist.Persist(message.Body.DataSet);
        }

        public void Consume(IMessage<DataSetExportModified> message)
        {
            message.Body.DataSet.Version = message.Body.Version;
            _persist.Persist(message.Body.DataSet);
        }

        public void Consume(IMessage<DataSetExportDeActivated> message)
        {
            //_persist.Persist(message.Body.DataSet);
        }
    }
}
