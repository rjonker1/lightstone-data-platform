using System;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Domain.BusinessRules.NamedEntities
{
    public class NamedEntityRuleHandler : AbstractMessageHandler<NamedEntityDto>
    {
        //Entity retriever
        private readonly IEntityByTypeRepository _entityRetriever;

        //private readonly INamedEntityRepository<NamedEntity> _repository;

        public NamedEntityRuleHandler(IEntityByTypeRepository entityRetriever)
        {
            _entityRetriever = entityRetriever;
        }

        public override void Handle(NamedEntityDto namedEntity)
        {
            //if (_repository.Exists(namedEntity.Id, namedEntity.Name))

            if (_entityRetriever.GetNamedEntities(Type.GetType(namedEntity.AssemblyQualifiedName))
                    .FirstOrDefault(x => x.Id != namedEntity.Id && (x.Name + "").Trim().ToLower() == (namedEntity.Name + "").Trim().ToLower()) != null)
                throw new LightstoneAutoException("{0} already exists".FormatWith(namedEntity.Name));
        }
    }
}