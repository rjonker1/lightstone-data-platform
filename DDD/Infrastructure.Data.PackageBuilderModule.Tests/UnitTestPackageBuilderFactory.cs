using System;
using System.Linq;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Model;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Data.PackageBuilder.Tests
{
    [TestClass]
    public class UnitTestPackageBuilderFactory
    {

        public const string StateUnderConsructionKey = "80adc8fe-a229-4b00-a491-818dd0273b16";
        public const string IndustryOtherKey = "a5f908f8-f645-4c94-93f5-fedbc9781f8c";

        [TestMethod]
        public void TestCreatePackage()
        {
            const string vviDes = "Vehicle Verification Information  - This service is invoked by licence plate # or VIN # and returns the Full Vehicle Description, VIN #, Engine Number, Colour, Salvage Code status (New, Used, Rebuilt or Permanently Demolished), Police Status (e.g. Stolen, Impounded, None), Financing Entity Name. Available via web interface or web-service API. This information is useful for claims investigations to pick up possible fraudulent claims and to verify key information.";
            Assert.IsTrue(vviDes.Length < 512);

            var packageFactory = new Package.Factory();

            var packageToCreate = new Package
            {
                Id = GuidUtil.NewSequentialId(),
                Name = "Live VVI",
                
                Description = vviDes,
                Version = "0.0.0.1",
                Owner = "Wayne",
                Published = false,
                StateId = new Guid(StateUnderConsructionKey),
                IndustryId = new Guid(IndustryOtherKey),
                Created = DateTime.Now
            };

            // cleanup 

            using (var db = new LightstoneAppDatabaseEntities())
            {
                var packageTODelegte =
                    db.Packages.SingleOrDefault(
                        x => x.Version == packageToCreate.Version && x.Name == packageToCreate.Name);

                if (packageTODelegte != null)
                {
                    db.Packages.Remove(packageTODelegte);
                    db.SaveChanges();
                }
            }

            packageFactory.CreatePackage(packageToCreate);

        }
    }
}