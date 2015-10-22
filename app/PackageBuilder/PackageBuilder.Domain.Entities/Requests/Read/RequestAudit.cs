using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.Requests.Read
{
    public class RequestAudit : Entity
    {
        public virtual Guid RequestId { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual ApiCommitRequestUserState UserState { get; set; }
        public virtual DateTime RequestExpiration { get; set; }

        public RequestAudit()
        {
        }

        public RequestAudit(Guid id, Guid requestId, ApiCommitRequestUserState userstate, DateTime requestExpiration)
            : base(id)
        {
            RequestId = requestId;
            UserState = userstate;
            RequestExpiration = requestExpiration;
        }
    }
}