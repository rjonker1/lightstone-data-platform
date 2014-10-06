using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Domain.MainModule.Products
{
    /// <summary>
    ///     Contract for Product aggregate root repository
    /// </summary>
    public interface IProductRepository
        : IRepository<Product>
    {
    }
}