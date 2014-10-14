namespace LightstoneApp.Domain.PackageBuilderModule.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository OpenSession();
    }
}