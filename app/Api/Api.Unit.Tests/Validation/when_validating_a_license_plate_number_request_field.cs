using DataPlatform.Shared.Dtos;
using Shared.BuildingBlocks.Api.Validation;
using Xunit.Extensions;

namespace Api.Unit.Tests.Validation
{
    public class when_validating_a_license_plate_number_request_field : Specification
    {
        private RequestFieldDto _requestField;
        private ValidationResult _validation;
        public override void Observe()
        {
            
        }

        [Observation]
        public void then_unkown_license_plate_should_be_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"UNKNown");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate. Please enter the correct license plate number");
        }

        [Observation]
        public void then_tba_license_plate_should_be_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"tBA");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate. Please enter the correct license plate number");
        }

        [Observation]
        public void then_ZK_license_plate_should_be_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167ZK");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Vehicle not eligible for quering");
        }

        [Observation]
        public void then_G_license_plate_should_be_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167g");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Vehicle not eligible for quering");
        }

        [Observation]
        public void then_B_license_plate_should_be_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167B");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Vehicle not eligible for quering");
        }

        [Observation]
        public void then_D_license_plate_should_be_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167d");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Vehicle not eligible for quering");
        }

        [Observation]
        public void then_GP_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167GP");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_L_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167L");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_FS_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167fs");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_MP_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167mp");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_NC_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167NC");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_NW_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167NW");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_EC_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167ec");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_Z_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167Z");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_N_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167N");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_WP_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"XMC167wp");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_starting_with_N_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"N100900");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_starting_with_C_license_plate_should_be_valid()
        {
            _validation = ValidationManager.Validate(1,"c100900");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
        }

        [Observation]
        public void then_non_alphanumeric_license_plate_should_be_not_valid()
        {
            _validation = ValidationManager.Validate(1,"100900");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate Number");
        }

        [Observation]
        public void then_license_plate__greater_than_9_characters_should_be_not_valid()
        {
            _validation = ValidationManager.Validate(1,"1234567890");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate Number");
        }

        [Observation]
        public void then_license_plate_less_than_3_characters_should_be_not_valid()
        {
            _validation = ValidationManager.Validate(1,"12");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate Number");
        }

        [Observation]
        public void then_license_plate_with_spaces_should_be_cleaned_be_valid()
        {
            _validation = ValidationManager.Validate(1,"X M C 167 Gp");
            _validation.IsValid.ShouldBeTrue();
            _validation.Error.ShouldBeEmpty();
            //_validation.GetCleanedLicensePlate.ShouldEqual("XMC167GP");
        }

        [Observation]
        public void then_license_plate_with_special_characters_should_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"X !M  %% C 167 &Gp");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate Number");
        }

        [Observation]
        public void then_license_plate_with_special_characters_and_legislation_number_should_be_cleaned_but_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"X !M  %% C 167 &ZK");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate Number");
        }

        [Observation]
        public void then_empty_license_plate_should_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"     ");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate Number");
            //_validation.GetCleanedLicensePlate.ShouldEqual("");
        }

        //cv44&gp
        [Observation]
        public void then_license_plate_with_ampersand_should_not_be_valid()
        {
            _validation = ValidationManager.Validate(1,"cv44&gp");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Invalid License Plate Number");
        }
    }
}
