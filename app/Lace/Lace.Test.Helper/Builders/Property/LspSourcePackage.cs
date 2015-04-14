using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Builders.Property
{
    public class PropertySourcePackage
    {
        public static IHavePackageForRequest PropertyPackage()
        {

            return new PropertyPackage();
        }
    }

    public class PropertyPackage : IHavePackageForRequest
    {
        public Guid Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public long Version
        {
            get { return 1; }
        }

        public IAmDataProvider[] DataProviders
        {
            get { return new IAmDataProvider[] {new DataProvider(DataProviderName.LightstoneProperty, 19, 38)}; }
        }

        public string Name
        {
            get { return "Property Package"; }
        }

        public string Action
        {
            get { return "Property Search"; }
        }
    }
}
