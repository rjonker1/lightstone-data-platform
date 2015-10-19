using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities.Requests.Read
{
    public class RequestAudit : Entity
    {
        public virtual Guid RequestId { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual Vin12State State { get; set; }
        public virtual DateTime RequestExpiration { get; set; }
    }
}