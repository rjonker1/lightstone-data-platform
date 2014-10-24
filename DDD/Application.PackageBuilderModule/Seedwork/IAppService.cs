using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Application.PackageBuilderModule.Seedwork
{
    public interface IAppService<TEntity> : IDisposable where TEntity : Entity
    {
        bool Add(TEntity item, Session session);

        Task<bool> AddAsync(TEntity item, Session session);

        bool Modify(TEntity item, Session session);

        Task<bool> ModifyAsync(TEntity item, Session session);

        bool Remove(TEntity item, Session session);

        Task<bool> RemoveAsync(TEntity item, Session session);

        TEntity Get(List<object> keyValues, Session session);

        Task<TEntity> GetAsync(List<object> keyValues, Session session);

        List<TEntity> GetAll(List<string> includes, Session session);

        Task<List<TEntity>> GetAllAsync(List<string> includes, Session session);

        List<TEntity> FindByFilter(CustomQuery<TEntity> filter, List<string> includes, Session session);

        Task<List<TEntity>> FindByFilterAsync(CustomQuery<TEntity> filter, List<string> includes, Session session);

        PagedCollection<TEntity> FindPagedByFilter(CustomQuery<TEntity> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool orderAscendent, Session session);

        Task<PagedCollection<TEntity>> FindPagedByFilterAsync(CustomQuery<TEntity> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session);

        int CountFind(CustomQuery<TEntity> filter, List<string> includes, Session session);

        Task<int> CountFindAsync(CustomQuery<TEntity> filter, List<string> includes, Session session);
    }
}