using System;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Domain.CommandHandlers.Industries
{
    public class RenameIndustryHandler : AbstractMessageHandler<RenameIndustry>
    {
        private readonly IRepository<Industry> _repository;

        public RenameIndustryHandler(IRepository<Industry> repository)
        {
            _repository = repository;
        }

        public override void Handle(RenameIndustry command)
        {
            var existing = _repository.FirstOrDefault(x => x.Id != command.Id && x.Name.ToLower() == command.Name.ToLower());
            if (existing != null)
                throw new LightstoneAutoException("An industry with the name {0} already exists".FormatWith(command.Name));

            var industry = _repository.Get(command.Id);
            if (industry == null)
                throw new ArgumentNullException("Could not load industry with id {0}".FormatWith(command.Id));

            industry.Name = command.Name;
        }
    }
}