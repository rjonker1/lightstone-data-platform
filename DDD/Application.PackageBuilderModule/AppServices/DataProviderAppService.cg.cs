using AutoMapper;
using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.Application.PackageBuilderModule.Resx;
using LightstoneApp.Application.PackageBuilderModule.Seedwork;
using LightstoneApp.Domain.PackageBuilderModule.IRepository;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Validator;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LightstoneApp.Application.PackageBuilderModule.AppServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataProviderAppService : IDataProviderAppService
    {
    	#region Fields
        
        private readonly IDataProviderRepository _repositoryDataProvider;
    
        #endregion
    
    	#region Constructor
    
        /// <summary>
        /// Create a new instance of DataProvider application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public DataProviderAppService(IDataProviderRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryDataProvider = repository;
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
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddDataProvider Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryDataProvider.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.DataProvider>(item));
    
    				committed = _repositoryDataProvider.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddDataProvider End"));
        
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Create async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
    	public async Task<bool> AddAsync(DataProvider item, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncDataProvider Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryDataProvider.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.DataProvider>(item));
    
    				committed = await _repositoryDataProvider.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncDataProvider End"));
        
    		return committed > 0;
    	}
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(DataProvider item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyDataProvider Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryDataProvider.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.DataProvider>(item));
    
    				committed = _repositoryDataProvider.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyDataProvider End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Update async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsync(DataProvider item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncDataProvider Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryDataProvider.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.DataProvider>(item));
    
    				committed = await _repositoryDataProvider.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncDataProvider End"));
    	
    		return committed > 0;
    	}
    	
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(DataProvider item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveDataProvider Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryDataProvider.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.DataProvider>(item));
    
    			committed = _repositoryDataProvider.UnitOfWork.Commit();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveDataProvider End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Delete async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsync(DataProvider item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncDataProvider Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryDataProvider.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.DataProvider>(item));
    
    			committed = await _repositoryDataProvider.UnitOfWork.CommitAsync();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncDataProvider End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public DataProvider Get(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetDataProvider Begin"));
    
    		Domain.PackageBuilderModule.Entities.DataProvider data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryDataProvider.Get(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetDataProvider End"));
    	
    		return Mapper.Map<DataProvider>(data);
    	}
    
    	/// <summary>
        /// Select async
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<DataProvider> GetAsync(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncDataProvider Begin"));
    
    		Domain.PackageBuilderModule.Entities.DataProvider data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryDataProvider.GetAsync(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncDataProvider End"));
    	
    		return Mapper.Map<DataProvider>(data);
    	}
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<DataProvider> GetAll(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllDataProvider Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.DataProvider> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryDataProvider.GetAll(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllDataProvider End"));
    	
    		return Mapper.Map<List<DataProvider>>(data);
    	}
    
    	/// <summary>
        /// Select all async
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results (task)</returns>
        public async Task<List<DataProvider>> GetAllAsync(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncDataProvider Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.DataProvider> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryDataProvider.GetAllAsync(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncDataProvider End"));
    	
    		return Mapper.Map<List<DataProvider>>(data);
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<DataProvider> FindByFilter(CustomQuery<DataProvider> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterDataProvider Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.DataProvider> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = _repositoryDataProvider.AllMatching(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterDataProvider End"));
    
            return Mapper.Map<List<DataProvider>>(data);
        }
    
    	/// <summary>
        /// Find by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results (task)</returns>
        public async Task<List<DataProvider>> FindByFilterAsync(CustomQuery<DataProvider> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncDataProvider Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.DataProvider> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = await _repositoryDataProvider.AllMatchingAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncDataProvider End"));
    
            return Mapper.Map<List<DataProvider>>(data);
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
    	/// <returns>Paged results</returns>
        public PagedCollection<DataProvider> FindPagedByFilter(CustomQuery<DataProvider> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterDataProvider Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.DataProvider> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = _repositoryDataProvider.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterDataProvider End"));
    
            return Mapper.Map<PagedCollection<DataProvider>>(data);
        }
    
    	/// <summary>
    	/// Find by filter paged async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="pageGo">Go to page</param>
        /// <param name="pageSize">Items request</param>
        /// <param name="orderBy">Fields order</param>
        /// <param name="ascending">Order ascendent</param>
        /// <param name="session">Session</param>
    	/// <returns>Paged results (task)</returns>
        public async Task<PagedCollection<DataProvider>> FindPagedByFilterAsync(CustomQuery<DataProvider> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncDataProvider Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.DataProvider> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = await _repositoryDataProvider.AllMatchingPagedAsync(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncDataProvider End"));
    
            return Mapper.Map<PagedCollection<DataProvider>>(data);
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals</returns>
        public int CountFind(CustomQuery<DataProvider> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindDataProvider Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = _repositoryDataProvider.AllMatchingCount(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindDataProvider End"));
    
            return count;
        }
    
    	/// <summary>
        /// Total count by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals (task)</returns>
        public async Task<int> CountFindAsync(CustomQuery<DataProvider> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncDataProvider Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryDataProvider.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.DataProvider>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = await _repositoryDataProvider.AllMatchingCountAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncDataProvider ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncDataProvider End"));
    
            return count;
        }
    
    	#endregion
    	
    	#region IDisposable Members
    
        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _repositoryDataProvider.Dispose();
        }
    
        #endregion
    }
}
