using LightstoneApp.Domain.PackageBuilderModule.Entities.Context.PackageBuilder;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.DTO
{
    public interface IHasPackageBuilderContext
    {
        PackageBuilderContext Context { get; }
    }
}