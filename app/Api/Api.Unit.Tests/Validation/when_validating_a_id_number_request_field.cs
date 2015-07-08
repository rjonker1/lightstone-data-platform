using Shared.BuildingBlocks.Api.Validation;
using Xunit.Extensions;

namespace Api.Unit.Tests.Validation
{
    public class when_validating_a_id_number_request_field : Specification
    {
        private ValidationResult _validation;
        public override void Observe()
        {
            
        }

        [Observation]
        public void then_id_number_less_than_13_characters_should_not_be_valid()
        {
            _validation = ValidationManager.Validate(15,"8310245010");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("ID number provided is not valid");
        
        }

        [Observation]
        public void then_id_number_characters_should_not_be_valid()
        {
            _validation = ValidationManager.Validate(15, "83102450100810");
            _validation.IsValid.ShouldBeFalse();
            _validation.Error.ShouldEqual("ID number provided is not valid");

        }

        [Observation]
        public void then_male_id_number_should_be_valid()
        {
            _validation = ValidationManager.Validate(15, "8310245010082");
            _validation.IsValid.ShouldBeTrue();
        }
    }
}