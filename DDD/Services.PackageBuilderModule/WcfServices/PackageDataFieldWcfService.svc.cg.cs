
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
    public partial class PackageDataFieldWcfService : IPackageDataFieldWcfService
    {
    	#region Fields
    
        private readonly IPackageDataFieldAppService _servicePackageDataField;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of PackageDataField distributed service
        /// </summary>
        /// <param name="service">Application dependency</param>
        public PackageDataFieldWcfService(IPackageDataFieldAppService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");
    
            _servicePackageDataField = service;
        }
    
        #endregion
    
    	#region Public Methods
    
    	/// <summary>
        /// Create
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Add(PackageDataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddPackageDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _servicePackageDataField.Add(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddPackageDataField Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddPackageDataField End"));
    		
    		return committed;
    	}
    
    	/// <summary>
        /// Create async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> AddAsyncServer(PackageDataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncPackageDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _servicePackageDataField.AddAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "AddAsyncPackageDataField Service Layer ERROR"), ex);
            }    
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - AddAsyncPackageDataField End"));
    		
    		return committed;
    	}  
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(PackageDataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyPackageDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _servicePackageDataField.Modify(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyPackageDataField Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyPackageDataField End"));
        
    		return committed;
    	}
    
    	/// <summary>
        /// Update async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsyncServer(PackageDataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncPackageDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _servicePackageDataField.ModifyAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "ModifyAsyncPackageDataField Service Layer ERROR"), ex);
            }            
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - ModifyAsyncPackageDataField End"));
        
    		return committed;
    	}     
    
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(PackageDataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemovePackageDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = _servicePackageDataField.Remove(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemovePackageDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemovePackageDataField End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Delete async server
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsyncServer(PackageDataField item, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncPackageDataField Begin"));
    		
    		var committed = false;
    
    		try
            {
                 committed = await _servicePackageDataField.RemoveAsync(item, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "RemoveAsyncPackageDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - RemoveAsyncPackageDataField End"));
        
    		return committed;			
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public PackageDataField Get(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetPackageDataField Begin"));
    		
    		PackageDataField result = null;
    
    		try
            {
                 result = _servicePackageDataField.Get(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetPackageDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetPackageDataField End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select async server
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<PackageDataField> GetAsyncServer(List<object> keyValues, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncPackageDataField Begin"));
    		
    		PackageDataField result = null;
    
    		try
            {
                 result = await _servicePackageDataField.GetAsync(keyValues, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAsyncPackageDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAsyncPackageDataField End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<PackageDataField> GetAll(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllPackageDataField Begin"));
    		
    		List<PackageDataField> result = null;
    
    		try
            {
                 result = _servicePackageDataField.GetAll(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllPackageDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllPackageDataField End"));
    		
    		return result;
        }
    
    	/// <summary>
        /// Select all async server
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public async Task<List<PackageDataField>> GetAllAsyncServer(List<string> includes, Session session = null)
        {
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncPackageDataField Begin"));
    		
    		List<PackageDataField> result = null;
    
    		try
            {
                 result = await _servicePackageDataField.GetAllAsync(includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "GetAllAsyncPackageDataField Service Layer ERROR"), ex);
            }  
    
    		LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - GetAllAsyncPackageDataField End"));
    		
    		return result;
        }
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result</returns>
        public List<PackageDataField> FindByFilter(CustomQuery<PackageDataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterPackageDataField Begin"));
    
    		List<PackageDataField> result = null;
    
    		try
            {
    			result = _servicePackageDataField.FindByFilter(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterPackageDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterPackageDataField End"));
            
            return result;
        }
    
    	/// <summary>
        /// Find by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of result (task)</returns>
        public async Task<List<PackageDataField>> FindByFilterAsyncServer(CustomQuery<PackageDataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncPackageDataField Begin"));
    
    		List<PackageDataField> result = null;
    
    		try
            {
    			result = await _servicePackageDataField.FindByFilterAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindByFilterAsyncPackageDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindByFilterAsyncPackageDataField End"));
            
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
        public PagedCollection<PackageDataField> FindPagedByFilter(CustomQuery<PackageDataField> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterPackageDataField Begin"));
    
    		PagedCollection<PackageDataField> result = null;
    
    		try
            {
    			result = _servicePackageDataField.FindPagedByFilter(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterPackageDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterPackageDataField End"));
            
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
        public async Task<PagedCollection<PackageDataField>> FindPagedByFilterAsyncServer(CustomQuery<PackageDataField> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncPackageDataField Begin"));
    
    		PagedCollection<PackageDataField> result = null;
    
    		try
            {
    			result = await _servicePackageDataField.FindPagedByFilterAsync(filter, includes, pageGo, pageSize, orderBy, ascending, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "FindPagedByFilterAsyncPackageDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - FindPagedByFilterAsyncPackageDataField End"));
            
            return result;
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total</returns>
    	public int CountFind(CustomQuery<PackageDataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindPackageDataField Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = _servicePackageDataField.CountFind(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindPackageDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindPackageDataField End"));
            
            return result;
        }
    
    	/// <summary>
        /// Total count by filter async server
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Total (task)</returns>
    	public async Task<int> CountFindAsyncServer(CustomQuery<PackageDataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncPackageDataField Begin"));
    
    		var result = 0;
    
    		try
            {
    			result = await _servicePackageDataField.CountFindAsync(filter, includes, session);
            }
            catch (Exception ex)
            {
    			LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "CountFindAsyncPackageDataField Service Layer ERROR"), ex);
            }
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Service Layer - CountFindAsyncPackageDataField End"));
            
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
            _servicePackageDataField.Dispose();
        }
    
        #endregion
    }
}
