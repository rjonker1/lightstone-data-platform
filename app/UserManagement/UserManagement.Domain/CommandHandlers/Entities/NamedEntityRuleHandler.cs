using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;

namespace UserManagement.Domain.CommandHandlers.Entities
{
    public class NamedEntityRuleHandler : AbstractMessageHandler<NamedEntityDto>
    {
        private readonly INamedEntityRepository<NamedEntity> _repository;

        public NamedEntityRuleHandler(INamedEntityRepository<NamedEntity> repository)
        {
            _repository = repository;
        }

        public override void Handle(NamedEntityDto namedEntity)
        {
            if (_repository.Exists(namedEntity.Id, namedEntity.Name))
                throw new LightstoneAutoException("{0} already exists".FormatWith(namedEntity));
        }
    }
}