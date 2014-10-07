using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.Core.Entities;
using LightstoneApp.Domain.Core.Specification;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.Core.Resources;

namespace LightstoneApp.Infrastructure.Data.Core
{
    /// <summary>
    ///     Default base class for extended repositories. This generic repository
    ///     is a default implementation of <see cref=" LightstoneApp.Domain.Core.IExtendedRepository{TEntity}" />
    ///     and your specific repositories can inherit from this base class so automatically will get default implementation.
    ///     IMPORTANT: Using this Base Repository class IS NOT mandatory. It is just a useful base class:
    ///     You could also decide that you do not want to use this base Repository class, because sometimes you don't want a
    ///     specific Repository getting all these features and it might be wrong for a specific Repository.
    ///     For instance, you could want just read-only data methods for your Repository, etc.
    ///     in that case, just simply do not use this base class on your Repository.
    /// </summary>
    /// <typeparam name="TEntity">Type of elements in repository</typeparam>
    public class ExtendedRepository<TEntity>
        : Repository<TEntity>, IExtendedRepository<TEntity>
        where TEntity : class, IObjectWithChangeTracker
    {
        #region Members

        private readonly IQueryableUnitOfWork _CurrentUoW;
        private readonly ITraceManager _TraceManager;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for GenericRepository
        /// </summary>
        /// <param name="unitOfWork">A unit of work  for this repository</param>
        /// <param name="traceManager">TraceManager dependency</param>
        public ExtendedRepository(IQueryableUnitOfWork unitOfWork, ITraceManager traceManager)
            : base(unitOfWork, traceManager)
        {
            //check preconditions
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork", Messages.exception_ContainerCannotBeNull);

            if (traceManager == null)
                throw new ArgumentNullException("traceManager", Messages.exception_TraceManagerCannotBeNull);

            //set internal values
            _CurrentUoW = unitOfWork;
            _TraceManager = traceManager;


            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_ConstructRepository,
                    typeof (TEntity).Name));
        }

        #endregion

        #region IRepository<TEntity> 

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="items">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        public virtual void Modify(ICollection<TEntity> items)
        {
            //check arguments
            if (items == null)
                throw new ArgumentNullException("items", Messages.exception_ItemArgumentIsNull);

            //for each element in collection apply changes
            foreach (TEntity item in items)
            {
                if (item != null)
                    _CurrentUoW.RegisterChanges(item);
            }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <typeparam name="KEntity">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </typeparam>
        /// <param name="specification">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </returns>
        public virtual IEnumerable<KEntity> GetBySpec<KEntity>(ISpecification<KEntity> specification)
            where KEntity : class, TEntity
        {
            if (specification == null)
                throw new ArgumentNullException("specification");

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetBySpec,
                    typeof (TEntity).Name));

            return (_CurrentUoW.CreateSet<TEntity>()
                .OfType<KEntity>()
                .Where(specification.SatisfiedBy())
                .AsEnumerable());
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <typeparam name="K">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </typeparam>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </returns>
        public virtual IEnumerable<K> GetAll<K>() where K : TEntity
        {
            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetAllRepository,
                    typeof (K).Name));

            //Create IObjectSet and perform query
            return (_CurrentUoW.CreateSet<TEntity>().OfType<K>()).AsEnumerable<K>();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <typeparam name="K">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </typeparam>
        /// <typeparam name="S">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </typeparam>
        /// <param name="pageIndex">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <param name="pageCount">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <param name="orderByExpression">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <param name="ascending">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </returns>
        public virtual IEnumerable<K> GetPagedElements<K, S>(int pageIndex, int pageCount,
            Expression<Func<K, S>> orderByExpression, bool ascending)
            where K : TEntity
        {
            //checking query arguments
            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression", Messages.exception_OrderByExpressionCannotBeNull);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetPagedElementsRepository,
                    typeof (K).Name, pageIndex, pageCount, orderByExpression));

            //Create IObjectSet for this type and perform query
            IObjectSet<TEntity> objectSet = _CurrentUoW.CreateSet<TEntity>();

            return (ascending)
                ? objectSet.OfType<K>()
                    .OrderBy(orderByExpression)
                    .Skip(pageIndex*pageCount)
                    .Take(pageCount)
                    .ToList()
                : objectSet.OfType<K>()
                    .OrderByDescending(orderByExpression)
                    .Skip(pageIndex*pageCount)
                    .Take(pageCount)
                    .ToList();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <typeparam name="K">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </typeparam>
        /// <param name="filter">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </returns>
        public virtual IEnumerable<K> GetFilteredElements<K>(Expression<Func<K, bool>> filter)
            where K : TEntity
        {
            //checking query arguments
            if (filter == null)
                throw new ArgumentNullException("filter", Messages.exception_FilterCannotBeNull);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetFilteredElementsRepository,
                    typeof (K).Name, filter));

            //Create IObjectSet and perform query
            return _CurrentUoW.CreateSet<TEntity>()
                .OfType<K>()
                .Where(filter)
                .ToList();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <typeparam name="K">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </typeparam>
        /// <typeparam name="S">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </typeparam>
        /// <param name="filter">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <param name="orderByExpression">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <param name="ascending">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <returns></returns>
        public virtual IEnumerable<K> GetFilteredElements<K, S>(Expression<Func<K, bool>> filter,
            Expression<Func<K, S>> orderByExpression, bool ascending)
            where K : TEntity
        {
            //checking query arguments
            if (filter == null)
                throw new ArgumentNullException("filter", Messages.exception_FilterCannotBeNull);

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression", Messages.exception_OrderByExpressionCannotBeNull);

            _TraceManager.TraceInfo(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Messages.trace_GetFilteredElementsRepository,
                    typeof (K).Name,
                    filter
                    ));

            //Create IObjectSet for this particular type and query this

            IObjectSet<TEntity> objectSet = _CurrentUoW.CreateSet<TEntity>();

            return (ascending)
                ? objectSet.OfType<K>()
                    .Where(filter)
                    .OrderBy(orderByExpression)
                    .ToList()
                : objectSet.OfType<K>()
                    .Where(filter)
                    .OrderByDescending(orderByExpression)
                    .ToList();
        }

        #endregion
    }
}