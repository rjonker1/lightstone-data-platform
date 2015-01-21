using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests
{
    public class when_exporting_nhibernate_schema : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_export_schema()
        {

        }
    }
}