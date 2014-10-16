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
using LightstoneApp.Infrastructure.Data.Core.Extensions;
using LightstoneApp.Infrastructure.Data.Core.Resources;

namespace LightstoneApp.Infrastructure.Data.Core
{
    /// <summary>
    ///     Default base class for repositories. This generic repository
    ///     is a default implementation of <see cref=" LightstoneApp.Domain.Core.IRepository{TEntity}" />
    ///     and your specific repositories can inherit from this base class so automatically will get default implementation.
    ///     IMPORTANT: Using this Base Repository class IS NOT mandatory. It is just a useful base class:
    ///     You could also decide that you do not want to use this base Repository class, because sometimes you don't want a
    ///     specific Repository getting all these features and it might be wrong for a specific Repository.
    ///     For instance, you could want just read-only data methods for your Repository, etc.
    ///     in that case, just simply do not use this base class on your Repository.
    /// </summary>
    /// <typeparam name="TEntity">Type of elements in repository</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IObjectWithChangeTracker
    {
        #region Members

        private readonly IQueryableUnitOfWork _CurrentUoW;
        private readonly ITraceManager _TraceManager;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create a new instance of Repository
        /// </summary>
        /// <param name="traceManager">Trace Manager dependency</param>
        /// <param name="unitOfWork">A unit of work for this repository</param>
        public Repository(IQueryableUnitOfWork unitOfWork, ITraceManager traceManager)
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

        #region IRepository<TEntity> Members

        /// <summary>
        ///     Return a unit of work in this repository
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _CurrentUoW; }
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="item">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        public virtual void Add(TEntity item)
        {
            //check item
            if (item == null)
                throw new ArgumentNullException("item", Messages.exception_ItemArgumentIsNull);

            //add object to IObjectSet for this type

            //really for STE you have two options, add object and
            //call to ApplyChanges in this objetSet. After 
            //review discussion feedback in our codeplex project
            //ApplyChanges is the best option because solve problems in 
            //many to many associations and AddObject method

            if (item.ChangeTracker != null
                &&
                item.ChangeTracker.State == ObjectState.Added)
            {
                _CurrentUoW.RegisterChanges(item);

                _TraceManager.TraceInfo(
                    string.Format(CultureInfo.InvariantCulture,
                        Messages.trace_AddedItemRepository,
                        typeof (TEntity).Name));
            }
            else
                throw new InvalidOperationException(Messages.exception_ChangeTrackerIsNullOrStateIsNOK);
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="item">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        public virtual void Remove(TEntity item)
        {
            //check item
            if (item == null)
                throw new ArgumentNullException("item", Messages.exception_ItemArgumentIsNull);


            IObjectSet<TEntity> objectSet = CreateSet();

            //Attach object to unit of work and delete this
            // this is valid only if T is a type in model
            objectSet.Attach(item);

            //delete object to IObjectSet for this type
            objectSet.DeleteObject(item);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_DeletedItemRepository,
                    typeof (TEntity).Name));
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="item">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        public virtual void RegisterItem(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            (CreateSet()).Attach(item);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_AttachedItemToRepository,
                    typeof (TEntity).Name));
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="item">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        public virtual void Modify(TEntity item)
        {
            //check arguments
            if (item == null)
                throw new ArgumentNullException("item", Messages.exception_ItemArgumentIsNull);

            //Set modifed state if change tracker is enabled and state is not deleted
            if (item.ChangeTracker != null
                &&
                ((item.ChangeTracker.State & ObjectState.Deleted) != ObjectState.Deleted)
                )
            {
                item.MarkAsModified();
            }
            //apply changes for item object
            _CurrentUoW.RegisterChanges(item);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_AppliedChangedItemRepository,
                    typeof (TEntity).Name));
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetAllRepository,
                    typeof (TEntity).Name));

            //Create IObjectSet and perform query 
            return (CreateSet()).AsEnumerable();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="specification">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </returns>
        public virtual IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification)
        {
            if (specification == null)
                throw new ArgumentNullException("specification");

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetBySpec,
                    typeof (TEntity).Name));

            return (CreateSet().Where(specification.SatisfiedBy())
                .AsEnumerable());
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
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
        public virtual IEnumerable<TEntity> GetPagedElements<S>(int pageIndex, int pageCount,
            Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {
            //checking arguments for this query 
            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression", Messages.exception_OrderByExpressionCannotBeNull);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetPagedElementsRepository,
                    typeof (TEntity).Name, pageIndex, pageCount, orderByExpression));

            //Create associated IObjectSet and perform query

            IObjectSet<TEntity> objectSet = CreateSet();

            return objectSet.Paginate(orderByExpression, pageIndex, pageCount, ascending);
        }


        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
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
        /// <param name="specification">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <param name="ascending">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </returns>
        public virtual IEnumerable<TEntity> GetPagedElements<S>(int pageIndex, int pageCount,
            Expression<Func<TEntity, S>> orderByExpression, ISpecification<TEntity> specification, bool ascending)
        {
            //checking arguments for this query 
            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression", Messages.exception_OrderByExpressionCannotBeNull);

            if (specification == null)
                throw new ArgumentNullException("specification", Messages.exception_SpecificationIsNull);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetPagedElementsRepository,
                    typeof (TEntity).Name, pageIndex, pageCount, orderByExpression));

            //Create associated IObjectSet and perform query

            IObjectSet<TEntity> objectSet = CreateSet();

            //this query cannot  use Paginate IQueryable extension method because Linq queries cannot be
            //merged with Object Builder methods. See Entity Framework documentation for more information

            return (ascending)
                ? objectSet
                    .Where(specification.SatisfiedBy())
                    .OrderBy(orderByExpression)
                    .Skip(pageIndex*pageCount)
                    .Take(pageCount)
                    .ToList()
                : objectSet
                    .Where(specification.SatisfiedBy())
                    .OrderByDescending(orderByExpression)
                    .Skip(pageIndex*pageCount)
                    .Take(pageCount)
                    .ToList();
        }


        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="filter">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
        /// <returns>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </returns>
        public virtual IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            //checking query arguments
            if (filter == null)
                throw new ArgumentNullException("filter", Messages.exception_FilterCannotBeNull);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetFilteredElementsRepository,
                    typeof (TEntity).Name, filter));

            //Create IObjectSet and perform query
            return CreateSet().Where(filter)
                .ToList();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="filter">
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </param>
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
        public virtual IEnumerable<TEntity> GetFilteredElements<S>(Expression<Func<TEntity, bool>> filter, int pageIndex,
            int pageCount, Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {
            //checking query arguments
            if (filter == null)
                throw new ArgumentNullException("filter", Messages.exception_FilterCannotBeNull);

            if (pageIndex < 0)
                throw new ArgumentException(Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression", Messages.exception_OrderByExpressionCannotBeNull);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetFilteredPagedElementsRepository,
                    typeof (TEntity).Name, filter, pageIndex, pageCount, orderByExpression));

            //Create IObjectSet for this particular type and query this
            IObjectSet<TEntity> objectSet = CreateSet();

            return (ascending)
                ? objectSet
                    .Where(filter)
                    .OrderBy(orderByExpression)
                    .Skip(pageIndex*pageCount)
                    .Take(pageCount)
                    .ToList()
                : objectSet
                    .Where(filter)
                    .OrderByDescending(orderByExpression)
                    .Skip(pageIndex*pageCount)
                    .Take(pageCount)
                    .ToList();
        }

        /// <summary>
        ///     <see cref="LightstoneApp.Domain.Core.IRepository{TEntity}" />
        /// </summary>
        /// <param name="filter">
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
        public virtual IEnumerable<TEntity> GetFilteredElements<S>(Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, S>> orderByExpression, bool ascending)
        {
            //Checking query arguments
            if (filter == null)
                throw new ArgumentNullException("filter", Messages.exception_FilterCannotBeNull);

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression", Messages.exception_OrderByExpressionCannotBeNull);

            _TraceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                    Messages.trace_GetFilteredElementsRepository,
                    typeof (TEntity).Name, filter));

            //Create IObjectSet for this type and perform query
            IObjectSet<TEntity> objectSet = CreateSet();

            return (ascending)
                ? objectSet
                    .Where(filter)
                    .OrderBy(orderByExpression)
                    .ToList()
                : objectSet
                    .Where(filter)
                    .OrderByDescending(orderByExpression)
                    .ToList();
        }

        #endregion

        #region Private Methods

        private IObjectSet<TEntity> CreateSet()
        {
            if (_CurrentUoW != null)
            {
                IObjectSet<TEntity> objectSet = _CurrentUoW.CreateSet<TEntity>();

                //set merge option to underlying ObjectQuery

                var query = objectSet as ObjectQuery<TEntity>;

                if (query != null) // check if this objectset is not in memory object set for testing
                    query.MergeOption = MergeOption.NoTracking;

                return objectSet;
            }
            throw new InvalidOperationException(Messages.exception_ContainerCannotBeNull);
        }

        #endregion
    }
}