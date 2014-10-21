using System.Globalization;
using System.Linq;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Model;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Views;
using Raven.Client.Indexes;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Transformers
{
    public class PackagePackageViewTransformer : AbstractTransformerCreationTask<Package>
    {
        public PackagePackageViewTransformer()
        {
            TransformResults = results => from result in results
                select new PackageView
                {
                    Id = result.Id.ToString(),
                    //Name = result.,
                    Version = result.Version.ToString(CultureInfo.InvariantCulture),
                };
        }
    }
}