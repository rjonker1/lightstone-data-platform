using System;
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
            var industry = _repository.Get(command.Id);

            if (industry == null)
                throw new ArgumentNullException(string.Format("Could not load industry with id {0}", command.Id));

            industry.Name = command.Name;
        }
    }
}