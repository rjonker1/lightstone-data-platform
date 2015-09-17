using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses;
using Nancy.Responses.Negotiation;
using Nancy.Security;
using ServiceStack.Text;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;
using PreBillingDto = Billing.Domain.Dtos.PreBillingDto;

namespace Billing.Api.Modules
{
    public class PreBillingModule : SecureModule
    {
        private readonly IRepository<PreBilling> _preBillingDBRepository;
        private IList<PreBilling> _preBillingRepository;

        public PreBillingModule(IRepository<PreBilling> preBillingDBRepository, 
                                IRepository<UserMeta> userMetaRepository, ICacheProvider<PreBilling> preBillingCacheProvider,
                                IReportApiClient reportApiClient)
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            _preBillingDBRepository = preBillingDBRepository;
            _preBillingRepository = preBillingCacheProvider.CacheClient.GetAll();

            var endDateFilter = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 25);
            var startDateFilter = new DateTime(DateTime.UtcNow.Year, (DateTime.UtcNow.Month - 1), 26);

            Before += async (ctx, ct) =>
            {
                this.Info(() => "Before Hook - PreBilling");
                await CheckCache(ct);
                return null;
            };

            After += async (ctx, ct) => this.Info(() => "After Hook - PreBilling");

            Get["/PreBilling/"] = _ =>
            {
                var preBillStartDateFilter = Request.Query["startDate"];
                var preBillEndDateFilter = Request.Query["endDate"];

                if (preBillStartDateFilter.HasValue) endDateFilter = preBillStartDateFilter;
                if (preBillEndDateFilter.HasValue) startDateFilter = preBillEndDateFilter;

                endDateFilter = endDateFilter.AddHours(23).AddMinutes(59).AddSeconds(59);

                var customerClientList = new List<PreBillingDto>();

                foreach (var transaction in _preBillingRepository)
                {
                    var customerClient = new PreBillingDto();
                    var userList = new List<User>();

                    var customerTransactions = _preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId
                                                                            && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                    var customerPackages = customerTransactions.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.Package.PackageId).Distinct().Count();


                    var clientTransactions = _preBillingRepository.Where(x => x.ClientId == transaction.ClientId
                                                                            && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                    var clientPackagesTotal = clientTransactions.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.Package.PackageId).Distinct().Count();

                    // Customer
                    if (transaction.ClientId == new Guid())
                    {
                        customerClient = new PreBillingDto
                        {
                            Id = transaction.CustomerId,
                            CustomerName = transaction.CustomerName,
                            Transactions = customerTransactions.Count(),
                            Products = customerPackages
                        };
                    }

                    // Client
                    if (transaction.CustomerId == new Guid())
                    {
                        customerClient = new PreBillingDto
                        {
                            Id = transaction.ClientId,
                            CustomerName = transaction.ClientName,
                            Transactions = clientTransactions.Count(),
                            Products = clientPackagesTotal
                        };
                    }

                   if ((transaction.ClientId == new Guid()) && (transaction.CustomerId == new Guid())) continue;

                    // User
                    var user = new User
                    {
                        UserId = transaction.User.UserId,
                        Username = transaction.User.Username,
                        HasTransactions = true
                    };

                    // Indices
                    var userIndex = userList.FindIndex(x => x.UserId == user.UserId);
                    var customerClientIndex = customerClientList.FindIndex(x => x.Id == customerClient.Id);


                    // Index restrictions for new records
                    if (userIndex < 0) userList.Add(user);

                    customerClient.Users = userList;

                    if (customerClientIndex < 0) customerClientList.Add(customerClient);
                }

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customerClientList });
            };


            Get["/PreBilling/CustomerClient/{searchId}/Users"] = param =>
            {
                var preBillStartDateFilter = Request.Query["startDate"];
                var preBillEndDateFilter = Request.Query["endDate"];

                if (preBillStartDateFilter.HasValue) endDateFilter = preBillStartDateFilter;
                if (preBillEndDateFilter.HasValue) startDateFilter = preBillEndDateFilter;

                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                var preBillingRepo = _preBillingRepository.Where(x => (x.CustomerId == searchId || x.ClientId == searchId)
                                                                    && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                foreach (var transaction in preBillingRepo)
                {
                    var userTransactionsList = new List<TransactionDto>();

                    var userMeta = userMetaRepository.FirstOrDefault(x => x.Id == transaction.User.UserId) ?? new UserMeta
                    {
                        Id = transaction.User.UserId,
                        Username = transaction.User.Username
                    };

                    // Filter repo for user transaction;
                    var userTransactions = preBillingRepo.Where(x => x.User.UserId == transaction.User.UserId)
                                            .Select(x =>
                                            new TransactionDto
                                            {
                                                TransactionId = x.UserTransaction.TransactionId,
                                                RequestId = x.UserTransaction.RequestId,
                                                IsBillable = x.UserTransaction.IsBillable
                                            }).Distinct();

                    foreach (var userTransaction in userTransactions)
                    {
                        var userTransIndex = userTransactionsList.FindIndex(x => x.TransactionId == userTransaction.TransactionId);
                        if (userTransIndex < 0) userTransactionsList.Add(userTransaction);
                    }

                    var user = Mapper.Map<PreBilling, UserDto>(transaction);
                    Mapper.Map(userMeta, user);
                    user.Transactions = userTransactionsList;

                    var userIndex = customerUsersDetailList.FindIndex(x => x.UserId == user.UserId);
                    if (userIndex < 0) customerUsersDetailList.Add(user);
                }

                return Response.AsJson(new { data = customerUsersDetailList });
            };


            Get["/PreBilling/CustomerClient/{searchId}/Packages"] = param =>
            {
                var preBillStartDateFilter = Request.Query["startDate"];
                var preBillEndDateFilter = Request.Query["endDate"];

                if (preBillStartDateFilter.HasValue) endDateFilter = preBillStartDateFilter;
                if (preBillEndDateFilter.HasValue) startDateFilter = preBillEndDateFilter;

                var searchId = new Guid(param.searchId);
                var customerPackagesDetailList = new List<PackageDto>();

                var preBillingRepo = _preBillingRepository.Where(x => (x.CustomerId == searchId || x.ClientId == searchId)
                                                                    && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                foreach (var transaction in preBillingRepo)
                {
                    var packageTransactions = preBillingRepo.Where(x => x.Package.PackageId == transaction.Package.PackageId).Distinct();

                    var package = Mapper.Map<Package, PackageDto>(transaction.Package);
                    package.PackageTransactions = packageTransactions.Count();

                    var packageIndex = customerPackagesDetailList.FindIndex(x => x.PackageId == package.PackageId);
                    if (packageIndex < 0) customerPackagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = customerPackagesDetailList });
            };

            Get["/PreBillingDump"] = _ =>
            {
                var preBillStartDateFilter = Request.Query["startDate"];
                var preBillEndDateFilter = Request.Query["endDate"];

                if (preBillStartDateFilter.HasValue) endDateFilter = preBillStartDateFilter;
                if (preBillEndDateFilter.HasValue) startDateFilter = preBillEndDateFilter;

                var preBilling = _preBillingRepository.Where(x => x.Created >= startDateFilter && x.Created <= endDateFilter);

                var report = new ReportDto
                {
                    Template = new ReportTemplate { ShortId = "418Ky2Cj" },
                    Data = new ReportData
                    {
                        PreBillingData = Mapper.Map<IEnumerable<PreBilling>, IEnumerable<PreBillingRecord>>(preBilling)
                    }
                };

                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                reportApiClient.Post(token, "/PreBillingReportDownload?startDate=" + startDateFilter + "&endDate="+ endDateFilter, null, report, null);


                var file = new FileStream(@"D:\LSA Reports\PreBilling " + startDateFilter.ToString("MMMM dd yyyy") + " - " + endDateFilter.ToString("MMMM dd yyyy") + ".xlsx", FileMode.Open);
                string fileName = "PreBilling_" + startDateFilter.ToString("MMMM-dd-yyyy") + "_" + endDateFilter.ToString("MMMM-dd-yyyy") + ".xlsx";

                var response = new StreamResponse(() => file, MimeTypes.GetMimeType(fileName));

                response.WithCookie("fileDownload", "true", DateTime.UtcNow.AddSeconds(10), "", "/");

                return response.AsAttachment(fileName);
            };

        }

        private async Task CheckCache(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            this.Info(() => "Checking PreBilling Cache");

            if (_preBillingRepository.Count <= 0)
            {
                this.Info(() => "No PreBilling records in cache. Switching to PreBilling DB Repository");
                _preBillingRepository = _preBillingDBRepository.ToList();
            }
            else
            {
                this.Info(() => "PreBilling Cache loaded");
            }
        }
    }

}