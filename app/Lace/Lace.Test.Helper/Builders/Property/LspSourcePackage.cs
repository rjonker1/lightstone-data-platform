using System;
using Lace.Domain.Core.Requests.Contracts;
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

        public DataProviderName[] DataProviders
        {
            get { return new DataProviderName[] {DataProviderName.LightstoneProperty}; }
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
