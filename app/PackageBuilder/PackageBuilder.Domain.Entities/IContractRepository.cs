using PackageBuilder.Core.Repositories;

namespace PackageBuilder.Domain.Entities
{
    public interface IContractRepository : IRepository<IContract>
    {
        IContract First();
    }
}