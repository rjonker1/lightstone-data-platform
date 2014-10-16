using System;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.MessageHandling;
using Raven.Client;

namespace PackageBuilder.Domain.CommandHandlers.Industries
{
    public class RenameIndustryHandler : AbstractMessageHandler<RenameIndustry>
    {
        private readonly IDocumentSession _session;

        public RenameIndustryHandler(IDocumentSession session)
        {
            _session = session;
        }

        public override void Handle(RenameIndustry command)
        {
            var industry = _session.Load<Industry>(command.Id);

            if (industry == null)
                throw new ArgumentNullException(string.Format("Could not load industry with id {0}", command.Id));

            industry.Name = command.Name;
        }
    }
}