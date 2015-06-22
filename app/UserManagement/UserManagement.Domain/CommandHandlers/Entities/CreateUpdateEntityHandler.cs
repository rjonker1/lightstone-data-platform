using System;
using AutoMapper;
using DataPlatform.Shared.ExceptionHandling;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
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
            //var brv = new BusinessRulesValidator(_handler);
            //brv.CheckRules(command.Entity, command.Function);

            // Func helper
            var namedEntityDto = ExceptionHelper.IgnoreException(() => Mapper.Map(command.Entity, new NamedEntityDto(), typeof(NamedEntity), typeof(NamedEntityDto)));
            var valueEntityDto = ExceptionHelper.IgnoreException(() => Mapper.Map(command.Entity, new ValueEntityDto(), typeof(ValueEntity), typeof(ValueEntityDto)));

            try
            {
                _handler.Handle(namedEntityDto);

                _handler.Handle(valueEntityDto);
            }
            catch (LightstoneAutoException lightstoneAutoException)
            {
                Console.WriteLine(lightstoneAutoException);
                return;
            }

            command.Entity.Modified = DateTime.UtcNow;
            
            _repository.SaveOrUpdate(command.Entity);
        }
    }
}