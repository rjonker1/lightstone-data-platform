using System;
using System.Collections.Generic;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Requests.Read;

namespace PackageBuilder.Infrastructure.Repositories
{
    public interface IRequestAuditRepository : IRepository<RequestAudit>
    {
        bool RequestExists(Guid id);
        IEnumerable<Guid> GetUniqueRequestIds();
    }
}