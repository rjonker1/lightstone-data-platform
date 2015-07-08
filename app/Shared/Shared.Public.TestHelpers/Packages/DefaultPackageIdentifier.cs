using System;
using DataPlatform.Shared.Helpers;
using DataPlatform.Shared.Identifiers;

namespace Shared.Public.TestHelpers.Packages
{
    public class DefaultPackageIdentifier : IDefinePackageIdentifer
    {
        public Guid Id
        {
            get { return new Guid("996F715A-9C90-4D68-8948-92D89D6AD760"); }
        }

        public VersionIdentifier Version
        {
            get { return new VersionIdentifier(1, SystemTime.Now()); }
        }

        public double PackageCostPrice
        {
            get { return 0; }
        }

        public double PackageRecommendedPrice
        {
            get { return 0; }
        }
    }
}