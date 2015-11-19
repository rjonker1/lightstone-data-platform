using System;
using AutoMapper;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Repositories;

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
            //todo: remove and use new business rule validation implementation
            var brv = new BusinessRulesValidator(_handler);
            brv.CheckRules(command.Entity, command.Function);

            var namedEntityDto = ExceptionHelper.IgnoreException(() => Mapper.Map(command.Entity, new NamedEntityDto(), typeof(NamedEntity), typeof(NamedEntityDto)));
            var valueEntityDto = ExceptionHelper.IgnoreException(() => Mapper.Map(command.Entity, new ValueEntityDto(), typeof(ValueEntity), typeof(ValueEntityDto)));

            // Business rule validation
            _handler.Handle(command.Entity);
            _handler.Handle(namedEntityDto);
            _handler.Handle(valueEntityDto);
            // Business rule validation

            command.Entity.Modified = DateTime.UtcNow;
            
            _repository.SaveOrUpdate(command.Entity);
        }
    }


}