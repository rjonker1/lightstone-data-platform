using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.Repository.Fakes;
using LightstoneApp.Infrastructure.Data.PackageBuilder.Module.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Application.PackageBuilderModule.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    
    [TestClass]
    public partial class DataProviderUnitTest
    {
    	#region Fields
    
    	private StubDataProviderRepository _fakeRepository;
    
    	#endregion
    
        #region Methods
    
    	[TestInitialize]
        public void SetupTest()
        {
    		LoggerFactory.SetCurrent(new TraceSourceLogFactory());
    
    		_fakeRepository = new StubDataProviderRepository(new ModelUnitOfWork());
    		Mapper.CreateMap<Dtos.DataProvider, DataProvider>()
    			.ForMember(m => m.DataFields, options => options.MapFrom(f => f.DataFields))
    			.ForMember(m => m.State, options => options.MapFrom(f => f.State));
        }
    
        [TestMethod, Timeout(5800)]
        public void AllMatchingDataProviderTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.DataProvider();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.DataProvider, DataProvider>(dtoCurrent);
    		_fakeRepository.AllMatchingExpressionOfFuncOfDataProviderBooleanListOfString = (expression, list) => new List<DataProvider> { mapDtoToEntity.Clone<DataProvider>() };
    
            // Act
            var entityMatch = _fakeRepository.AllMatchingExpressionOfFuncOfDataProviderBooleanListOfString(null, null).FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
    	[TestMethod, Timeout(5800)]
        public async Task AllMatchingAsyncDataProviderTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.DataProvider();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.DataProvider, DataProvider>(dtoCurrent);
    		var cloneEntity = mapDtoToEntity.Clone<DataProvider>();
            _fakeRepository.AllMatchingAsyncExpressionOfFuncOfDataProviderBooleanListOfString = (expression, list) => Task.FromResult(new List<DataProvider> { cloneEntity });
    
            // Act
            var entitiesMatch = await _fakeRepository.AllMatchingAsyncExpressionOfFuncOfDataProviderBooleanListOfString(null, null);
    		var entityMatch = entitiesMatch.FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
        #endregion
    }
}
