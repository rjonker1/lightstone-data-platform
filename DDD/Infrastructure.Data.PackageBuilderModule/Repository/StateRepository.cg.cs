
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Domain.PackageBuilderModule.IRepository;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.UnitOfWork;
using LightstoneApp.Infrastructure.Data.Core.Seedwork;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class StateRepository : Repository<State>, IStateRepository
    {
        #region Constructor
    
        /// <summary>
        /// Default constructor for StateRepository
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork dependency</param>        
    	public StateRepository(ModelUnitOfWork unitOfWork) : base(unitOfWork) { }
    
        #endregion
    }
}
