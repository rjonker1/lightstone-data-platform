using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Repository;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading.Tasks;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    
    [TestClass]
    public partial class DataProviderUnitTest
    {
    	#region Fields
    
    	private DataProviderRepository _repository;
    
    	#endregion
    	
    	#region Methods
    
    	[TestInitialize]
    	public void SetupTest()
    	{	
    		LoggerFactory.SetCurrent(new TraceSourceLogFactory());
    		_repository = new DataProviderRepository(new ModelUnitOfWork());
    	}
    
    	[TestMethod, Timeout(5800)]
    	public void CountFindDataProviderTest()
    	{
    		// Act
    		var count = _repository.AllMatchingCount();
    
    		// Assert
    		Assert.IsNotNull(count);
    		Assert.IsTrue(count != -1);
    	}
    
    	[TestMethod, Timeout(5800)]
    	public async Task CountFindAsyncDataProviderTest()
    	{
    		// Act
    		var result = await _repository.AllMatchingCountAsync();
    
    		// Assert
    		Assert.IsNotNull(result);
    		Assert.IsTrue(result != -1);
    	}
    
    	#endregion
    }
}
