using System;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Domain.CommandHandlers.Industries
{
    public class RenameIndustryHandler : AbstractMessageHandler<RenameIndustry>
    {
        private readonly INamedEntityRepository<Industry> _repository;

        public RenameIndustryHandler(INamedEntityRepository<Industry> repository)
        {
            _repository = repository;
        }

        public override void Handle(RenameIndustry command)
        {
            if (_repository.Exists(command.Id, command.Name))
                throw new LightstoneAutoException("An industry with the name {0} already exists".FormatWith(command.Name));

            var industry = _repository.Get(command.Id);
            if (industry == null)
                throw new ArgumentNullException("Could not load industry with id {0}".FormatWith(command.Id));

            industry.Name = command.Name;
        }
    }
}