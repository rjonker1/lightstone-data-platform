using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Requests.Commands
{
    public class CreateRequestAudit : DomainCommand
    {
        public Guid RequestId { get; set; }
        public ApiCommitRequestUserState UserState { get; set; }
        public DateTime RequestExpiration { get; set; }

        public CreateRequestAudit(Guid id, Guid requestId, ApiCommitRequestUserState userstate, DateTime requestExpiration)
            : base(id)
        {
            RequestId = requestId;
            UserState = userstate;
            RequestExpiration = requestExpiration;
        }
    }
}