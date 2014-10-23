﻿using System;
using System.Collections.Generic;
using System.Linq;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Model;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;
using LightstoneApp.Infrastructure.Data.Core.Commits;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Infrastructure.Data.PackageBuilder.Tests
{
    [TestClass]
    public class UnitTestPackageBuilderFactory
    {
        private const string StateUnderConsructionKey = "80adc8fe-a229-4b00-a491-818dd0273b16";

        [TestMethod]
        public void TestCreatePackages()
        {
            var idNameDescTup = new List<System.Tuple<Guid, string, string, Guid>>
            {
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{3867274A-7EE2-4AE3-B897-EC55E2899DF5}"),
                    "Live VVI",
                    "Vehicle Verification Information  - This service is invoked by licence plate # or VIN # and returns the Full Vehicle Description, VIN #, Engine Number, Colour, Salvage Code status (New, Used, Rebuilt or Permanently Demolished), Police Status (e.g. Stolen, Impounded, None), Financing Entity Name. Available via web interface or web-service API. This information is useful for claims investigations to pick up possible fraudulent claims and to verify key information.",
                    Constants.IndustryKeys.Dealer),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{A01C448D-2330-4C3F-8C4C-0AB23F4BEF75}"),
                    "Live VVi+ADX",
                    "As for VVi. This variation adds the repair quote history for the vehicle."
                    , Constants.IndustryKeys.Dealer),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{04537129-CE1D-404A-8848-259549280201}"),
                    "Live VVi+ADX+VPi",
                    "As for VVi. This variation adds the repair quote history and the estimated Retail Value with a related Estimated High, Low, Confidence Score and Last 5 Sales for the same model and year of vehicle.",
                    Constants.IndustryKeys.Dealer),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{B3D98ABF-636F-4199-ABF5-F2AF8447AA3F}"),
                    "LIVE VPi",
                    "Vehicle Valuation Report – suited for policy issuance and under-writing. This service is currently invoked by a VIN # search and returns the Make, Model, Derivative, Year and Estimated Retail Value, Estimated High, Estimated Low, a Confidence Score and the last five sales related to that same Model and Year."
                    , Constants.IndustryKeys.Insurance),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{74352502-0FA0-47DE-BD73-72CF7F11FC86}"),
                    "Verification Lite VPi+",
                    "Vehicle Valuation Report This service is currently invoked by a VIN #, Licence plate search or register number search, and  returns the Make, Model, Derivative, Year and Estimated Retail Value, Estimated High, Estimated Low, a Confidence Score and the last five sales related to that same Model and "
                    , Constants.IndustryKeys.Insurance),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{F7F1DBD0-6D7C-4D82-95A4-E09710FA5BD1}"),
                    "Verification Lite WSD",
                    "Windscreen Lookup service (WSD service) – suited to windscreen replacement firms. This service is invoked by licence plate # or VIN # and returns the Make, Full Vehicle Description, VIN # as well as whether the vehicle comes with Rain Censors and Heads up Display. This is useful for glass fitment related services to ensure one is quoting on/sending out the correct glass. Available via web interface or web-service API."
                    , Constants.IndustryKeys.Insurance),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{EB0B3FAB-E371-4D19-938D-47B7AF7D4A92}"),
                    "Verification Lite VLi",
                    "Vehicle Lookup service (VLi Plus service) This is a quick lookup service invoked by VIN #. It returns the VIN, Make, Full Vehicle Description, Warranty Start Year and Quarter and Colour. This is a fast and accurate way of determining critical details of a vehicle when loading it onto a policy.  Available via web interface or web-service API."
                    , Constants.IndustryKeys.Insurance),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{802DC40E-E541-4DC8-8A38-75A6F38A7FDD}"),
                    "Verification Lite VLi+",
                    "Vehicle Lookup service (VLi Plus service) This is a quick lookup service invoked by VIN #. It returns the VIN, Make, Full Vehicle Description, Warranty Start Year and Quarter and Colour. This is a fast and accurate way of determining critical details of a vehicle when loading it onto a policy.  Available via web interface or web-service API."
                    , Constants.IndustryKeys.Insurance),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{CC5CD8BB-2D40-43D4-88FF-4A682DDF021C}"),
                    "Consumer Consumer VVi+ADX",
                    "Consumer Vehicle Verification Information  - This service is invoked by licence plate # or VIN # and returns the Full Vehicle Description, VIN #, Engine Number, Colour, Salvage Code status (New, Used, Rebuilt or Permanently Demolished), Police Status (e.g. Stolen, Impounded, None), Financed status, and repair quote history. Available via web-service API. This information is useful for consumer to verify key information about the vehicle."
                    , Constants.IndustryKeys.Consumer),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{8199E8B2-11E8-4E5A-AA7E-A33515F5E33E}"),
                    "LIVE DLi",
                    "Driver’s licence scanning - This service gives you the ability to decrypt the driver’s licence related bar-code contents that would be sent to Lightstone via web-service API on the back of a scan of that barcode using an App that you have developed. ",
                    Constants.IndustryKeys.Consumer),
                new System.Tuple<Guid, string, string, Guid>(
                    new Guid("{44716DAB-FF72-4407-9EAF-C7E4300269E9}"),
                    "LIVE EzScore",
                    "This service gives you the ability to verify a customer, and perform a basic affordability check without performing a credit enquiry.  It provides an indication of risk and financial affluence, estimating the likelihood of the customer qualifying for finance.",
                    Constants.IndustryKeys.Consumer),
            };

            var recordDate = DateTime.Parse("21 Oct 2014");

            var createdPackages = new List<Package>();

            foreach (var tuple in idNameDescTup)
            {
                var packageFactory = new Package.Factory();

                var packageToCreate = new Package
                {
                    EntityState = TrackState.Added,
                    Id = tuple.Item1,
                    Name = tuple.Item2,
                    Description = tuple.Item3,
                    Version = "0.0.0.1",
                    Owner = "Lightstone Auto",
                    Published = false,
                    StateId = new Guid(StateUnderConsructionKey),
                    IndustryId = tuple.Item4,
                    Created = DateTime.Parse("21 Oct 2014"),
                    CostOfSale = 0,
                    Edited = recordDate,
                    RecomendedRetailPrice = 0,
                    RevisionDate = recordDate
                };

                // cleanup 

                var db = new LightstoneAppDatabaseEntities();

                var packageToDelegte =
                    db.Packages.SingleOrDefault(
                        x => x.Version == packageToCreate.Version && x.Name == packageToCreate.Name);

                if (packageToDelegte != null)
                {
                    db.Packages.Remove(packageToDelegte);
                    db.SaveChanges();
                }

                // execute
                var createdPackage = packageFactory.CreatePackage(packageToCreate);

               if (createdPackage != null)
                    createdPackages.Add(createdPackage);


            }

            
            var commitFactory = new Commit.Factory();
            var transactionIdentifier = GuidUtil.NewSequentialId();
            var correlationId = "Seed_Packages/" + transactionIdentifier;
            var commit = commitFactory.CreateFor(transactionIdentifier, correlationId, createdPackages[0], "Wayne");


            //Assert;
            var packageCount = createdPackages.Count;
            Assert.IsTrue(packageCount == idNameDescTup.Count);
        }
    }
}