using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Domain.CommandHandlers.ValueEntities
{
    public class CreateValueEntityHandler : AbstractMessageHandler<ValueEntityDto>
    {
        private readonly IRetrieveEntitiesByType _entityRetriever;
        private readonly IValueEntityRepository<ValueEntity> _repository;

        public CreateValueEntityHandler(IRetrieveEntitiesByType entityRetriever, IValueEntityRepository<ValueEntity> repository)
        {
            _entityRetriever = entityRetriever;
            _repository = repository;
        }

        public override void Handle(ValueEntityDto command)
        {
            if (_entityRetriever.Exists(command.Type, command.Id, command.Value)) return;

            var entity = (ValueEntity)Mapper.Map(command, typeof(ValueEntityDto), command.Type);

            _repository.Save(entity);
        }
    }
}