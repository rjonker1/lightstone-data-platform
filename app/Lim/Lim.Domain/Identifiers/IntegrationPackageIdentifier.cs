using System;
using System.Collections.Generic;

namespace Lim.Domain.Identifiers
{
    public class IntegrationPackageIdentifier
    {
        public IntegrationPackageIdentifier(IEnumerable<Guid> packageIds)
        {
            PackageIds = packageIds;
        }
        public IEnumerable<Guid> PackageIds { get; private set; }
    }
}
