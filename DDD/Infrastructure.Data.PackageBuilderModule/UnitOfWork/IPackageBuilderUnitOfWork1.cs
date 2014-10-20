using System.Data.Entity.Core.Objects;
using DTO.PackageBuilder;
using LightstoneApp.Infrastructure.Data.Core;
using Package = LightstoneApp.Domain.PackageBuilderModule.Entities.Package;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Module.UnitOfWork
{
    
    ///<sumary>
    ///Base contract for context in Package Builder Module 
    ///</sumary>
    public interface IPackageBuilderUnitOfWork :IQueryableUnitOfWork
    {
       
        #region ObjectSet Properties
    
        IObjectSet<DataField> DataFields{get;}
        
    
        IObjectSet<DataProvider> DataProviders{get;}
        
    
        IObjectSet<Industry> Industries{get;}
        
    
        IObjectSet<Package> Packages{get;}
        
    
        IObjectSet<PackageDataField> PackageDataFields{get;}
        
    
        IObjectSet<State> States{get;}
        

        #endregion

    
    }
}
	
