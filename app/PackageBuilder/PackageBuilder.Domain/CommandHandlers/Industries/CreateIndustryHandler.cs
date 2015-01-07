using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Domain.CommandHandlers.Industries
{
    public class CreateIndustryHandler : AbstractMessageHandler<CreateIndustry>
    {
        private readonly INamedEntityRepository<Industry> _repository;

        public CreateIndustryHandler(INamedEntityRepository<Industry> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateIndustry command)
        {
            if (_repository.Exists(command.Id, command.Name))
            {
                this.Warn(() => "An industry with the name {0} already exists".FormatWith(command.Name));
                return;
            }

            _repository.Save(new Industry(command.Id, command.Name, command.IsSelected));
        }
    }
}