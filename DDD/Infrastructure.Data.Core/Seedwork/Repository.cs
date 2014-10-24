using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LightstoneApp.Domain.Core.Seedwork;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Infrastructure.Data.Core.Resources;

namespace LightstoneApp.Infrastructure.Data.Core.Seedwork
{
    /// <summary>
    /// Repository base class
    /// </summary>
    /// <typeparam name="TEntity">The type of underlying entity in this repository</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository

        /// <summary>
        /// Get the unit of work in this repository
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="item">Item</param>
        public virtual void Add(TEntity item)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Add Begin"));

            if (item != null)
            {
                try
                {
                    _unitOfWork.GetDbSet<TEntity>().Add(item);
                }
                catch (Exception ex)
                {
                    LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Add Data Layer ERROR"), ex);
                }
            }
            else
                LoggerFactory.CreateLog().Info(Messages.info_CannotAddNullEntity, typeof(TEntity).ToString());

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Add End"));
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
        public virtual void Modify(TEntity item)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Modify Begin"));

            if (item != null)
            {
                try
                {
                    _unitOfWork.SetEntryState(item, EntityState.Modified);
                }
                catch (Exception ex)
                {
                    LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Modify Data Layer ERROR"), ex);
                }
            }
            else
                LoggerFactory.CreateLog().Info(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Modify End"));
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
        public virtual void Remove(TEntity item)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Remove Begin"));

            if (item != null)
            {
                try
                {
                    _unitOfWork.SetEntryState(item, EntityState.Unchanged);
                    _unitOfWork.GetDbSet<TEntity>().Remove(item);
                }
                catch (Exception ex)
                {
                    LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Remove Data Layer ERROR"), ex);
                }
            }
            else
                LoggerFactory.CreateLog().Info(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Remove End"));
        }

        /// <summary>
        /// Merge
        /// </summary>
        /// <param name="persisted">Persisted item</param>
        /// <param name="current">Current item</param>
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Merge Begin"));

            try
            {
                _unitOfWork.ApplyCurrentValues(persisted, current);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Merge Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Merge End"));
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
        /// <returns>Entity</returns>
        public virtual TEntity Get(List<object> keyValues)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Get Begin"));

            TEntity item = null;

            try
            {
                item = _unitOfWork.GetDbSet<TEntity>().Find(keyValues.ToArray());
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Get Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - Get End"));

            return item;
        }

        /// <summary>
        /// Select async
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
        /// <returns>TEntity (task)</returns>
        public virtual async Task<TEntity> GetAsync(List<object> keyValues)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - GetAsync Begin"));

            TEntity item = null;

            try
            {
                item = await _unitOfWork.GetDbSet<TEntity>().FindAsync(keyValues.ToArray());
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAsync Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - GetAsync End"));

            return item;
        }

        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
        /// <returns>List of results</returns>
        public virtual List<TEntity> GetAll(List<string> includes = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - GetAll Begin"));

            List<TEntity> items = null;

            try
            {
                items = _unitOfWork.GetQueryable<TEntity>(includes).ToList();
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAll Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - GetAll End"));

            return items;
        }

        /// <summary>
        /// Select all async
        /// </summary>
        /// <param name="includes">Inners</param>
        /// <returns>List of results (task)</returns>
        public virtual async Task<List<TEntity>> GetAllAsync(List<string> includes = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - GetAllAsync Begin"));

            List<TEntity> items = null;

            try
            {
                items = await _unitOfWork.GetQueryable<TEntity>(includes).ToListAsync();
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllAsync Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - GetAllAsync End"));

            return items;
        }

        /// <summary>
        /// Find items
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <returns>List of results</returns>
        public virtual List<TEntity> AllMatching(Expression<Func<TEntity, bool>> filter, List<string> includes = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatching Begin"));

            List<TEntity> items = null;

            try
            {
                items = _unitOfWork.GetQueryable(includes, filter).ToList();
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AllMatching Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatching End"));

            return items;
        }

        /// <summary>
        /// Find items async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <returns>List of results (task)</returns>
        public virtual async Task<List<TEntity>> AllMatchingAsync(Expression<Func<TEntity, bool>> filter, List<string> includes = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingAsync Begin"));

            List<TEntity> items = null;

            try
            {
                items = await _unitOfWork.GetQueryable(includes, filter).ToListAsync();
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AllMatchingAsync Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingAsync End"));

            return items;
        }

        /// <summary>
        /// Find paged items
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="pageGo">Go to page</param>
        /// <param name="pageSize">Items request</param>
        /// <param name="orderBy">Fields order</param>
        /// <param name="orderAscendent">Order ascendent</param>
        /// <returns>Paged results</returns>
        public virtual PagedCollection<TEntity> AllMatchingPaged(Expression<Func<TEntity, bool>> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool orderAscendent)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingPaged Begin"));

            List<TEntity> items = null;
            var totalItems = 0;

            try
            {
                items = _unitOfWork.GetQueryable(includes, filter, pageGo, pageSize, orderBy, orderAscendent).ToList();
                totalItems = _unitOfWork.GetQueryable(includes, filter).Count();
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AllMatchingPaged Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingPaged End"));

            return new PagedCollection<TEntity> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
        }

        /// <summary>
        /// Find paged items async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="pageGo">Go to page</param>
        /// <param name="pageSize">Items request</param>
        /// <param name="orderBy">Fields order</param>
        /// <param name="orderAscendent">Order ascendent</param>
        /// <returns>Paged results (task)</returns>
        public virtual async Task<PagedCollection<TEntity>> AllMatchingPagedAsync(Expression<Func<TEntity, bool>> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool orderAscendent)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingPagedAsync Begin"));

            List<TEntity> items = null;
            var totalItems = 0;

            try
            {
                var itemsTask = _unitOfWork.GetQueryable(includes, filter, pageGo, pageSize, orderBy, orderAscendent).ToListAsync();
                totalItems = _unitOfWork.GetQueryable(includes, filter).Count();
                items = await itemsTask;
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AllMatchingPagedAsync Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingPagedAsync End"));

            return new PagedCollection<TEntity> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
        }

        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <returns>Total count</returns>
        public virtual int AllMatchingCount(Expression<Func<TEntity, bool>> filter = null, List<string> includes = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingCount Begin"));

            var totalItems = 0;

            try
            {
                totalItems = _unitOfWork.GetQueryable(includes, filter).Count();
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AllMatchingCount Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingCount End"));

            return totalItems;
        }

        /// <summary>
        /// Total count by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <returns>Total count (task)</returns>
        public virtual async Task<int> AllMatchingCountAsync(Expression<Func<TEntity, bool>> filter = null, List<string> includes = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingCountAsync Begin"));

            var totalItems = 0;

            try
            {
                totalItems = await _unitOfWork.GetQueryable(includes, filter).CountAsync();
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AllMatchingCountAsync Data Layer ERROR"), ex);
            }

            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Data Layer - AllMatchingCountAsync End"));

            return totalItems;
        }

        /// <summary>
        /// Cleanup resources
        /// </summary>
        public void Dispose()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();
        }

        #endregion
    }
}