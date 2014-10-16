using System.CodeDom.Compiler;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Context.PackageBuilder;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.DTO
{
    [GeneratedCode("OIALtoPLiX", "1.0")]
    public interface IHasPackageBuilderContext
    {
        PackageBuilderContext Context { get; }
    }
}