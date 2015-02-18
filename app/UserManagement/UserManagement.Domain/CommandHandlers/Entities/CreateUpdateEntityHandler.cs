using System.Collections.Generic;
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


            //var test = _repository.Select(x => x).Where(x => x.GetType() == typeof(Package));

            var brv = new BusinessRulesValidator();
            brv.CheckRules(command.Entity, _repository);

            _repository.SaveOrUpdate(command.Entity);
        }
    }
}