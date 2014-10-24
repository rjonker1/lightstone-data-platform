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
    
    public partial class PackageDataFieldAppService : IPackageDataFieldAppService
    {
    	#region Fields
        
        private readonly IPackageDataFieldRepository _repositoryPackageDataField;
    
        #endregion
    
    	#region Constructor
    
        /// <summary>
        /// Create a new instance of PackageDataField application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public PackageDataFieldAppService(IPackageDataFieldRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryPackageDataField = repository;
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
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddPackageDataField Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryPackageDataField.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.PackageDataField>(item));
    
    				committed = _repositoryPackageDataField.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddPackageDataField End"));
        
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Create async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
    	public async Task<bool> AddAsync(PackageDataField item, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncPackageDataField Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryPackageDataField.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.PackageDataField>(item));
    
    				committed = await _repositoryPackageDataField.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncPackageDataField End"));
        
    		return committed > 0;
    	}
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(PackageDataField item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyPackageDataField Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryPackageDataField.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.PackageDataField>(item));
    
    				committed = _repositoryPackageDataField.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyPackageDataField End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Update async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsync(PackageDataField item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncPackageDataField Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryPackageDataField.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.PackageDataField>(item));
    
    				committed = await _repositoryPackageDataField.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncPackageDataField End"));
    	
    		return committed > 0;
    	}
    	
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(PackageDataField item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemovePackageDataField Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryPackageDataField.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.PackageDataField>(item));
    
    			committed = _repositoryPackageDataField.UnitOfWork.Commit();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemovePackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemovePackageDataField End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Delete async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsync(PackageDataField item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncPackageDataField Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryPackageDataField.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.PackageDataField>(item));
    
    			committed = await _repositoryPackageDataField.UnitOfWork.CommitAsync();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncPackageDataField End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public PackageDataField Get(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetPackageDataField Begin"));
    
    		Domain.PackageBuilderModule.Entities.PackageDataField data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryPackageDataField.Get(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetPackageDataField End"));
    	
    		return Mapper.Map<PackageDataField>(data);
    	}
    
    	/// <summary>
        /// Select async
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<PackageDataField> GetAsync(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncPackageDataField Begin"));
    
    		Domain.PackageBuilderModule.Entities.PackageDataField data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryPackageDataField.GetAsync(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncPackageDataField End"));
    	
    		return Mapper.Map<PackageDataField>(data);
    	}
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<PackageDataField> GetAll(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPackageDataField Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.PackageDataField> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryPackageDataField.GetAll(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPackageDataField End"));
    	
    		return Mapper.Map<List<PackageDataField>>(data);
    	}
    
    	/// <summary>
        /// Select all async
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results (task)</returns>
        public async Task<List<PackageDataField>> GetAllAsync(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncPackageDataField Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.PackageDataField> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryPackageDataField.GetAllAsync(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncPackageDataField End"));
    	
    		return Mapper.Map<List<PackageDataField>>(data);
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<PackageDataField> FindByFilter(CustomQuery<PackageDataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPackageDataField Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.PackageDataField> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = _repositoryPackageDataField.AllMatching(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPackageDataField End"));
    
            return Mapper.Map<List<PackageDataField>>(data);
        }
    
    	/// <summary>
        /// Find by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results (task)</returns>
        public async Task<List<PackageDataField>> FindByFilterAsync(CustomQuery<PackageDataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncPackageDataField Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.PackageDataField> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = await _repositoryPackageDataField.AllMatchingAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncPackageDataField End"));
    
            return Mapper.Map<List<PackageDataField>>(data);
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
        public PagedCollection<PackageDataField> FindPagedByFilter(CustomQuery<PackageDataField> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPackageDataField Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.PackageDataField> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = _repositoryPackageDataField.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPackageDataField End"));
    
            return Mapper.Map<PagedCollection<PackageDataField>>(data);
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
        public async Task<PagedCollection<PackageDataField>> FindPagedByFilterAsync(CustomQuery<PackageDataField> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncPackageDataField Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.PackageDataField> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = await _repositoryPackageDataField.AllMatchingPagedAsync(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncPackageDataField End"));
    
            return Mapper.Map<PagedCollection<PackageDataField>>(data);
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals</returns>
        public int CountFind(CustomQuery<PackageDataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindPackageDataField Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = _repositoryPackageDataField.AllMatchingCount(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindPackageDataField End"));
    
            return count;
        }
    
    	/// <summary>
        /// Total count by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals (task)</returns>
        public async Task<int> CountFindAsync(CustomQuery<PackageDataField> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncPackageDataField Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryPackageDataField.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.PackageDataField>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = await _repositoryPackageDataField.AllMatchingCountAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncPackageDataField ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncPackageDataField End"));
    
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
            _repositoryPackageDataField.Dispose();
        }
    
        #endregion
    }
}
