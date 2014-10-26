using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Presentation.Web.Mvc.Client.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LightstoneApp.Presentation.Web.Mvc.Client.Controllers.Tests
{
    [TestClass()]
    public class PackageControllerTests
    {

        [TestInitialize]
        public void SetupTest()
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());

            _fakeRepository = new StubDataProviderRepository(new ModelUnitOfWork());
            Mapper.CreateMap<Dtos.DataProvider, DataProvider>()
                .ForMember(m => m.DataFields, options => options.MapFrom(f => f.DataFields))
                .ForMember(m => m.State, options => options.MapFrom(f => f.State));
        }


        [TestMethod()]
        public void FindTest()
        {
            Assert.Fail();
        }
    }
}
