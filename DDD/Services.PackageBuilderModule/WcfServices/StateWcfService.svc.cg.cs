
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
    public partial class StateWcfService : IStateWcfService
    {
    	#region Fields
    
        private readonly IStateAppService _serviceState;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of State distributed service
        /// </summary>
        /// <param name="service">Application dependency</param>
        public StateWcfService(IStateAppService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");
    
            _serviceState = service;
        }
    
        #endregion
    
    	#region Public Methods
    
    	/// <summary>
        /// Create
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Add(State item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddState Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceState.Add(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddState Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddState End"));
    		
    		return committed;
    	}
    
    	/// <summary>
        /// Create async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> AddAsyncServer(State item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncState Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceState.AddAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddAsyncState Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncState End"));
    		
    		return committed;
    	}  
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(State item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyState Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceState.Modify(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyState Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyState End"));
        
    		return committed;
    	}
    
    	/// <summary>
        /// Update async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsyncServer(State item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncState Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceState.ModifyAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyAsyncState Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncState End"));
        
    		return committed;
    	}     
    
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(State item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveState Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceState.Remove(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveState Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveState End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Delete async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsyncServer(State item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncState Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceState.RemoveAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveAsyncState Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncState End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public State Get(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetState Begin"));
    		
    		State result = null;
    
    		try
            {
                 result = _serviceState.Get(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetState Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetState End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select async server
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<State> GetAsyncServer(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncState Begin"));
    		
    		State result = null;
    
    		try
            {
                 result = await _serviceState.GetAsync(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAsyncState Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncState End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<State> GetAll(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllState Begin"));
    		
    		List<State> result = null;
    
    		try
            {
                 result = _serviceState.GetAll(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllState Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllState End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select all async server
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public async Task<List<State>> GetAllAsyncServer(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncState Begin"));
    		
    		List<State> result = null;
    
    		try
            {
                 result = await _serviceState.GetAllAsync(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllAsyncState Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncState End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result</returns>
        public List<State> FindByFilter(CustomQuery<State> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterState Begin"));
    
    		List<State> result = null;
    
    		try
            {
    			result = _serviceState.FindByFilter(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterState Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterState End"));
            
            return result;
        }
    
    	/// <summary>
        /// Find by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result (task)</returns>
        public async Task<List<State>> FindByFilterAsyncServer(CustomQuery<State> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncState Begin"));
    
    		List<State> result = null;
    
    		try
            {
    			result = await _serviceState.FindByFilterAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterAsyncState Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncState End"));
            
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
        public PagedCollection<State> FindPagedByFilter(CustomQuery<State> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterState Begin"));
    
    		PagedCollection<State> result = null;
    
    		try
            {
    			result = _serviceState.FindPagedByFilter(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterState Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterState End"));
            
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
        public async Task<PagedCollection<State>> FindPagedByFilterAsyncServer(CustomQuery<State> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncState Begin"));
    
    		PagedCollection<State> result = null;
    
    		try
            {
    			result = await _serviceState.FindPagedByFilterAsync(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterAsyncState Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncState End"));
            
            return result;
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total</returns>
    	public int CountFind(CustomQuery<State> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindState Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = _serviceState.CountFind(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindState Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindState End"));
            
            return result;
        }
    
    	/// <summary>
        /// Total count by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total (task)</returns>
    	public async Task<int> CountFindAsyncServer(CustomQuery<State> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncState Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = await _serviceState.CountFindAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindAsyncState Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncState End"));
            
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
            _serviceState.Dispose();
        }
    
        #endregion
    }
}
