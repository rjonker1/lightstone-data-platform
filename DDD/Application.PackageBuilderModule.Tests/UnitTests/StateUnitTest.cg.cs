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
    public partial class StateUnitTest
    {
    	#region Fields
    
    	private StubStateRepository _fakeRepository;
    
    	#endregion
    
        #region Methods
    
    	[TestInitialize]
        public void SetupTest()
        {
    		LoggerFactory.SetCurrent(new TraceSourceLogFactory());
    
    		_fakeRepository = new StubStateRepository(new ModelUnitOfWork());
    		Mapper.CreateMap<Dtos.State, State>()
    			.ForMember(m => m.DataProviders, options => options.MapFrom(f => f.DataProviders))
    			.ForMember(m => m.Packages, options => options.MapFrom(f => f.Packages));
        }
    
        [TestMethod, Timeout(5800)]
        public void AllMatchingStateTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.State();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.State, State>(dtoCurrent);
    		_fakeRepository.AllMatchingExpressionOfFuncOfStateBooleanListOfString = (expression, list) => new List<State> { mapDtoToEntity.Clone<State>() };
    
            // Act
            var entityMatch = _fakeRepository.AllMatchingExpressionOfFuncOfStateBooleanListOfString(null, null).FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
    	[TestMethod, Timeout(5800)]
        public async Task AllMatchingAsyncStateTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.State();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.State, State>(dtoCurrent);
    		var cloneEntity = mapDtoToEntity.Clone<State>();
            _fakeRepository.AllMatchingAsyncExpressionOfFuncOfStateBooleanListOfString = (expression, list) => Task.FromResult(new List<State> { cloneEntity });
    
            // Act
            var entitiesMatch = await _fakeRepository.AllMatchingAsyncExpressionOfFuncOfStateBooleanListOfString(null, null);
    		var entityMatch = entitiesMatch.FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
        #endregion
    }
}
