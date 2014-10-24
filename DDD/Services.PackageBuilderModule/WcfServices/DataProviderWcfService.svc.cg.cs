
using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.DistributedServices.Core.ErrorHandlers;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Services.PackageBuilderModule.InstanceProviders;
using System.Globalization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace LightstoneApp.Services.PackageBuilderModule.WcfServices
{
    using System;
    using System.Collections.Generic;
    
    [ApplicationErrorHandlerAttribute]
    [UnityInstanceProviderServiceBehavior]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public partial class DataProviderWcfService : IDataProviderWcfService
    {
    	#region Fields
    
        private readonly IDataProviderAppService _serviceDataProvider;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of DataProvider distributed service
        /// </summary>
        /// <param name="service">Application dependency</param>
        public DataProviderWcfService(IDataProviderAppService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");
    
            _serviceDataProvider = service;
        }
    
        #endregion
    
    	#region Public Methods
    
    	/// <summary>
        /// Create
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Add(DataProvider item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddDataProvider Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceDataProvider.Add(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddDataProvider Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddDataProvider End"));
    		
    		return committed;
    	}
    
    	/// <summary>
        /// Create async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> AddAsyncServer(DataProvider item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncDataProvider Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceDataProvider.AddAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddAsyncDataProvider Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncDataProvider End"));
    		
    		return committed;
    	}  
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(DataProvider item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyDataProvider Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceDataProvider.Modify(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyDataProvider Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyDataProvider End"));
        
    		return committed;
    	}
    
    	/// <summary>
        /// Update async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsyncServer(DataProvider item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncDataProvider Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceDataProvider.ModifyAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyAsyncDataProvider Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncDataProvider End"));
        
    		return committed;
    	}     
    
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(DataProvider item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveDataProvider Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceDataProvider.Remove(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveDataProvider Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveDataProvider End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Delete async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsyncServer(DataProvider item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncDataProvider Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceDataProvider.RemoveAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveAsyncDataProvider Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncDataProvider End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public DataProvider Get(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetDataProvider Begin"));
    		
    		DataProvider result = null;
    
    		try
            {
                 result = _serviceDataProvider.Get(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetDataProvider Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetDataProvider End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select async server
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<DataProvider> GetAsyncServer(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncDataProvider Begin"));
    		
    		DataProvider result = null;
    
    		try
            {
                 result = await _serviceDataProvider.GetAsync(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAsyncDataProvider Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncDataProvider End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<DataProvider> GetAll(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllDataProvider Begin"));
    		
    		List<DataProvider> result = null;
    
    		try
            {
                 result = _serviceDataProvider.GetAll(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllDataProvider Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllDataProvider End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select all async server
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public async Task<List<DataProvider>> GetAllAsyncServer(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncDataProvider Begin"));
    		
    		List<DataProvider> result = null;
    
    		try
            {
                 result = await _serviceDataProvider.GetAllAsync(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllAsyncDataProvider Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncDataProvider End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result</returns>
        public List<DataProvider> FindByFilter(CustomQuery<DataProvider> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterDataProvider Begin"));
    
    		List<DataProvider> result = null;
    
    		try
            {
    			result = _serviceDataProvider.FindByFilter(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterDataProvider Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterDataProvider End"));
            
            return result;
        }
    
    	/// <summary>
        /// Find by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result (task)</returns>
        public async Task<List<DataProvider>> FindByFilterAsyncServer(CustomQuery<DataProvider> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncDataProvider Begin"));
    
    		List<DataProvider> result = null;
    
    		try
            {
    			result = await _serviceDataProvider.FindByFilterAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterAsyncDataProvider Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncDataProvider End"));
            
            return result;
        }
    
        /// <summary>
        /// Find by filter paged
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="pageGo">Go to page</param>
        /// <param name="pageSize">Items request</param>
        /// <param name="orderBy">Fields order</param>
        /// <param name="ascending">Order ascendent</param>
        /// <param name="session">Session</param>
        /// <returns>Paged result</returns>
        public PagedCollection<DataProvider> FindPagedByFilter(CustomQuery<DataProvider> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterDataProvider Begin"));
    
    		PagedCollection<DataProvider> result = null;
    
    		try
            {
    			result = _serviceDataProvider.FindPagedByFilter(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterDataProvider Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterDataProvider End"));
            
            return result;
        }
    
    	/// <summary>
    	/// Find by filter paged async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="pageGo">Go to page</param>
        /// <param name="pageSize">Items request</param>
        /// <param name="orderBy">Fields order</param>
        /// <param name="ascending">Order ascendent</param>
        /// <param name="session">Session</param>
        /// <returns>Paged result (task)</returns>
        public async Task<PagedCollection<DataProvider>> FindPagedByFilterAsyncServer(CustomQuery<DataProvider> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncDataProvider Begin"));
    
    		PagedCollection<DataProvider> result = null;
    
    		try
            {
    			result = await _serviceDataProvider.FindPagedByFilterAsync(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterAsyncDataProvider Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncDataProvider End"));
            
            return result;
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total</returns>
    	public int CountFind(CustomQuery<DataProvider> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindDataProvider Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = _serviceDataProvider.CountFind(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindDataProvider Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindDataProvider End"));
            
            return result;
        }
    
    	/// <summary>
        /// Total count by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total (task)</returns>
    	public async Task<int> CountFindAsyncServer(CustomQuery<DataProvider> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncDataProvider Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = await _serviceDataProvider.CountFindAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindAsyncDataProvider Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncDataProvider End"));
            
            return result;
        }
    
    	#endregion
    
    	#region IDisposable Members
    
        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _serviceDataProvider.Dispose();
        }
    
        #endregion
    }
}
