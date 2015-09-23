using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_lightstone_consumer_specifications_response : Specification
    {
        private readonly string _response;
        private TransformConsumerSpecificationsResponse _transformer;

        public when_transforming_lightstone_consumer_specifications_response()
        {
            _response = new SourceResponseBuilder().ForLightstoneConsumerSpecificationsResponse();
        }

        public override void Observe()
        {
            _transformer = new TransformConsumerSpecificationsResponse(_response, null);
            _transformer.Transform();
        }

        [Observation]
        public void lightstone_consumer_specifications_transformer_continue_with_transformation_must_be_true()
        {
            _transformer.Continue.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_consumer_specifications_transformer_result_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.RepairData.ShouldNotBeNull();
            _transformer.Result.RepairData.Count().ShouldEqual(1);
            _transformer.Result.RepairData.First().VehicleDescription.ShouldEqual("HYUNDAI TUCSON");
        }
    }
}
