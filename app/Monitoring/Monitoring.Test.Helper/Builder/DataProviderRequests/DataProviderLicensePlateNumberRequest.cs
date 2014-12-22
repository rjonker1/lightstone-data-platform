using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Builders;
using PackageBuilder.TestObjects.Mothers;

namespace Monitoring.Test.Helper.Builder.DataProviderRequests
{
    public class DataProviderLicensePlateNumberRequest: ILaceRequest
    {

        public IPackage Package
        {
            get
            {
                return LicensePlateNumberRequestPackage.LicenseNumberPackage();
            }
        }

        public IProvideUserInformationForRequest User
        {
            get
            {
                return new RequestUserInformation();
            }
        }

        public IProvideContextForRequest Context
        {
            get
            {
                return new ContextInformation();
            }
        }

        public IProvideRequestAggregation RequestAggregation
        {
            get
            {
                return new AggregationInformation();
            }
        }

        public IProvideVehicleInformationForRequest Vehicle
        {
            get
            {
                return new RequestVehicleInformation();
            }
        }

        public IProvideCoOrdinateInformationForRequest CoOrdinates
        {
            get { return new CoOrdinateInformation(); }
        }

        public IProvideJisInformation Jis
        {
            get { return new RequestJisInformation(); }
        }

        public DateTime RequestDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public string SearchTerm
        {
            get
            {
                return "XMC167GP";
            }
        }
      
    }

    public class LicensePlateNumberRequestPackage
    {
        public static IPackage LicenseNumberPackage()
        {
            // return WritePackageMother.LicensePlateSearchPackage;
            return LicensePlateSearchPackage;
        }

        public static Package LicensePlateSearchPackage
        {
            get
            {
                return new WritePackageBuilder()
                    .With("License plate search")
                    .With(10d, 20d)
                    .With(ActionMother.LicensePlateSearchAction)
                    .With(IndustryMother.Finance, IndustryMother.Automotive)
                    .With(StateMother.Published)
                    .With(0.1m)
                    .With(DateTime.Now)
                    .With(WriteDataProviderMother.Ivid, WriteDataProviderMother.IvidTitleHolder, WriteDataProviderMother.Rgt, WriteDataProviderMother.RgtVin, Audatex, Lightstone)
                    .Build();
            }
        }

        private static PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider Audatex
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Audatex)
                    .With("Audatex")
                    .With(10d)
                    .With(typeof(IProvideDataFromAudatex))
                    .Build();
            }
        }

        private static PackageBuilder.Domain.Entities.DataProviders.WriteModels.DataProvider Lightstone
        {
            get
            {
                return new WriteDataProviderBuilder()
                    .With(DataProviderName.Lightstone)
                    .With("Lightstone")
                    .With(10d)
                    .With(typeof(IProvideDataFromLightstone))
                    .Build();
            }
        }
    }

    public class RequestUserInformation : IProvideUserInformationForRequest
    {
        public Guid UserId
        {
            get
            {
                return new Guid("4A17B499-845F-43E2-AA2F-CFCB06920AB6");
            }
        }

        public Guid AggregateId
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public string UserName
        {
            get
            {
                return null;
            }
        }

        public string UserFirstName
        {
            get
            {
                return "Penny";
            }
        }

        public string UserLastName
        {
            get
            {
                return null;
            }
        }

        public string UserEmail
        {
            get
            {
                return "pennyl@lightstone.co.za";
            }
        }

        public string UserPhone
        {
            get
            {
                return null;
            }
        }
    }

    public class ContextInformation : IProvideContextForRequest
    {
        public string Product
        {
            get
            {
                return "VVi+ADX+VPi";
            }
        }

        public string ReasonForApplication
        {
            get
            {
                return null;
            }
        }

        public string SecurityCode
        {
            get
            {
                return "c99ef6d2-fdea-4a81-b15f-ff8251ac9050";
            }
        }
    }

    public class AggregationInformation : IProvideRequestAggregation
    {
        public Guid AggregateId
        {
            get
            {
                return Guid.NewGuid();
            }
        }
    }

    public class RequestVehicleInformation : IProvideVehicleInformationForRequest
    {
        public string EngineNo
        {
            get
            {
                return null;
            }
        }

        public string VinOrChassis
        {
            get
            {
                return null;
            }
        }

        public string Make
        {
            get
            {
                return null;
            }
        }

        public string RegisterNo
        {
            get
            {
                return null;
            }
        }

        public string LicenceNo
        {
            get
            {
                return "XMC167GP";
            }
        }

        public string Vin
        {
            get { return "SB1KV58E40F039277"; }
        }
    }

    public class CoOrdinateInformation : IProvideCoOrdinateInformationForRequest
    {
        public double Latitude
        {
            get
            {
                return -26.864250004641011;
            }
        }

        public double Longitude
        {
            get { return 32.829399989305713; }
        }

        public string Image
        {
            get { return string.Empty; }
        }
    }

    public class RequestJisInformation : IProvideJisInformation
    {
        public string CroppedImage
        {
            get { return string.Empty; }
        }

        public string FullImage
        {
            get { return string.Empty; }
        }

        public string FullImageThumb
        {
            get { return string.Empty; }
        }

        public double Latitude
        {
            get { return 0; }
        }

        public double Longitude
        {
            get { return 0; }
        }

        public DateTime SightingDate
        {
            get { return DateTime.MinValue; }
        }

        public string SiteLocation
        {
            get { return string.Empty; }
        }

        public string SiteName
        {
            get { return string.Empty; }
        }

        public int SessionId
        {
            get { return 0; }
        }

        public string UserName
        {
            get { return string.Empty; }
        }

        public string LicensePlateNumber
        {
            get { return string.Empty; }
        }
    }
}
