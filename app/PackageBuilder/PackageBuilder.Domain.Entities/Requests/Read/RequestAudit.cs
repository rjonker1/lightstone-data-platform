﻿using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.Requests.Read
{
    public class RequestAudit : Entity
    {
        public virtual Guid RequestId { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual CommitRequestState State { get; set; }
        public virtual DateTime RequestExpiration { get; set; }

        public RequestAudit()
        {
        }

        public RequestAudit(Guid id, Guid requestId, CommitRequestState state, DateTime requestExpiration)
            : base(id)
        {
            RequestId = requestId;
            State = state;
            RequestExpiration = requestExpiration;
        }
    }
}