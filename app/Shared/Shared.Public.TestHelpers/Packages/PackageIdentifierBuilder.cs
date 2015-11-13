using System;
using DataPlatform.Shared.Identifiers;

namespace Shared.Public.TestHelpers.Packages
{
    public class PackageIdentifierBuilder
    {
        private Guid id;
        private VersionIdentifier version;
        private double packageCostPrice;
        private double packageRecommendedPrice;

        public PackageIdentifier Build()
        {
            return new PackageIdentifier(id, version, packageCostPrice, packageRecommendedPrice);
        }

        public PackageIdentifierBuilder With(IDefinePackageIdentifer data)
        {
            return WithId(data.Id)
                .WithVersion(data.Version)
                .WithPackagePricing(data.PackageCostPrice, data.PackageRecommendedPrice);
        }

        public PackageIdentifierBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        public PackageIdentifierBuilder WithVersion(VersionIdentifier version)
        {
            this.version = version;
            return this;
        }

        public PackageIdentifierBuilder WithPackagePricing(double packageCostPrice, double packageRecommendedPrice)
        {
            this.packageCostPrice = packageCostPrice;
            this.packageRecommendedPrice = packageRecommendedPrice;
            return this;
        }
    }
}