using System;
using System.Linq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.States
{
    public class CreateStateHandler : AbstractMessageHandler<CreateState>
    {
        private readonly IRepository<State> _repository;

        public CreateStateHandler(IRepository<State> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateState command)
        {
            if (_repository.FirstOrDefault(x => x.Name.ToLower() == command.Name.ToLower()) != null)
                throw new Exception(string.Format("An state with {0} already exists", command.Name));

            var entity = new State(command.Id, command.Name);
            _repository.Save(entity);
        }
    }
}