using System.Data.Entity.Core.Objects;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Infrastructure.Data.Core;

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
	
