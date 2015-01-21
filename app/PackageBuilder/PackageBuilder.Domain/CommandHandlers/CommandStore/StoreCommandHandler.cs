using System.Text;
using Newtonsoft.Json;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.CommandStore;
using PackageBuilder.Domain.Entities.CommandStore.Commands;

namespace PackageBuilder.Domain.CommandHandlers.CommandStore
{
    public class StoreCommandHandler : AbstractMessageHandler<StoreCommand>
    {
        private readonly IRepository<Command> _repository;

        public StoreCommandHandler(IRepository<Command> repository)
        {
            _repository = repository;
        }

        public override void Handle(StoreCommand command)
        {
            var json = JsonConvert.SerializeObject(command.Command, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            _repository.Save(new Command(command.Id, command.Type, command.TypeName, Encoding.UTF8.GetBytes(json)));
        }
    }
}