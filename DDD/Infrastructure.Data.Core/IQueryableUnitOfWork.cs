using System.Data.Objects;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Infrastructure.Data.Core
{
    /// <summary>
    ///     This is the minimun contract for all unit of work, one unit of work per module, that extend
    ///     base IUnitOfWork contract with specific features of ADO .NET EF and STE.
    ///     Creation of this and base contract add isolation feature from specific contract for
    ///     testing purposed and delete innecesary dependencies
    /// </summary>
    public interface IQueryableUnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///     Create a object set for a type TEntity
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in object set</typeparam>
        /// <returns>Object set of type {TEntity}</returns>
        IObjectSet<TEntity> CreateSet<TEntity>() where TEntity : class, IObjectWithChangeTracker;
    }
}