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
    
    public partial class IndustryAppService : IIndustryAppService
    {
    	#region Fields
        
        private readonly IIndustryRepository _repositoryIndustry;
    
        #endregion
    
    	#region Constructor
    
        /// <summary>
        /// Create a new instance of Industry application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public IndustryAppService(IIndustryRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryIndustry = repository;
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
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddIndustry Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryIndustry.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.Industry>(item));
    
    				committed = _repositoryIndustry.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddIndustry End"));
        
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Create async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
    	public async Task<bool> AddAsync(Industry item, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncIndustry Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryIndustry.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.Industry>(item));
    
    				committed = await _repositoryIndustry.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncIndustry End"));
        
    		return committed > 0;
    	}
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(Industry item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyIndustry Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryIndustry.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.Industry>(item));
    
    				committed = _repositoryIndustry.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyIndustry End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Update async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsync(Industry item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncIndustry Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryIndustry.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.Industry>(item));
    
    				committed = await _repositoryIndustry.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncIndustry End"));
    	
    		return committed > 0;
    	}
    	
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(Industry item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveIndustry Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryIndustry.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.Industry>(item));
    
    			committed = _repositoryIndustry.UnitOfWork.Commit();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveIndustry End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Delete async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsync(Industry item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncIndustry Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryIndustry.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.Industry>(item));
    
    			committed = await _repositoryIndustry.UnitOfWork.CommitAsync();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncIndustry End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public Industry Get(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetIndustry Begin"));
    
    		Domain.PackageBuilderModule.Entities.Industry data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryIndustry.Get(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetIndustry End"));
    	
    		return Mapper.Map<Industry>(data);
    	}
    
    	/// <summary>
        /// Select async
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<Industry> GetAsync(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncIndustry Begin"));
    
    		Domain.PackageBuilderModule.Entities.Industry data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryIndustry.GetAsync(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncIndustry End"));
    	
    		return Mapper.Map<Industry>(data);
    	}
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Industry> GetAll(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllIndustry Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.Industry> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryIndustry.GetAll(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllIndustry End"));
    	
    		return Mapper.Map<List<Industry>>(data);
    	}
    
    	/// <summary>
        /// Select all async
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results (task)</returns>
        public async Task<List<Industry>> GetAllAsync(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncIndustry Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.Industry> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryIndustry.GetAllAsync(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncIndustry End"));
    	
    		return Mapper.Map<List<Industry>>(data);
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Industry> FindByFilter(CustomQuery<Industry> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterIndustry Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.Industry> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Industry>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = _repositoryIndustry.AllMatching(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterIndustry End"));
    
            return Mapper.Map<List<Industry>>(data);
        }
    
    	/// <summary>
        /// Find by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results (task)</returns>
        public async Task<List<Industry>> FindByFilterAsync(CustomQuery<Industry> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncIndustry Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.Industry> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Industry>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = await _repositoryIndustry.AllMatchingAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncIndustry End"));
    
            return Mapper.Map<List<Industry>>(data);
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
        public PagedCollection<Industry> FindPagedByFilter(CustomQuery<Industry> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterIndustry Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.Industry> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Industry>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = _repositoryIndustry.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterIndustry End"));
    
            return Mapper.Map<PagedCollection<Industry>>(data);
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
        public async Task<PagedCollection<Industry>> FindPagedByFilterAsync(CustomQuery<Industry> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncIndustry Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.Industry> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Industry>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = await _repositoryIndustry.AllMatchingPagedAsync(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncIndustry End"));
    
            return Mapper.Map<PagedCollection<Industry>>(data);
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals</returns>
        public int CountFind(CustomQuery<Industry> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindIndustry Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Industry>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = _repositoryIndustry.AllMatchingCount(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindIndustry End"));
    
            return count;
        }
    
    	/// <summary>
        /// Total count by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals (task)</returns>
        public async Task<int> CountFindAsync(CustomQuery<Industry> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncIndustry Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryIndustry.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Industry>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = await _repositoryIndustry.AllMatchingCountAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncIndustry ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncIndustry End"));
    
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
            _repositoryIndustry.Dispose();
        }
    
        #endregion
    }
}
