﻿using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.Requests.Commands
{
    public class CreateRequestAudit : DomainCommand
    {
        public Guid RequestId { get; set; }
        public Vin12State State { get; set; }
        public DateTime RequestExpiration { get; set; }

        public CreateRequestAudit(Guid id, Guid requestId, Vin12State state, DateTime requestExpiration) : base(id)
        {
            RequestId = requestId;
            State = state;
            RequestExpiration = requestExpiration;
        }
    }
}