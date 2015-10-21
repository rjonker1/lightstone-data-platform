using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Requests.Commands
{
    public class CreateRequestAudit : DomainCommand
    {
        public Guid RequestId { get; set; }
        public ApiCommitRequestState State { get; set; }
        public DateTime RequestExpiration { get; set; }

        public CreateRequestAudit(Guid id, Guid requestId, ApiCommitRequestState state, DateTime requestExpiration)
            : base(id)
        {
            RequestId = requestId;
            State = state;
            RequestExpiration = requestExpiration;
        }
    }
}