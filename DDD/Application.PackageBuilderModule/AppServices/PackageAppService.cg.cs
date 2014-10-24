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
    
    public partial class PackageAppService : IPackageAppService
    {
    	#region Fields
        
        private readonly IPackageRepository _repositoryPackage;
    
        #endregion
    
    	#region Constructor
    
        /// <summary>
        /// Create a new instance of Package application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public PackageAppService(IPackageRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryPackage = repository;
        }
    
    	#endregion
    
    	#region Public Methods
    
    	/// <summary>
        /// Create
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
    	public bool Add(Package item, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddPackage Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryPackage.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.Package>(item));
    
    				committed = _repositoryPackage.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddPackage End"));
        
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Create async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
    	public async Task<bool> AddAsync(Package item, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncPackage Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryPackage.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.Package>(item));
    
    				committed = await _repositoryPackage.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncPackage End"));
        
    		return committed > 0;
    	}
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(Package item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyPackage Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryPackage.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.Package>(item));
    
    				committed = _repositoryPackage.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyPackage End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Update async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsync(Package item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncPackage Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryPackage.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.Package>(item));
    
    				committed = await _repositoryPackage.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncPackage End"));
    	
    		return committed > 0;
    	}
    	
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(Package item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemovePackage Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryPackage.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.Package>(item));
    
    			committed = _repositoryPackage.UnitOfWork.Commit();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemovePackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemovePackage End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Delete async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsync(Package item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncPackage Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryPackage.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.Package>(item));
    
    			committed = await _repositoryPackage.UnitOfWork.CommitAsync();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncPackage End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public Package Get(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetPackage Begin"));
    
    		Domain.PackageBuilderModule.Entities.Package data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryPackage.Get(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetPackage End"));
    	
    		return Mapper.Map<Package>(data);
    	}
    
    	/// <summary>
        /// Select async
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<Package> GetAsync(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncPackage Begin"));
    
    		Domain.PackageBuilderModule.Entities.Package data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryPackage.GetAsync(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncPackage End"));
    	
    		return Mapper.Map<Package>(data);
    	}
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Package> GetAll(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPackage Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.Package> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryPackage.GetAll(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPackage End"));
    	
    		return Mapper.Map<List<Package>>(data);
    	}
    
    	/// <summary>
        /// Select all async
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results (task)</returns>
        public async Task<List<Package>> GetAllAsync(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncPackage Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.Package> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryPackage.GetAllAsync(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncPackage End"));
    	
    		return Mapper.Map<List<Package>>(data);
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Package> FindByFilter(CustomQuery<Package> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPackage Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.Package> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Package>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = _repositoryPackage.AllMatching(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPackage End"));
    
            return Mapper.Map<List<Package>>(data);
        }
    
    	/// <summary>
        /// Find by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results (task)</returns>
        public async Task<List<Package>> FindByFilterAsync(CustomQuery<Package> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncPackage Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.Package> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Package>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = await _repositoryPackage.AllMatchingAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncPackage End"));
    
            return Mapper.Map<List<Package>>(data);
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
        public PagedCollection<Package> FindPagedByFilter(CustomQuery<Package> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPackage Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.Package> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Package>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = _repositoryPackage.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPackage End"));
    
            return Mapper.Map<PagedCollection<Package>>(data);
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
        public async Task<PagedCollection<Package>> FindPagedByFilterAsync(CustomQuery<Package> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncPackage Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.Package> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Package>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = await _repositoryPackage.AllMatchingPagedAsync(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncPackage End"));
    
            return Mapper.Map<PagedCollection<Package>>(data);
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals</returns>
        public int CountFind(CustomQuery<Package> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindPackage Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Package>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = _repositoryPackage.AllMatchingCount(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindPackage End"));
    
            return count;
        }
    
    	/// <summary>
        /// Total count by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals (task)</returns>
        public async Task<int> CountFindAsync(CustomQuery<Package> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncPackage Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackage.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.Package>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = await _repositoryPackage.AllMatchingCountAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncPackage ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncPackage End"));
    
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
            _repositoryPackage.Dispose();
        }
    
        #endregion
    }
}
