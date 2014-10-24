using LightstoneApp.Application.PackageBuilderModule.AppServices;
using LightstoneApp.Domain.PackageBuilderModule.IRepository;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Adapter;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Validator;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Repository;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.UnitOfWork;
using LightstoneApp.Services.PackageBuilderModule.WcfServices;
using Microsoft.Practices.Unity;

namespace LightstoneApp.Services.PackageBuilderModule.UnityContainer
{
    using System;

    /// <summary>
    /// DI container accessor
    /// </summary>
    public partial class UnityConfig
    {
    	#region Unity Container
    
    	private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
    	{
    		var container = new Microsoft.Practices.Unity.UnityContainer();
    		ConfigureContainer(container);
    		ConfigureCustomContainer(container);
    		ConfigureFactories();
    		ConfigureCustomFactories();
    		return container;
    	});
    
    	/// <summary>
    	/// Gets the configured Unity container.
    	/// </summary>
    	public static IUnityContainer GetConfiguredContainer()
    	{
    		return Container.Value;
    	}
    
    	#endregion
    
    	#region Methods
    
    	/// <summary>
    	/// Registers the type mappings with the Unity container
    	/// </summary>
    	/// <param name="container">The unity container to configure</param>
    	private static void ConfigureContainer(IUnityContainer container)
    	{
    		//-> Unit of Work
    		container.RegisterType(typeof(ModelUnitOfWork), new PerResolveLifetimeManager());
    
    		//-> Adapters
    		container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());
    
    		#region Model -> "..\..\Domain.PackageBuilderModule.Entities\Model\Model1.edmx"
    
    		//-> Repositories
    		container.RegisterType<IDataFieldRepository, DataFieldRepository>();
    		container.RegisterType<IDataProviderRepository, DataProviderRepository>();
    		container.RegisterType<IIndustryRepository, IndustryRepository>();
    		container.RegisterType<IPackageRepository, PackageRepository>();
    		container.RegisterType<IPackageDataFieldRepository, PackageDataFieldRepository>();
    		container.RegisterType<IStateRepository, StateRepository>();
    
    		//-> Application services
    		container.RegisterType<IDataFieldAppService, DataFieldAppService>();
    		container.RegisterType<IDataProviderAppService, DataProviderAppService>();
    		container.RegisterType<IIndustryAppService, IndustryAppService>();
    		container.RegisterType<IPackageAppService, PackageAppService>();
    		container.RegisterType<IPackageDataFieldAppService, PackageDataFieldAppService>();
    		container.RegisterType<IStateAppService, StateAppService>();
    
    		//-> Distributed Services
    		container.RegisterType<IDataFieldWcfService, DataFieldWcfService>();
    		container.RegisterType<IDataProviderWcfService, DataProviderWcfService>();
    		container.RegisterType<IIndustryWcfService, IndustryWcfService>();
    		container.RegisterType<IPackageWcfService, PackageWcfService>();
    		container.RegisterType<IPackageDataFieldWcfService, PackageDataFieldWcfService>();
    		container.RegisterType<IStateWcfService, StateWcfService>();
    
    		#endregion
    	}
    
    	/// <summary>
    	/// Factories configuration
    	/// </summary>
    	private static void ConfigureFactories()
    	{
    		LoggerFactory.SetCurrent(new TraceSourceLogFactory());
    		EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
    		TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
    	}
    
    	#endregion
    }
}
