using LightstoneApp.Domain.PackageBuilderModule.Entities.PackageBuilder;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    public interface IHasPackageBuilderContext
    {
        PackageBuilderContext Context
        {
            get;
        }
    }
}