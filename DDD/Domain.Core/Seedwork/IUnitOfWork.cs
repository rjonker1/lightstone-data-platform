using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LightstoneApp.Domain.Core.Seedwork
{
    /// <summary>
    /// The UnitOfWork contract for EF implementation
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;

        IQueryable<TEntity> GetQueryable<TEntity>(List<string> includes = null, Expression<Func<TEntity, bool>> filter = null, int pageGo = 0, int pageSize = 0, List<string> orderBy = null, bool orderAscendent = false) where TEntity : class;

        void SetEntryState<TEntity>(TEntity item, EntityState state) where TEntity : class;

        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;

        IQueryable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        int ExecuteCommand(string sqlCommand, params object[] parameters);

        Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters);

        void SetConnectionDb(string connectionstring);

        int Commit();

        Task<int> CommitAsync();

        int CommitAndRefreshChanges();

        Task<int> CommitAndRefreshChangesAsync();

        void RollBackChanges();

        void SetTracking();
    }
}