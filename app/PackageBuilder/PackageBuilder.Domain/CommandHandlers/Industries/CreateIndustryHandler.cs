using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.Domain.MessageHandling;
using Raven.Client;

namespace PackageBuilder.Domain.CommandHandlers.Industries
{
    public class CreateIndustryHandler : AbstractMessageHandler<CreateIndustry>
    {
        private readonly IDocumentSession _session;

        public CreateIndustryHandler(IDocumentSession session)
        {
            _session = session;
        }

        public override void Handle(CreateIndustry command)
        {
            var industry = new Industry(command.Id, command.Name);
            _session.Store(industry);
        }
    }
}