using System.Linq;
using EasyNetQ;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Base;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Toolbox.LightstoneAuto.Domain.Events;

namespace Toolbox.LightstoneAuto.Consumers.Read
{
    public class DatabaseViewEventConsumer
    {
        private readonly IPersist<DatabaseViewDto> _persist;
        private readonly IPublish _publisher;
        private readonly ISendCommand _send;
        private readonly IReadDatabaseExtractFacade _databaseExtract;

        public DatabaseViewEventConsumer(IPublish publisher, ISendCommand send, IPersist<DatabaseViewDto> persist,
            IReadDatabaseExtractFacade databaseExtract)
        {
            _publisher = publisher;
            _persist = persist;
            _send = send;
            _databaseExtract = databaseExtract;
        }

        public void Consume(IMessage<DatabaseViewLoaded> message)
        {
            var saved = _persist.Persist(message.Body.DatabaseView);

            if (!saved) return;
            var dto = AutoMapper.Mapper.Map<DatabaseExtractDto>(message.Body.DatabaseView);
            _send.Send(new CreateDataExtract(dto, message.Body.User, message.Body.CorrelationId));
        }

        public void Consume(IMessage<DatabaseViewModified> message)
        {
            var saved = _persist.Persist(message.Body.DatabaseView);

            if (!saved) return;
            var dto = AutoMapper.Mapper.Map<DatabaseExtractDto>(message.Body.DatabaseView);

            var existingExtracts = _databaseExtract.GetDataExtracts().Where(w => w.ViewId == dto.ViewId).ToList();

            if (!existingExtracts.Any())
            {
                _send.Send(new CreateDataExtract(dto, message.Body.User, message.Body.CorrelationId));
                return;
            }

            foreach (var extract in existingExtracts)
            {
                _send.Send(new ModifyDataExtract(dto, message.Body.User, extract.Version, message.Body.CorrelationId));
            }
        }
    }
}