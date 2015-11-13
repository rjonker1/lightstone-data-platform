using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Requests.Read;

namespace PackageBuilder.Infrastructure.Repositories
{
    public class RequestAuditRepository : Repository<RequestAudit>, IRequestAuditRepository
    {
        public RequestAuditRepository(ISession session) : base(session)
        {
        }

        public bool RequestExists(Guid id)
        {
            return this.Any(x => x.RequestId != id );
        }

        public IEnumerable<Guid> GetUniqueRequestIds()
        {
            return this.Select(x => x.RequestId).Distinct().ToList();
        }
    }
}