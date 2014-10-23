
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Domain.PackageBuilderModule.IRepository;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.UnitOfWork;
using LightstoneApp.Infrastructure.Data.Core.Seedwork;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataFieldRepository : Repository<DataField>, IDataFieldRepository
    {
        #region Constructor
    
        /// <summary>
        /// Default constructor for DataFieldRepository
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork dependency</param>        
    	public DataFieldRepository(ModelUnitOfWork unitOfWork) : base(unitOfWork) { }
    
        #endregion
    }
}
