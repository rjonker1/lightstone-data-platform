using System.Linq;
using Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;
using Lace.Toolbox.PCubed.Domain;
using RestSharp;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_pcubed_ezscore_response : Specification
    {
        private readonly IRestResponse<ConsumerViewResponse> _response;
        private TransformPCubedEzScoreResponse _transformer;

        public when_transforming_pcubed_ezscore_response()
        {
            _response = new SourceResponseBuilder().ForPcubedEzScore();
        }

        public override void Observe()
        {
            _transformer = new TransformPCubedEzScoreResponse(_response, null);
            _transformer.Transform();
        }

        [Observation]
        public void pcubed_ezscore_transformer_continue_with_transformation_must_be_true()
        {
            _transformer.Continue.ShouldBeTrue();
        }

        [Observation]
        public void pcubed_ezscore_company_transformer_result_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.EzScoreRecords.ShouldNotBeNull();
            _transformer.Result.EzScoreRecords.Count().ShouldEqual(1);
            _transformer.Result.EzScoreRecords.First().FirstName.ShouldNotBeNull();
        }
    }
}
