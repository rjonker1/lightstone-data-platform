using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MemBus;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Domain.CommandHandlers.Entities
{
    public class CreateUpdateEntityHandler : AbstractMessageHandler<CreateUpdateEntity>
    {
        private readonly IRepository<Entity> _repository;

        private readonly IHandleMessages _handler;

        public CreateUpdateEntityHandler(IRepository<Entity> repository, IHandleMessages handler)
        {
            _repository = repository;
            _handler = handler;
        }


        public override void Handle(CreateUpdateEntity command)
        {

            var brv = new BusinessRulesValidator(_handler);
            brv.CheckRules(command.Entity, command.Create);

            _repository.SaveOrUpdate(command.Entity);
        }
    }
}