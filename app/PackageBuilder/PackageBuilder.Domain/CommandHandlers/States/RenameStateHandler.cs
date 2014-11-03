using System;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.States
{
    public class RenameStateHandler : AbstractMessageHandler<RenameState>
    {
        private readonly IRepository<State> _repository;

        public RenameStateHandler(IRepository<State> repository)
        {
            _repository = repository;
        }

        public override void Handle(RenameState command)
        {
            var existing = _repository.FirstOrDefault(x => x.Id != command.Id && x.Name == command.Name);
            if (existing != null)
                throw new LightstoneAutoException("A state with the name {0} already exists".FormatWith(command.Name));

            var state = _repository.Get(command.Id);
            if (state == null)
                throw new ArgumentNullException(string.Format("Could not load state with id {0}", command.Id));

            state.Alias = command.Alias;
        }
    }
}