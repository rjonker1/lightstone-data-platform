using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Business
{
    public class DirectorSourcePackage
    {
        public static IHavePackageForRequest DirectorPackage(long idnumber, string firstName, string surname)
        {
            return new DirectorPackage(idnumber,firstName,surname);
        }
    }

    public class DirectorPackage : IHavePackageForRequest
    {
        private readonly long _idNumber;
        private readonly string _firstName;
        private readonly string _surname;

        public DirectorPackage(long idnumber, string firstName, string surname)
        {
            _idNumber = idnumber;
            _firstName = firstName;
            _surname = surname;
        }

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
            get { return new IAmDataProvider[] { new DataProvider(DataProviderName.LSBusinessDirector_E_WS, 50, 27, LightstoneBusinessDirectorRequest.WithDefault(_firstName,_surname,_idNumber)) }; }
        }

        public string Name
        {
            get { return "Director Package"; }
        }

        public double PackageCostPrice
        {
            get { return 0.0; }
        }

        public double PackageRecommendedPrice
        {
            get { return 0.0; }
        }
    }
}
