using System.Linq;
using System.Text;
using DataPlatform.Shared.Helpers;
using DataPlatform.Shared.Helpers.Extensions;
using MemBus;
using Newtonsoft.Json;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.CommandStore;
using PackageBuilder.Domain.Entities.CommandStore.Commands;

namespace PackageBuilder.Domain.CommandHandlers.CommandStore
{
    public class ReplayCommandHandler : AbstractMessageHandler<ReplayCommand>
    {
        private readonly IRepository<Command> _repository;
        private readonly IBus _bus;

        public ReplayCommandHandler(IRepository<Command> repository, IBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public override void Handle(ReplayCommand replayCommand)
        {
            foreach (var command in _repository.OrderBy(x => x.CreatedDate).ToList())
            {
                var domainCommand = GetDomainCommandByType(command);
                if (domainCommand == null)
                    this.Error(() => "Could not replay command {0}, continuing to replay next command".FormatWith(command.Type));
                else
                    _bus.Publish(domainCommand);
            }
        }

        private object GetDomainCommandByType(Command command)
        {
            try
            {
                return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(command.CommandData), command.Type);
            }
            catch (JsonException exception)
            {
                this.Error(() => "Could not deserialize command by type: {0} attempting to deserialize by type name {1}".FormatWith(command.Type, command.TypeName), exception);
                return GetDomainCommandByTypeName(command);
            }
        }

        private object GetDomainCommandByTypeName(Command command)
        {
            try
            {
                return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(command.CommandData), TypeHelper.GetTypeByName(command.TypeName)[0]);
            }
            catch (JsonException exception)
            {
                this.Error(() => "Could not deserialize command by type: {0} or type name {1}".FormatWith(command.Type, command.TypeName), exception);
                return null;
            }
        }
    }
}