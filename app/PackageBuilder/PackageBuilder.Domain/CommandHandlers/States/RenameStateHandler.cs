﻿using System;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.CommandHandlers.States
{
    public class RenameStateHandler : AbstractMessageHandler<RenameState>
    {
        private readonly IStateRepository _repository;

        public RenameStateHandler(IStateRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(RenameState command)
        {
            if (_repository.Exists(command.Id, command.Name))
                throw new LightstoneAutoException("A state with the name {0} already exists".FormatWith(command.Name));

            var state = _repository.Get(command.Id);
            if (state == null)
                throw new ArgumentNullException(string.Format("Could not load state with id {0}", command.Id));

            state.Alias = command.Alias;
        }
    }
}