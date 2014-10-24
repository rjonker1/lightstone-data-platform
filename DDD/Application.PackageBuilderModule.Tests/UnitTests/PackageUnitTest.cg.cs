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
    public partial class PackageUnitTest
    {
    	#region Fields
    
    	private StubPackageRepository _fakeRepository;
    
    	#endregion
    
        #region Methods
    
    	[TestInitialize]
        public void SetupTest()
        {
    		LoggerFactory.SetCurrent(new TraceSourceLogFactory());
    
    		_fakeRepository = new StubPackageRepository(new ModelUnitOfWork());
    		Mapper.CreateMap<Dtos.Package, Package>()
    			.ForMember(m => m.Industry, options => options.MapFrom(f => f.Industry))
    			.ForMember(m => m.State, options => options.MapFrom(f => f.State))
    			.ForMember(m => m.PackageDataFields, options => options.MapFrom(f => f.PackageDataFields));
        }
    
        [TestMethod, Timeout(5800)]
        public void AllMatchingPackageTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.Package();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.Package, Package>(dtoCurrent);
    		_fakeRepository.AllMatchingExpressionOfFuncOfPackageBooleanListOfString = (expression, list) => new List<Package> { mapDtoToEntity.Clone<Package>() };
    
            // Act
            var entityMatch = _fakeRepository.AllMatchingExpressionOfFuncOfPackageBooleanListOfString(null, null).FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
    	[TestMethod, Timeout(5800)]
        public async Task AllMatchingAsyncPackageTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.Package();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.Package, Package>(dtoCurrent);
    		var cloneEntity = mapDtoToEntity.Clone<Package>();
            _fakeRepository.AllMatchingAsyncExpressionOfFuncOfPackageBooleanListOfString = (expression, list) => Task.FromResult(new List<Package> { cloneEntity });
    
            // Act
            var entitiesMatch = await _fakeRepository.AllMatchingAsyncExpressionOfFuncOfPackageBooleanListOfString(null, null);
    		var entityMatch = entitiesMatch.FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
        #endregion
    }
}
