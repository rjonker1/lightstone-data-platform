
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Domain.PackageBuilderModule.IRepository;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.UnitOfWork;
using LightstoneApp.Infrastructure.Data.Core.Seedwork;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class IndustryRepository : Repository<Industry>, IIndustryRepository
    {
        #region Constructor
    
        /// <summary>
        /// Default constructor for IndustryRepository
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork dependency</param>        
    	public IndustryRepository(ModelUnitOfWork unitOfWork) : base(unitOfWork) { }
    
        #endregion
    }
}
