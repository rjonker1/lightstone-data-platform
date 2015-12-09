using System;
using System.Threading.Tasks;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class WritePackageMother
    {
        public static Package LicensePlateSearchPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("License plate search")
                    .With(10m, 20m)
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.UtcNow)
                    .With(WriteDataProviderMother.Ivid, WriteDataProviderMother.IvidTitleHolder, WriteDataProviderMother.Rgt, WriteDataProviderMother.RgtVin, WriteDataProviderMother.Audatex, WriteDataProviderMother.Lightstone)
                    .Build();
            }
        }

        public static Package FullVerificationPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("Full verification")
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.UtcNow)
                    .With(WriteDataProviderMother.Ivid, WriteDataProviderMother.IvidTitleHolder, WriteDataProviderMother.Rgt, WriteDataProviderMother.RgtVin, WriteDataProviderMother.Audatex, WriteDataProviderMother.Lightstone)
                    .Build();
            }
        }

        public static Package PartialVerificationPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("Partial verification")
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.UtcNow)
                    .With(WriteDataProviderMother.Ivid, WriteDataProviderMother.IvidTitleHolder, WriteDataProviderMother.Rgt, WriteDataProviderMother.RgtVin, WriteDataProviderMother.Audatex, WriteDataProviderMother.Lightstone)
                    .Build();
            }
        }

        public static Package LicenseScanPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("Driver’s license scan package")
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.UtcNow)
                    .With(WriteDataProviderMother.SignioDriversLicenseDataProvider)
                    .Build();
            }
        }

        public static Package EzScorePackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("EzScore")
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.UtcNow)
                    .With(WriteDataProviderMother.Ivid, WriteDataProviderMother.IvidTitleHolder, WriteDataProviderMother.Rgt, WriteDataProviderMother.RgtVin, WriteDataProviderMother.Audatex, WriteDataProviderMother.Lightstone)
                    .Build();
            }
        }

        public static Package FicaVerificationPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("Fica verfication package")
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.UtcNow)
                    .With(WriteDataProviderMother.PCubedFicaDataProvider)
                    .Build();
            }
        }

        public static Package PropertyPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("Property verification package")
                    .With(IndustryMother.Finance, IndustryMother.Property)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.UtcNow)
                    .With(WriteDataProviderMother.LightstoneProperty)
                    .Build();
            }
        }
    }
}