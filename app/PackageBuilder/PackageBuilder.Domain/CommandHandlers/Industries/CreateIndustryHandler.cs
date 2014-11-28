using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

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
                return;
                //throw new LightstoneAutoException("An industry with the name {0} already exists".FormatWith(command.Name));

            var industry = new Industry(command.Id, command.Name, false);
            _repository.Save(industry);
        }
    }
}