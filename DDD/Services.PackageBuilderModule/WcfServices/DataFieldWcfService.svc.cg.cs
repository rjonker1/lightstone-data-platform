
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
    public partial class DataFieldWcfService : IDataFieldWcfService
    {
    	#region Fields
    
        private readonly IDataFieldAppService _serviceDataField;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of DataField distributed service
        /// </summary>
        /// <param name="service">Application dependency</param>
        public DataFieldWcfService(IDataFieldAppService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");
    
            _serviceDataField = service;
        }
    
        #endregion
    
    	#region Public Methods
    
    	/// <summary>
        /// Create
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Add(DataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceDataField.Add(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddDataField Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddDataField End"));
    		
    		return committed;
    	}
    
    	/// <summary>
        /// Create async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> AddAsyncServer(DataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceDataField.AddAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddAsyncDataField Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncDataField End"));
    		
    		return committed;
    	}  
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(DataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceDataField.Modify(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyDataField Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyDataField End"));
        
    		return committed;
    	}
    
    	/// <summary>
        /// Update async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsyncServer(DataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceDataField.ModifyAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyAsyncDataField Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncDataField End"));
        
    		return committed;
    	}     
    
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(DataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _serviceDataField.Remove(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveDataField End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Delete async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsyncServer(DataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _serviceDataField.RemoveAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveAsyncDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncDataField End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public DataField Get(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetDataField Begin"));
    		
    		DataField result = null;
    
    		try
            {
                 result = _serviceDataField.Get(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetDataField End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select async server
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<DataField> GetAsyncServer(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncDataField Begin"));
    		
    		DataField result = null;
    
    		try
            {
                 result = await _serviceDataField.GetAsync(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAsyncDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncDataField End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<DataField> GetAll(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllDataField Begin"));
    		
    		List<DataField> result = null;
    
    		try
            {
                 result = _serviceDataField.GetAll(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllDataField End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select all async server
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public async Task<List<DataField>> GetAllAsyncServer(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncDataField Begin"));
    		
    		List<DataField> result = null;
    
    		try
            {
                 result = await _serviceDataField.GetAllAsync(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllAsyncDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncDataField End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result</returns>
        public List<DataField> FindByFilter(CustomQuery<DataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterDataField Begin"));
    
    		List<DataField> result = null;
    
    		try
            {
    			result = _serviceDataField.FindByFilter(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterDataField End"));
            
            return result;
        }
    
    	/// <summary>
        /// Find by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result (task)</returns>
        public async Task<List<DataField>> FindByFilterAsyncServer(CustomQuery<DataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncDataField Begin"));
    
    		List<DataField> result = null;
    
    		try
            {
    			result = await _serviceDataField.FindByFilterAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterAsyncDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncDataField End"));
            
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
        public PagedCollection<DataField> FindPagedByFilter(CustomQuery<DataField> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterDataField Begin"));
    
    		PagedCollection<DataField> result = null;
    
    		try
            {
    			result = _serviceDataField.FindPagedByFilter(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterDataField End"));
            
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
        public async Task<PagedCollection<DataField>> FindPagedByFilterAsyncServer(CustomQuery<DataField> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncDataField Begin"));
    
    		PagedCollection<DataField> result = null;
    
    		try
            {
    			result = await _serviceDataField.FindPagedByFilterAsync(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterAsyncDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncDataField End"));
            
            return result;
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total</returns>
    	public int CountFind(CustomQuery<DataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindDataField Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = _serviceDataField.CountFind(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindDataField End"));
            
            return result;
        }
    
    	/// <summary>
        /// Total count by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total (task)</returns>
    	public async Task<int> CountFindAsyncServer(CustomQuery<DataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncDataField Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = await _serviceDataField.CountFindAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindAsyncDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncDataField End"));
            
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
            _serviceDataField.Dispose();
        }
    
        #endregion
    }
}
