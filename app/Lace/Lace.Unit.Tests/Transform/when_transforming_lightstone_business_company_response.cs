using System.Data;
using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Transform
{
    public class when_transforming_lightstone_business_company_response : Specification
    {

        private readonly DataSet _returnCompanies;
        private TransformLightstoneCompanyResponse _transformer;

        public when_transforming_lightstone_business_company_response()
        {
            _returnCompanies = new SourceResponseBuilder().ForLightstoneBusinessCompanyResponse();
        }

        public override void Observe()
        {
            _transformer = new TransformLightstoneCompanyResponse(_returnCompanies);
            _transformer.Transform();
        }

        [Observation]
        public void lightstone_business_company_transformer_continue_with_transformation_must_be_true()
        {
            _transformer.Continue.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_business_company_transformer_result_should_not_be_null()
        {
            _transformer.Result.ShouldNotBeNull();
            _transformer.Result.Companies.ShouldNotBeNull();
            _transformer.Result.Companies.Count().ShouldEqual(1);
        }
    }
}
