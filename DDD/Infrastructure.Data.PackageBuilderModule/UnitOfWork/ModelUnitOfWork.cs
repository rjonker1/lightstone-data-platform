using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LightstoneApp.Domain.Core.Seedwork;
using LightstoneApp.Domain.PackageBuilderModule.EntityModel;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.Data.Core.Seedwork;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.UnitOfWork
{
    public class ModelUnitOfWork : LightstoneAppDatabaseEntities, IUnitOfWork
    {
        #region IQueryableUnitOfWork

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public IQueryable<TEntity> GetQueryable<TEntity>(List<string> includes = null, Expression<Func<TEntity, bool>> filter = null, int pageGo = 0, int pageSize = 0, List<string> orderBy = null, bool orderAscendent = false) where TEntity : class
        {
            IQueryable<TEntity> items = Set<TEntity>();

            if (includes != null && includes.Any())
                includes.Where(i => i != null).ToList().ForEach(i => { items = items.Include(i); });

            if (filter != null)
                items = items.Where(filter);

            if (pageSize > 0)
            {
                if (orderBy != null && orderBy.Any())
                {
                    orderBy.Where(i => i != null).ToList().ForEach(s => items = QueryableUtils.CallOrderBy(items, s, orderAscendent));
                    items = items.Skip(pageSize * (pageGo - 1));
                }
                items = items.Take(pageSize);
            }

            return items;
        }

        public void SetEntryState<TEntity>(TEntity item, EntityState state) where TEntity : class
        {
            Entry(item).State = state;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            Entry(original).CurrentValues.SetValues(current);
        }

        public int Commit()
        {
            SetTracking();
            return base.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            SetTracking();
            return await base.SaveChangesAsync();
        }

        public IQueryable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<TEntity>(sqlQuery, parameters).AsQueryable();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        public async Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            return await Database.ExecuteSqlCommandAsync(sqlCommand, parameters);
        }

        public void SetConnectionDb(string connectionstring)
        {
            if (!string.IsNullOrEmpty(connectionstring))
                Database.Connection.ConnectionString = connectionstring;
        }

        public int CommitAndRefreshChanges()
        {
            var result = 0;
            bool saveFailed;

            do {
                try
                {
                    result = base.SaveChanges();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.ToList().ForEach(entry => entry.OriginalValues.SetValues(entry.GetDatabaseValues()));
                }
            } while (saveFailed);

            return result;
        }

        public async Task<int> CommitAndRefreshChangesAsync()
        {
            var result = 0;
            bool saveFailed;

            do {
                try
                {
                    result = await base.SaveChangesAsync();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.ToList().ForEach(entry => entry.OriginalValues.SetValues(entry.GetDatabaseValuesAsync()));
                }
            } while (saveFailed);

            return result;
        }

        public void RollBackChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public void SetTracking()
        {
            ChangeTracker.Entries<Entity>().Where(entity => entity.Entity.EntityState != null).ToList().ForEach(entry => entry.State = TrackUtils.GetEntityState(entry.Entity.EntityState));
        }

        #endregion
    }
}