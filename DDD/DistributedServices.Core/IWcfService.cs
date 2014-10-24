using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using LightstoneApp.DistributedServices.Core.ErrorHandlers;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.DistributedServices.Core
{
    [ServiceContract]
    public interface IWcfService<TEntity> : IDisposable where TEntity : Entity
    {
        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        bool Add(TEntity item, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        Task<bool> AddAsyncServer(TEntity item, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        bool Modify(TEntity item, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        Task<bool> ModifyAsyncServer(TEntity item, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        bool Remove(TEntity item, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        Task<bool> RemoveAsyncServer(TEntity item, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        TEntity Get(List<object> keyValues, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        Task<TEntity> GetAsyncServer(List<object> keyValues, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<TEntity> GetAll(List<string> includes, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        Task<List<TEntity>> GetAllAsyncServer(List<string> includes, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        List<TEntity> FindByFilter(CustomQuery<TEntity> filter, List<string> includes, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        Task<List<TEntity>> FindByFilterAsyncServer(CustomQuery<TEntity> filter, List<string> includes, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        PagedCollection<TEntity> FindPagedByFilter(CustomQuery<TEntity> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool orderAscendent, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        Task<PagedCollection<TEntity>> FindPagedByFilterAsyncServer(CustomQuery<TEntity> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        int CountFind(CustomQuery<TEntity> filter, List<string> includes, Session session);

        [OperationContract]
        [FaultContract(typeof(ApplicationServiceError))]
        Task<int> CountFindAsyncServer(CustomQuery<TEntity> filter, List<string> includes, Session session);
    }
}