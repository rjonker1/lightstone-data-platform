using Shared.BuildingBlocks.Api.Validation;
using Xunit.Extensions;

namespace Api.Unit.Tests.Validation
{
    public class when_validating_a_vinnumber_request_field :Specification
    {
        private ValidationResult _validation;
        public override void Observe()
        {

        }

        [Observation]
        public void then_number_only_vin_number_should_not_be_valid()
        {
            _validation = ValidationManager.Validate(0, "123456789");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Vin number is not alphanumeric");
        }

        [Observation]
        public void then_vin_number_greater_than_17_characters_should_not_be_valid()
        {
            _validation = ValidationManager.Validate(0, "SB1KV58E40F0392779");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Vin number cannot be greater than 17 characters");
        }

        [Observation]
        public void then_vin_number_less_than_6_characters_should_not_be_valid()
        {
            _validation = ValidationManager.Validate(0, "SB1KV");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("Vin number cannot be smaller than 6 characters");
        }

        [Observation]
        public void then_vin_number_less_than_17_characters_but_greater_than_6_should_be_valid()
        {
            _validation = ValidationManager.Validate(0, "SB1KV58E40F0");
            _validation.IsValid.ShouldBeTrue();
        }

        [Observation]
        public void then_vin_number_should_be_valid()
        {
            _validation = ValidationManager.Validate(0, "SB1KV58E40F039277");
            _validation.IsValid.ShouldBeTrue();
        }

        
    }
}
