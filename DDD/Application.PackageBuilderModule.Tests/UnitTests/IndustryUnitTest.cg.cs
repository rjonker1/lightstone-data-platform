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
    public partial class IndustryUnitTest
    {
    	#region Fields
    
    	private StubIndustryRepository _fakeRepository;
    
    	#endregion
    
        #region Methods
    
    	[TestInitialize]
        public void SetupTest()
        {
    		LoggerFactory.SetCurrent(new TraceSourceLogFactory());
    
    		_fakeRepository = new StubIndustryRepository(new ModelUnitOfWork());
    		Mapper.CreateMap<Dtos.Industry, Industry>()
    			.ForMember(m => m.DataFields, options => options.MapFrom(f => f.DataFields))
    			.ForMember(m => m.Packages, options => options.MapFrom(f => f.Packages));
        }
    
        [TestMethod, Timeout(5800)]
        public void AllMatchingIndustryTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.Industry();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.Industry, Industry>(dtoCurrent);
    		_fakeRepository.AllMatchingExpressionOfFuncOfIndustryBooleanListOfString = (expression, list) => new List<Industry> { mapDtoToEntity.Clone<Industry>() };
    
            // Act
            var entityMatch = _fakeRepository.AllMatchingExpressionOfFuncOfIndustryBooleanListOfString(null, null).FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
    	[TestMethod, Timeout(5800)]
        public async Task AllMatchingAsyncIndustryTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.Industry();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.Industry, Industry>(dtoCurrent);
    		var cloneEntity = mapDtoToEntity.Clone<Industry>();
            _fakeRepository.AllMatchingAsyncExpressionOfFuncOfIndustryBooleanListOfString = (expression, list) => Task.FromResult(new List<Industry> { cloneEntity });
    
            // Act
            var entitiesMatch = await _fakeRepository.AllMatchingAsyncExpressionOfFuncOfIndustryBooleanListOfString(null, null);
    		var entityMatch = entitiesMatch.FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
        #endregion
    }
}
