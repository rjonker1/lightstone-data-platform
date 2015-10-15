using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.Requests.Commands;
using PackageBuilder.Domain.Entities.Requests.Read;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.CommandHandlers.Requests
{
    public class CreateRequestAuditHandler : AbstractMessageHandler<CreateRequestAudit>
    {
        private readonly IRequestAuditRepository _requestAuditRepository;

        public CreateRequestAuditHandler(IRequestAuditRepository requestAuditRepository)
        {
            _requestAuditRepository = requestAuditRepository;
        }

        public override void Handle(CreateRequestAudit command)
        {
            _requestAuditRepository.Save(new RequestAudit(command.Id, command.RequestId,command.State,command.RequestExpiration));
        }
    }
}