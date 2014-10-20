using System;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Data.PackageBuilder.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //var packageBuilderContext = new LightstoneApp.Domain.PackageBuilderModule.Entities.Model.Context();

            

                
                const string vviDes = "Vehicle Verification Information  - This service is invoked by licence plate # or VIN # and returns the Full Vehicle Description, VIN #, Engine Number, Colour, Salvage Code status (New, Used, Rebuilt or Permanently Demolished), Police Status (e.g. Stolen, Impounded, None), Financing Entity Name. Available via web interface or web-service API. This information is useful for claims investigations to pick up possible fraudulent claims and to verify key information.";

            //    var stateUnderConstruction = packageBuilderContext.CreateState("Under construction");


                //var packageToCreate = packageBuilderContext.CreatePackage("LIVE VVi", vviDes, "0.0.0.1", stateUnderConstruction);

            //   // packageBuilderContext.SaveChanges();


            //var package =
            //    new LightstoneApp.Domain.PackageBuilderModule.Entities.Package(packageBuilderContext);

            var packageFactory = new Package.Factory();

            var packageToCreate = new Package()
            {
                Name = "Live VVI",
                IndustryId = new Guid("a5f908f8-f645-4c94-93f5-fedbc9781f8c"),
                Description = vviDes,
                Version = "0.0.0.1",
                StateId = new Guid("80adc8fe-a229-4b00-a491-818dd0273b16")
            };




            packageFactory.CreatePackage(packageToCreate);

            //var p = packageFactory.CreatePackage("LIVE VVi",vviDes, "0.0.0.1");




















        }
    }
}