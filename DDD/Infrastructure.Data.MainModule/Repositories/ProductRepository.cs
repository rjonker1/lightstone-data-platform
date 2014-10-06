using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Domain.MainModule.Products;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.Core;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;

namespace LightstoneApp.Infrastructure.Data.MainModule.Repositories
{
    /// <summary>
    ///     IProductRepository implementation
    ///     <see cref="LightstoneApp.Domain.MainModule.Products.IProductRepository" />
    /// </summary>
    public class ProductRepository
        : Repository<Product>, IProductRepository
    {
        #region Constructor

        /// <summary>
        ///     Default constructor for ProductRepository
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork dependency, intende to be resolved with IoC</param>
        /// <param name="traceManager">ITraceManager dependency, intended to be resolved with IoC</param>
        public ProductRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager)
            : base(unitOfWork, traceManager)
        {
        }

        #endregion
    }
}