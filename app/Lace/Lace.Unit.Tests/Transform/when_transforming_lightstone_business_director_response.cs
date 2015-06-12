using System;
using System.Data;
using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_lightstone_business_director_response : Specification
    {

        private readonly DataSet _returnDirectors;
        private TransformLightstoneDirectorResponse _transformer;

        public when_transforming_lightstone_business_director_response()
        {
            _returnDirectors = new SourceResponseBuilder().ForLightstoneDirectorResponse();
            
        }

        public override void Observe()
        {
            _transformer = new TransformLightstoneDirectorResponse(_returnDirectors);
            _transformer.Transform();
        }

        [Observation]
        public void lightstone_business_director_transformer_continue_must_be_true()
        {
            _transformer.Continue.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_business_director_transformer_result_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.Directors.ShouldNotBeNull();
            _transformer.Result.Directors.Count().ShouldEqual(1);
        }
    }
}
