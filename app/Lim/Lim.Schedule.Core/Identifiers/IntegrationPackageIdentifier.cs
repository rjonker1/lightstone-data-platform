using System.Collections.Generic;
using Lim.Domain.Dto;

namespace Lim.Schedule.Core.Identifiers
{
    public class IntegrationPackageIdentifier
    {
        public IntegrationPackageIdentifier(IEnumerable<IntegrationPackageDto> packages)
        {
            Packages = packages;
        }
        public IEnumerable<IntegrationPackageDto> Packages { get; private set; }
    }
}
