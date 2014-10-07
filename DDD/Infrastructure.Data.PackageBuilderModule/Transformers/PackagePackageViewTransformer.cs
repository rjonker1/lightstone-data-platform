using System.Linq;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using Raven.Client.Indexes;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Transformers
{
	public class PackagePackageViewTransformer : AbstractTransformerCreationTask<Package>
	{
		public PackagePackageViewTransformer()
		{
			TransformResults = results => from result in results
											   select new Views.PackageView()
											   {
												   Id = result.Id.ToString(),
												   Name = result.Name,
												   Version = result.Version,
                                                   
											   };
		}
	}
}
