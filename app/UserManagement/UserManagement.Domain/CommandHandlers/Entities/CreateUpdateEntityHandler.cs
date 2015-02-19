﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public CreateUpdateEntityHandler(IRepository<Entity> repository)
        {
            _repository = repository;
        }



        public override void Handle(CreateUpdateEntity command)
        {

            var commandEntityName = command.Entity.GetType().Name;
            var brEntities = new Collection<Entity>();

            foreach (var entity in _repository)
            {

                if (entity.GetType().Name == commandEntityName)
                {
                    brEntities.Add(entity);
                }
            }

            //var brv = new BusinessRulesValidator();
            //brv.CheckRules(command.Entity, brEntities);

            _repository.SaveOrUpdate(command.Entity);
        }
    }
}