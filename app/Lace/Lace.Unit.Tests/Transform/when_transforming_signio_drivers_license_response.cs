using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_signio_drivers_license_response : Specification
    {
        private readonly string _decodedDriversLicenseResponse;
        private Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management.TransformSignioResponse _transformer;

        public when_transforming_signio_drivers_license_response()
        {
            _decodedDriversLicenseResponse =
                new SourceResponseBuilder().ForSignioDriversLicenseDecryptedResponse();
            _transformer = new Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management.TransformSignioResponse(_decodedDriversLicenseResponse);
        }

        public override void Observe()
        {
            _transformer.Transform();
        }

        [Observation]
        public void then_drivers_license_detail_must_have_correct_result_from_serialized_drivers_license()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.ShouldNotBeNull();
            _transformer.Result.DecodedData.ShouldNotBeNull();
            _transformer.Result.DecodedData.ShouldNotBeEmpty();
        }

        [Observation]
        public void then_drivers_license_certificate_number_should_be_correct()
        {
            _transformer.Result.DrivingLicense.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.DrivingLicense.CertificateNumber.ShouldEqual("409900036V1K");
        }

        [Observation]
        public void then_drivers_license_identity_document_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.IdentityDocument.ShouldNotBeNull();
        }


        [Observation]
        public void then_drivers_license_person_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.Person.ShouldNotBeNull();
        }

        [Observation]
        public void then_drivers_license_card_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.Card.ShouldNotBeNull();
        }

        [Observation]
        public void then_drivers_license_professional_driving_permit_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.ProfessionalDrivingPermit.ShouldNotBeNull();
        }

        [Observation]
        public void then_drivers_license_vehicle_class1_permit_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.VehicleClass1.ShouldNotBeNull();
        }

        [Observation]
        public void then_drivers_license_photo_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.Photo.ShouldNotBeNull();
            _transformer.Result.DrivingLicense.Photo.ShouldNotBeEmpty();

        }
    }
}
