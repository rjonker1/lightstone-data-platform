using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class PreBillingCoSModule : SecureModule
    {
        public PreBillingCoSModule(IRepository<PreBilling> preBillingTransactionsRepository, IRepository<DataProviderTransaction> dataProviderTransactionsRepository)
        {
            var endDateFilter = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 25);
            var startDateFilter = new DateTime(DateTime.UtcNow.Year, (DateTime.UtcNow.Month - 1), 26);

            Get["/PreBillingCoS"] = _ =>
            {
                var preBillCoSStartDateFilter = Request.Query["startDate"];
                var preBillCoSEndDateFilter = Request.Query["endDate"];

                if (preBillCoSStartDateFilter.HasValue) startDateFilter = preBillCoSStartDateFilter;
                if (preBillCoSEndDateFilter.HasValue) endDateFilter = preBillCoSEndDateFilter;

                endDateFilter = endDateFilter.AddHours(23).AddMinutes(59).AddSeconds(59);

                var listStub = new List<PreBillingCoSDto>();

                var db = preBillingTransactionsRepository.Where(x => x.Created >= startDateFilter && x.Created <= endDateFilter);

                listStub.AddRange(db.DistinctBy(x => x.DataProvider.CostPrice).Select(x =>
                    new PreBillingCoSDto
                    {
                        DataProviderName = x.DataProvider.DataProviderName,

                        TotalTransactions = db.Count(d => d.DataProvider.DataProviderName == x.DataProvider.DataProviderName &&
                                                d.DataProvider.CostPrice == x.DataProvider.CostPrice),

                        BillableTransactions = db.Count(d => d.DataProvider.DataProviderName == x.DataProvider.DataProviderName &&
                                                d.DataProvider.CostPrice == x.DataProvider.CostPrice && x.BillingType == "BILLABLE"),

                        TotalCostOfSale = db.Where(d => d.DataProvider.DataProviderName == x.DataProvider.DataProviderName &&
                                                d.DataProvider.CostPrice == x.DataProvider.CostPrice).Sum(d => d.DataProvider.CostPrice),

                        CostOfSale = x.DataProvider.CostPrice
                    }));

                return Negotiate.WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = listStub }); ;
            };
        }
    }

    public class PreBillingCoSDto
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string DataProviderName { get; set; }
        public string AccountOwner { get; set; }
        public int TotalTransactions { get; set; }
        public int BillableTransactions { get; set; }
        public double CostOfSale { get; set; }
        public double TotalCostOfSale { get; set; }
    }
}