using EasyNetQ;
using Lim.Domain.Base;
using Toolbox.LightstoneAuto.Domain;
using Toolbox.LightstoneAuto.Domain.Commands.View;

namespace Toolbox.LightstoneAuto.Consumers.Write
{
    public class DatabaseViewCommandConsumer
    {
        private readonly IAggregateRepository<DatabaseView> _repository;

        public DatabaseViewCommandConsumer(IAggregateRepository<DatabaseView> repository)
        {
            _repository = repository;
        }

        public void Consume(IMessage<LoadView> message)
        {
            var view = new DatabaseView(message.Body);
            _repository.Save(view, -1);
        }

        public void Consume(IMessage<ModifyView> message)
        {
            var view = new DatabaseView();
            view.Modify(message.Body);
            _repository.Save(view, message.Body.Version);
        }
    }
}
