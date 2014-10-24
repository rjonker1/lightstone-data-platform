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
    public partial class PackageDataFieldUnitTest
    {
    	#region Fields
    
    	private StubPackageDataFieldRepository _fakeRepository;
    
    	#endregion
    
        #region Methods
    
    	[TestInitialize]
        public void SetupTest()
        {
    		LoggerFactory.SetCurrent(new TraceSourceLogFactory());
    
    		_fakeRepository = new StubPackageDataFieldRepository(new ModelUnitOfWork());
    		Mapper.CreateMap<Dtos.PackageDataField, PackageDataField>()
    			.ForMember(m => m.DataField, options => options.MapFrom(f => f.DataField))
    			.ForMember(m => m.Package, options => options.MapFrom(f => f.Package));
        }
    
        [TestMethod, Timeout(5800)]
        public void AllMatchingPackageDataFieldTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.PackageDataField();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.PackageDataField, PackageDataField>(dtoCurrent);
    		_fakeRepository.AllMatchingExpressionOfFuncOfPackageDataFieldBooleanListOfString = (expression, list) => new List<PackageDataField> { mapDtoToEntity.Clone<PackageDataField>() };
    
            // Act
            var entityMatch = _fakeRepository.AllMatchingExpressionOfFuncOfPackageDataFieldBooleanListOfString(null, null).FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
    	[TestMethod, Timeout(5800)]
        public async Task AllMatchingAsyncPackageDataFieldTest()
        {
    		// Arrange
            var dtoCurrent = new Dtos.PackageDataField();
    		dtoCurrent.GenerateNewIdentity();
            var mapDtoToEntity = Mapper.Map<Dtos.PackageDataField, PackageDataField>(dtoCurrent);
    		var cloneEntity = mapDtoToEntity.Clone<PackageDataField>();
            _fakeRepository.AllMatchingAsyncExpressionOfFuncOfPackageDataFieldBooleanListOfString = (expression, list) => Task.FromResult(new List<PackageDataField> { cloneEntity });
    
            // Act
            var entitiesMatch = await _fakeRepository.AllMatchingAsyncExpressionOfFuncOfPackageDataFieldBooleanListOfString(null, null);
    		var entityMatch = entitiesMatch.FirstOrDefault();
    
            // Assert
            Assert.IsNotNull(entityMatch);
            Assert.AreEqual(dtoCurrent.Id, entityMatch.Id);
        }
    
        #endregion
    }
}
