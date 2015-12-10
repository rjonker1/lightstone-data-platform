using EasyNetQ;
using Lim.Domain.Base;
using Toolbox.LightstoneAuto.Domain;
using Toolbox.LightstoneAuto.Domain.Commands.View;

namespace Toolbox.LightstoneAuto.Consumers.Write
{
    public class ViewImportCommandConsumer
    {
        private readonly IAggregateRepository<ViewImport> _repository;

        public ViewImportCommandConsumer(IAggregateRepository<ViewImport> repository)
        {
            _repository = repository;
        }

        public void Consume(IMessage<CreateViewImport> message)
        {
            var view = new ViewImport(message.Body);
            _repository.Save(view, -1);
        }

        public void Consume(IMessage<ModifyViewImport> message)
        {
            var view = new ViewImport();
            view.Modify(message.Body);
            _repository.Save(view, message.Body.Version);
        }

        public void Consume(IMessage<DeActivateViewImport> message)
        {
            var view = new ViewImport();
            view.Deactivate(message.Body);
            _repository.Save(view, message.Body.Version);
        }

        public void Consume(IMessage<ReloadViewImport> message)
        {
            var view = new ViewImport();
            view.Reload(message.Body);
            _repository.Save(view, message.Body.Version);
        }
    }
}
