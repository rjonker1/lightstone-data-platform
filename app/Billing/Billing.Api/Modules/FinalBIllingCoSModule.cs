using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class FinalBillingCoSModule : SecureModule
    {
        public FinalBillingCoSModule(IRepository<FinalBilling> finalBillingTransactionsRepository)
        {
            Get["/FinalBillingCoS"] = _ =>
            {
                var preBillCoSStartDateFilter = Request.Query["startDate"];
                var preBillCoSEndDateFilter = Request.Query["endDate"];
                var listStub = new List<FinalBillingCoSDto>();

                var db = finalBillingTransactionsRepository;

                listStub.AddRange(db.Select(x =>
                    new FinalBillingCoSDto
                    {
                        DataProviderName = x.DataProvider.DataProviderName,
                    }).DistinctBy(x => x.DataProviderName));

                foreach (var dto in listStub)
                {
                    dto.TotalTransactions = db.GroupBy(x => x.DataProvider.DataProviderName).Count(x => x.Key == dto.DataProviderName);

                    dto.BillableTransactions = db.Where(x => x.BillingType == "BILLABLE" && x.DataProvider.DataProviderName == dto.DataProviderName)
                                                    .DistinctBy(x => x.UserTransaction.RequestId).Count();

                    dto.TotalCostOfSale = db.Where(x => x.BillingType == "BILLABLE" && x.DataProvider.DataProviderName == dto.DataProviderName)
                                                    .DistinctBy(x => x.UserTransaction.RequestId).Sum(x => x.DataProvider.CostPrice);

                    dto.MaxCostOfSale = db.Count(x => x.BillingType == "BILLABLE" && x.DataProvider.DataProviderName == dto.DataProviderName) > 0 ?
                                            Math.Round(db.Where(x => x.BillingType == "BILLABLE" && x.DataProvider.DataProviderName == dto.DataProviderName)
                                            .DistinctBy(x => x.UserTransaction.RequestId).Max(x => Convert.ToDouble(x.DataProvider.CostPrice)), 2) : 0;
                }

                return Negotiate.WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = listStub }); ;
            };
        }
    }

    public class FinalBillingCoSDto
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string DataProviderName { get; set; }
        public string AccountOwner { get; set; }
        public int TotalTransactions { get; set; }
        public int BillableTransactions { get; set; }
        public double MaxCostOfSale { get; set; }
        public double TotalCostOfSale { get; set; }
    }
}