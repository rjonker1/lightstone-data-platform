using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;

namespace UserManagement.Domain.BusinessRules.ValueEntities
{
    public class ValueEntityRuleHandler : AbstractMessageHandler<ValueEntityDto>
    {
        private readonly IValueEntityRepository<ValueEntity> _repository;

        public ValueEntityRuleHandler(IValueEntityRepository<ValueEntity> repository)
        {
            _repository = repository;
        }

        public override void Handle(ValueEntityDto valueEntity)
        {
            if (_repository.Exists(valueEntity.Id, valueEntity.Value))
                throw new LightstoneAutoException("{0} already exists".FormatWith(valueEntity.Value));
        }
    }
}