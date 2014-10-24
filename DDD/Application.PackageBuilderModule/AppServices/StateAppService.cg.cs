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
    
    public partial class StateAppService : IStateAppService
    {
    	#region Fields
        
        private readonly IStateRepository _repositoryState;
    
        #endregion
    
    	#region Constructor
    
        /// <summary>
        /// Create a new instance of State application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public StateAppService(IStateRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryState = repository;
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
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddState Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryState.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.State>(item));
    
    				committed = _repositoryState.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddState End"));
        
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Create async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
    	public async Task<bool> AddAsync(State item, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncState Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryState.Add(Mapper.Map<Domain.PackageBuilderModule.Entities.State>(item));
    
    				committed = await _repositoryState.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - AddAsyncState End"));
        
    		return committed > 0;
    	}
    
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Modify(State item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyState Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryState.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.State>(item));
    
    				committed = _repositoryState.UnitOfWork.Commit();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyState End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Update async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> ModifyAsync(State item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncState Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    		
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			var validator = EntityValidatorFactory.CreateValidator();
    			if (validator.IsValid(item))
    			{
    				// Domain Services?
    
    				_repositoryState.Modify(Mapper.Map<Domain.PackageBuilderModule.Entities.State>(item));
    
    				committed = await _repositoryState.UnitOfWork.CommitAsync();
    			}
    			else
    				throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - ModifyAsyncState End"));
    	
    		return committed > 0;
    	}
    	
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State</returns>
        public bool Remove(State item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveState Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryState.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.State>(item));
    
    			committed = _repositoryState.UnitOfWork.Commit();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveState End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Delete async
        /// </summary>
        /// <param name="item">Item</param>
    	/// <param name="session">Session</param>
    	/// <returns>State (task)</returns>
        public async Task<bool> RemoveAsync(State item, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncState Begin"));
    
    		var committed = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			if (item == null)
    				throw new ArgumentNullException("item");
    
    			// Domain Services?
    
    			_repositoryState.Remove(Mapper.Map<Domain.PackageBuilderModule.Entities.State>(item));
    
    			committed = await _repositoryState.UnitOfWork.CommitAsync();
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - RemoveAsyncState End"));
    	
    		return committed > 0;
    	}
    
    	/// <summary>
        /// Select
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity</returns>
        public State Get(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetState Begin"));
    
    		Domain.PackageBuilderModule.Entities.State data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryState.Get(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetState End"));
    	
    		return Mapper.Map<State>(data);
    	}
    
    	/// <summary>
        /// Select async
        /// </summary>
        /// <param name="keyValues">Entity key values</param>
    	/// <param name="session">Session</param>
        /// <returns>Entity (task)</returns>
        public async Task<State> GetAsync(List<object> keyValues, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncState Begin"));
    
    		Domain.PackageBuilderModule.Entities.State data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryState.GetAsync(keyValues);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAsyncState End"));
    	
    		return Mapper.Map<State>(data);
    	}
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<State> GetAll(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllState Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.State> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = _repositoryState.GetAll(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllState End"));
    	
    		return Mapper.Map<List<State>>(data);
    	}
    
    	/// <summary>
        /// Select all async
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results (task)</returns>
        public async Task<List<State>> GetAllAsync(List<string> includes, Session session = null)
    	{
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncState Begin"));
    
    		List<Domain.PackageBuilderModule.Entities.State> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
    
    			data = await _repositoryState.GetAllAsync(includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAsyncState End"));
    	
    		return Mapper.Map<List<State>>(data);
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<State> FindByFilter(CustomQuery<State> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterState Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.State> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.State>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = _repositoryState.AllMatching(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterState End"));
    
            return Mapper.Map<List<State>>(data);
        }
    
    	/// <summary>
        /// Find by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results (task)</returns>
        public async Task<List<State>> FindByFilterAsync(CustomQuery<State> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncState Begin"));
    		
    		List<Domain.PackageBuilderModule.Entities.State> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.State>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    
    			data = await _repositoryState.AllMatchingAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAsyncState End"));
    
            return Mapper.Map<List<State>>(data);
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
        public PagedCollection<State> FindPagedByFilter(CustomQuery<State> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterState Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.State> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.State>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = _repositoryState.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterState End"));
    
            return Mapper.Map<PagedCollection<State>>(data);
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
        public async Task<PagedCollection<State>> FindPagedByFilterAsync(CustomQuery<State> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncState Begin"));
    
    		PagedCollection<Domain.PackageBuilderModule.Entities.State> data = null;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.State>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    
    			data = await _repositoryState.AllMatchingPagedAsync(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAsyncState End"));
    
            return Mapper.Map<PagedCollection<State>>(data);
        }
    
        /// <summary>
        /// Total count by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals</returns>
        public int CountFind(CustomQuery<State> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindState Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.State>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = _repositoryState.AllMatchingCount(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindState End"));
    
            return count;
        }
    
    	/// <summary>
        /// Total count by filter async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>Totals (task)</returns>
        public async Task<int> CountFindAsync(CustomQuery<State> filter, List<string> includes, Session session = null)
        {
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncState Begin"));
    
    		var count = 0;
    
    		try
            {
    			if (session != null)
    				_repositoryState.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			var mapperExp = Mapper.Map<CustomQuery<Domain.PackageBuilderModule.Entities.State>>(filter).ToDomainExpression();
            
    			// Domain Services?
    		
    			count = await _repositoryState.AllMatchingCountAsync(mapperExp, includes);
    		}
    		catch (Exception ex)
            {
                LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncState ERROR"), ex);
            }  
    
            LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - CountFindAsyncState End"));
    
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
            _repositoryState.Dispose();
        }
    
        #endregion
    }
}
