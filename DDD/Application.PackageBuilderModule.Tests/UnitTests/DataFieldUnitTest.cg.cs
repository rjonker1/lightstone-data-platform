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
    public partial class DataFieldUnitTest
    {
    	#region Fields
    
    	private StubDataFieldRepository _fakeRepository;
    
    	#endregion
    
        #region Methods
    
    	[TestInitialize]
        public void SetupTest()
        {
    		LoggerFactory.SetCurrent(new TraceSourceLogFactory());
    
    		_fakeRepository = new StubDataFieldRepository(new ModelUnitOfWork());
    		Mapper.CreateMap<Dtos.DataField, DataField>()
    			.ForMember(m => m.DataProvider, options => options.MapFrom(f => f.DataProvider))
    			.ForMember(m => m.Industry, options => options.MapFrom(f => f.Industry))
    			.ForMember(m => m.PackageDataFields, options => options.MapFrom(f => f.PackageDataFields));
        }
    
        [TestMethod, Timeout(5800)]
        public void AllMatchingDataFieldTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.DataField();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.DataField, DataField>(dtoCurrent);
    		_fakeRepository.AllMatchingExpressionOfFuncOfDataFieldBooleanListOfString = (expression, list) => new List<DataField> { mapDtoToEntity.Clone<DataField>() };
    
            // Act
            var entityMatch = _fakeRepository.AllMatchingExpressionOfFuncOfDataFieldBooleanListOfString(null, null).FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
    	[TestMethod, Timeout(5800)]
        public async Task AllMatchingAsyncDataFieldTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.DataField();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.DataField, DataField>(dtoCurrent);
    		var cloneEntity = mapDtoToEntity.Clone<DataField>();
            _fakeRepository.AllMatchingAsyncExpressionOfFuncOfDataFieldBooleanListOfString = (expression, list) => Task.FromResult(new List<DataField> { cloneEntity });
    
            // Act
            var entitiesMatch = await _fakeRepository.AllMatchingAsyncExpressionOfFuncOfDataFieldBooleanListOfString(null, null);
    		var entityMatch = entitiesMatch.FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
        #endregion
    }
}
