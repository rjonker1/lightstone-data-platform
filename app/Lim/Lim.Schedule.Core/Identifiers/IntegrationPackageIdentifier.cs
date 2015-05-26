using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace Lim.Schedule.Core.Identifiers
{
    public class IntegrationPackageIdentifier
    {
        public IntegrationPackageIdentifier(IEnumerable<PackageContract> packageIds)
        {
            PackageIds = packageIds;
        }
        public IEnumerable<PackageContract> PackageIds { get; private set; }
    }

    public class PackageContract
    {
        public PackageContract(Guid packageId, Guid contractId)
        {
            PackageId = packageId;
            ContractId = contractId;
        }

        public Guid PackageId { get; private set; }
        public Guid ContractId { get; private set; }
    }
}
