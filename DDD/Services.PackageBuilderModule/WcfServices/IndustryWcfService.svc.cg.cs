
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
    public partial class IndustryWcfService : IIndustryWcfService
    {
    	#region Fields
    
        private readonly IIndustryAppService _serviceIndustry;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Industry distributed service
        /// </summary>
        /// <param name="service">Application dependency</param>
        public IndustryWcfService(IIndustryAppService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");
    
            _serviceIndustry = service;
        }
    
        #endregion
    
    	#region Public Methods
    
    	/// <summary>
        /// Create
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Add(Industry item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddIndustry Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceIndustry.Add(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddIndustry Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddIndustry End"));
    		
    		return committed;
    	}
    
    	/// <summary>
        /// Create async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> AddAsyncServer(Industry item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncIndustry Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceIndustry.AddAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddAsyncIndustry Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncIndustry End"));
    		
    		return committed;
    	}  
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(Industry item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyIndustry Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceIndustry.Modify(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyIndustry Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyIndustry End"));
        
    		return committed;
    	}
    
    	/// <summary>
        /// Update async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsyncServer(Industry item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncIndustry Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceIndustry.ModifyAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyAsyncIndustry Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncIndustry End"));
        
    		return committed;
    	}     
    
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(Industry item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveIndustry Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceIndustry.Remove(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveIndustry Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveIndustry End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Delete async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsyncServer(Industry item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncIndustry Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceIndustry.RemoveAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveAsyncIndustry Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncIndustry End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public Industry Get(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetIndustry Begin"));
    		
    		Industry result = null;
    
    		try
            {
                 result = _serviceIndustry.Get(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetIndustry Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetIndustry End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select async server
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<Industry> GetAsyncServer(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncIndustry Begin"));
    		
    		Industry result = null;
    
    		try
            {
                 result = await _serviceIndustry.GetAsync(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAsyncIndustry Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncIndustry End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Industry> GetAll(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllIndustry Begin"));
    		
    		List<Industry> result = null;
    
    		try
            {
                 result = _serviceIndustry.GetAll(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllIndustry Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllIndustry End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select all async server
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public async Task<List<Industry>> GetAllAsyncServer(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncIndustry Begin"));
    		
    		List<Industry> result = null;
    
    		try
            {
                 result = await _serviceIndustry.GetAllAsync(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllAsyncIndustry Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncIndustry End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result</returns>
        public List<Industry> FindByFilter(CustomQuery<Industry> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterIndustry Begin"));
    
    		List<Industry> result = null;
    
    		try
            {
    			result = _serviceIndustry.FindByFilter(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterIndustry Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterIndustry End"));
            
            return result;
        }
    
    	/// <summary>
        /// Find by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result (task)</returns>
        public async Task<List<Industry>> FindByFilterAsyncServer(CustomQuery<Industry> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncIndustry Begin"));
    
    		List<Industry> result = null;
    
    		try
            {
    			result = await _serviceIndustry.FindByFilterAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterAsyncIndustry Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncIndustry End"));
            
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
        public PagedCollection<Industry> FindPagedByFilter(CustomQuery<Industry> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterIndustry Begin"));
    
    		PagedCollection<Industry> result = null;
    
    		try
            {
    			result = _serviceIndustry.FindPagedByFilter(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterIndustry Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterIndustry End"));
            
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
        public async Task<PagedCollection<Industry>> FindPagedByFilterAsyncServer(CustomQuery<Industry> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncIndustry Begin"));
    
    		PagedCollection<Industry> result = null;
    
    		try
            {
    			result = await _serviceIndustry.FindPagedByFilterAsync(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterAsyncIndustry Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncIndustry End"));
            
            return result;
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total</returns>
    	public int CountFind(CustomQuery<Industry> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindIndustry Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = _serviceIndustry.CountFind(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindIndustry Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindIndustry End"));
            
            return result;
        }
    
    	/// <summary>
        /// Total count by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total (task)</returns>
    	public async Task<int> CountFindAsyncServer(CustomQuery<Industry> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncIndustry Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = await _serviceIndustry.CountFindAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindAsyncIndustry Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncIndustry End"));
            
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
            _serviceIndustry.Dispose();
        }
    
        #endregion
    }
}