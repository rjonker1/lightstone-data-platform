using System;
using System.Collections.Generic;
using System.Linq;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Repositories;
using Nancy;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Entities;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Billing.Api.Modules
{
    public class ReportModule : NancyModule
    {
        public ReportModule(IRepository<StageBilling> stageBillingRepository, IReportApiClient reportApiClient)
        {
            Get["/Reports/Customer/Transactions/{searchId}"] = parameters =>
            {
                var searchId = (Guid) parameters.searchId;
                var packagesDetailList = new List<PackageDto>();

                var transactions = stageBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId);

                foreach (var transaction in transactions)
                {
                    // Return Pacakge details without price, if non-billable
                    if (transactions.Count(x => x.IsBillable).Equals(0))
                    {
                        var emptyPackage = new PackageDto
                        {
                            PackageId = transaction.PackageId,
                            PackageName = transaction.PackageName,
                            PackageCostPrice = 0.00,
                            PackageRecommendedPrice = 0.00
                        };

                        // Package Index
                        var emptyPackageIndex = packagesDetailList.FindIndex(x => x.PackageId == emptyPackage.PackageId);

                        //Index restriction for new record
                        if (emptyPackageIndex < 0) packagesDetailList.Add(emptyPackage);
                        break;
                    }

                    // Package
                    var package = new PackageDto
                    {
                        PackageId = transaction.PackageId,
                        PackageName = transaction.PackageName,
                        PackageCostPrice = transaction.PackageCostPrice,
                        PackageRecommendedPrice = transaction.PackageRecommendedPrice
                    };

                    // Package Index
                    var packageIndex = packagesDetailList.FindIndex(x => x.PackageId == package.PackageId);

                    // Index restriction for new record
                    if (packageIndex < 0) packagesDetailList.Add(package);

                }

                var packagesList = stageBillingRepository.Where(x => x.CustomerId == searchId)
                            .Select(x => new ReportPackage
                            {
                                ItemCode = x.PackageName,
                                ItemDescription = x.PackageName,
                                Price = x.PackageRecommendedPrice,
                                //Vat = 2284
                            }).Distinct();

                var reportData = new ReportDto
                {
                    Template = new ReportTemplate { ShortId = "N190datG" },
                    Data = new ReportData
                    {
                        Customer = new ReportCustomer
                        {
                            Name = "TEST",
                            TaxRegistration = 4190195679,
                            Packages = packagesList.ToList()
                        }
                    }
                };

                var token = Context.AuthorizationHeaderToken();
                var htmlReport = reportApiClient.Post("", "/ReportHTML", reportData,
                    new[]
                        {
                            new KeyValuePair<string, string>("Authorization", "Token " + token),
                            new KeyValuePair<string, string>("Content-Type", "application/json"),
                        });

                //return Response.AsJson(new { data = packagesDetailList });
                return null;
            };
        }
    }
}