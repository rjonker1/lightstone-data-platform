namespace LightstoneApp.Infrastructure.Data.Core.Services
{
    public interface IRepositoryFactory
    {
        IRepository OpenSession();
    }
}