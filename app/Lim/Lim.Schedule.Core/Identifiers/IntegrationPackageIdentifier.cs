using System.Collections.Generic;
using Lim.Domain.Models;

namespace Lim.Schedule.Core.Identifiers
{
    public class IntegrationPackageIdentifier
    {
        public IntegrationPackageIdentifier(IEnumerable<IntegrationPackage> packages)
        {
            Packages = packages;
        }
        public IEnumerable<IntegrationPackage> Packages { get; private set; }
    }
}
