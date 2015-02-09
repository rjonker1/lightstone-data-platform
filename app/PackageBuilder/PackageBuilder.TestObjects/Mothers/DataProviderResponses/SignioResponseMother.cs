using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses
{
    public class SignioResponseMother
    {
        public static IProvideDataFromSignioDriversLicenseDecryption Response
        {
            get
            {
                return new SignioResponseBuilder()
                    .With(new IdentityDocument(string.Empty, string.Empty))
                    .With(new Person(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                        string.Empty))
                    .With(new DrivingLicense(string.Empty, string.Empty))
                    .With(new Card(string.Empty, string.Empty, string.Empty))
                    .With(new VehicleClass(string.Empty, string.Empty, string.Empty),
                        new VehicleClass(string.Empty, string.Empty, string.Empty),
                        new VehicleClass(string.Empty, string.Empty, string.Empty),
                        new VehicleClass(string.Empty, string.Empty, string.Empty))
                    .With(string.Empty, string.Empty, string.Empty)
                    .With(string.Empty)
                    .Build();
            }
        }
    }

    public class SignioResponseBuilder
    {
        private IRespondWithIdentityDocument _identityDocument;
        private IRespondWithPerson _person;
        private IRespondWithDrivingLicense _drivingLicense;
        private IRespondWithCard _card;
        private IRespondWithProfessionalDrivingPermit _drivingPermit;
        private IRespondWithVehicleClass _vehicleClass1;
        private IRespondWithVehicleClass _vehicleClass2;
        private IRespondWithVehicleClass _vehicleClass3;
        private IRespondWithVehicleClass _vehicleClass4;

        private string _cellphone;
        private string _emailAddress;
        private string _photo;
        private string _decodedData;


        public SignioResponseBuilder With(IRespondWithIdentityDocument identityDocument)
        {
            _identityDocument = identityDocument;
            return this;
        }

        public SignioResponseBuilder With(IRespondWithPerson person)
        {
            _person = person;
            return this;
        }

        public SignioResponseBuilder With(IRespondWithDrivingLicense drivingLicense)
        {
            _drivingLicense = drivingLicense;
            return this;
        }

        public SignioResponseBuilder With(IRespondWithCard card)
        {
            _card = card;
            return this;
        }

        public SignioResponseBuilder With(IRespondWithProfessionalDrivingPermit drivingPermit)
        {
            _drivingPermit = drivingPermit;
            return this;
        }


        public SignioResponseBuilder With(IRespondWithVehicleClass vehicleClass1, IRespondWithVehicleClass vehicleClass2,
            IRespondWithVehicleClass vehicleClass3, IRespondWithVehicleClass vehicleClass4)
        {
            _vehicleClass1 = vehicleClass1;
            _vehicleClass2 = vehicleClass2;
            _vehicleClass3 = vehicleClass3;
            _vehicleClass4 = vehicleClass4;
            return this;
        }

        public SignioResponseBuilder With(string cellphone, string photo, string emailAddress)
        {
            _cellphone = cellphone;
            _photo = photo;
            _emailAddress = emailAddress;
            return this;
        }

        public SignioResponseBuilder With(string decodedData)
        {
            _decodedData = decodedData;
            return this;
        }


        public IProvideDataFromSignioDriversLicenseDecryption Build()
        {
            return
                new SignioDriversLicenseDecryptionResponse(
                    new DrivingLicenseCard(_identityDocument, _person, _drivingLicense, _card, _drivingPermit,
                        _vehicleClass1, _vehicleClass2, _vehicleClass3, _vehicleClass4, _photo, _cellphone,
                        _emailAddress), _decodedData);
        }
    }
}
