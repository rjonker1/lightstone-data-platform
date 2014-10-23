using System;
using System.Linq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.Industries
{
    public class CreateIndustryHandler : AbstractMessageHandler<CreateIndustry>
    {
        private readonly IRepository<Industry> _repository;

        public CreateIndustryHandler(IRepository<Industry> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateIndustry command)
        {
            if (_repository.FirstOrDefault(x => x.Name.ToLower() == command.Name.ToLower()) != null)
                throw new Exception(string.Format("An industry with {0} already exists", command.Name));

            var industry = new Industry(command.Id, command.Name);
            _repository.Save(industry);
        }
    }
}