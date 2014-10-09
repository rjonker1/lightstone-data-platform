using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.Core.Seedwork
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(TEntity item);

        void Modify(TEntity item);

        void Remove(TEntity item);

        void Merge(TEntity persisted, TEntity current);

        TEntity Get(List<object> keyValues);

        Task<TEntity> GetAsync(List<object> keyValues);

        List<TEntity> GetAll(List<string> includes);

        Task<List<TEntity>> GetAllAsync(List<string> includes);

        List<TEntity> AllMatching(Expression<Func<TEntity, bool>> filter, List<string> includes);

        Task<List<TEntity>> AllMatchingAsync(Expression<Func<TEntity, bool>> filter, List<string> includes);

        PagedCollection<TEntity> AllMatchingPaged(Expression<Func<TEntity, bool>> filter, List<string> includes,
            int pageIndex, int pageSize, List<string> sortFields, bool ascending);

        Task<PagedCollection<TEntity>> AllMatchingPagedAsync(Expression<Func<TEntity, bool>> filter,
            List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool orderAscendent);

        int AllMatchingCount(Expression<Func<TEntity, bool>> filter, List<string> includes);

        Task<int> AllMatchingCountAsync(Expression<Func<TEntity, bool>> filter, List<string> includes);

        void Save<TAggregate>(TAggregate aggregate) where TAggregate : IAggregate;
        void CommitChanges();

        TAggregate GetById<TAggregate>(String aggregateId) where TAggregate : IAggregate;

        TAggregate[] GetById<TAggregate>(params string[] aggregateIds) where TAggregate : IAggregate;
    }
}