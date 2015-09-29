using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses.Negotiation;
using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;

namespace Billing.Api.Modules
{
    public class FinalBillingModule : SecureModule
    {
        private readonly IRepository<FinalBilling> _finalBillingDBRepository;
        private IList<FinalBilling> finalBillingRepository;

        public FinalBillingModule(IRepository<FinalBilling> finalBillingDBRepository, IRepository<UserMeta> userMetaRepository, IRepository<AccountMeta> accountMetaRepository,
                                    ICacheProvider<FinalBilling> finalBillingCacheProvider)
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            _finalBillingDBRepository = finalBillingDBRepository;
            finalBillingRepository = finalBillingCacheProvider.CacheClient.GetAll();

            var endDateFilter = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 25);
            var startDateFilter = new DateTime(DateTime.UtcNow.Year, (DateTime.UtcNow.Month - 1), 26);

            Before += async (ctx, ct) =>
            {
                this.Info(() => "Before Hook - FinalBilling");
                await CheckCache(ct);
                return null;
            };

            After += async (ctx, ct) => this.Info(() => "After Hook - FinalBilling");

            Get["/FinalBilling/"] = _ =>
            {
                var finalBillingStartDateFilter = Request.Query["startDate"];
                var finalBillingEndDateFilter = Request.Query["endDate"];

                if (finalBillingStartDateFilter.HasValue) endDateFilter = finalBillingStartDateFilter;
                if (finalBillingEndDateFilter.HasValue) startDateFilter = finalBillingEndDateFilter;

                endDateFilter = endDateFilter.AddHours(23).AddMinutes(59).AddSeconds(59);

                var customerClientList = new List<FinalBillingDto>();

                foreach (var transaction in finalBillingRepository)
                {
                    var customerClient = new FinalBillingDto();
                    var userList = new List<User>();

                    var customerTransactions = finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId
                                                                            && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                    var customerPackages = customerTransactions.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.Package.PackageId).Distinct().Count();


                    var clientTransactions = finalBillingRepository.Where(x => x.ClientId == transaction.ClientId).DistinctBy(x => x.UserTransaction.TransactionId);

                    var clientPackagesTotal = clientTransactions.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.Package.PackageId).Distinct().Count();

                    // Customer
                    if (transaction.ClientId == new Guid())
                    {
                        customerClient = new FinalBillingDto
                        {
                            Id = transaction.CustomerId,
                            CustomerName = transaction.CustomerName,
                            Transactions = customerTransactions.Count(),
                            Products = customerPackages,
                            AccountMeta = accountMetaRepository.FirstOrDefault(x => x.AccountNumber == transaction.AccountNumber)
                        };
                    }

                    // Client
                    if (transaction.CustomerId == new Guid())
                    {
                        customerClient = new FinalBillingDto
                        {
                            Id = transaction.ClientId,
                            CustomerName = transaction.ClientName,
                            Transactions = clientTransactions.Count(),
                            Products = clientPackagesTotal,
                            AccountMeta = accountMetaRepository.FirstOrDefault(x => x.AccountNumber == transaction.AccountNumber)
                        };
                    }

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


            Get["/FinalBilling/CustomerClient/{searchId}/Users"] = param =>
            {
                var finalBillingStartDateFilter = Request.Query["startDate"];
                var finalBillingEndDateFilter = Request.Query["endDate"];

                if (finalBillingStartDateFilter.HasValue) endDateFilter = finalBillingStartDateFilter;
                if (finalBillingEndDateFilter.HasValue) startDateFilter = finalBillingEndDateFilter;

                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                var finalBillingRepo = finalBillingRepository.Where(x => (x.CustomerId == searchId || x.ClientId == searchId)
                                                                    && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                foreach (var transaction in finalBillingRepo)
                {
                    var userTransactionsList = new List<TransactionDto>();

                    var userMeta = userMetaRepository.FirstOrDefault(x => x.Id == transaction.User.UserId) ?? new UserMeta
                    {
                        Id = transaction.User.UserId,
                        Username = transaction.User.Username
                    };

                    // Filter repo for user transaction;
                    var userTransactions = finalBillingRepo.Where(x => x.User.UserId == transaction.User.UserId)
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

                    var user = Mapper.Map<FinalBilling, UserDto>(transaction);
                    Mapper.Map(userMeta, user);
                    user.Transactions = userTransactionsList;

                    var userIndex = customerUsersDetailList.FindIndex(x => x.UserId == user.UserId);
                    if (userIndex < 0) customerUsersDetailList.Add(user);
                }

                return Response.AsJson(new { data = customerUsersDetailList });
            };


            Get["/FinalBilling/CustomerClient/{searchId}/Packages"] = param =>
            {
                var finalBillingStartDateFilter = Request.Query["startDate"];
                var finalBillingEndDateFilter = Request.Query["endDate"];

                if (finalBillingStartDateFilter.HasValue) endDateFilter = finalBillingStartDateFilter;
                if (finalBillingEndDateFilter.HasValue) startDateFilter = finalBillingEndDateFilter;

                var searchId = new Guid(param.searchId);
                var customerPackagesDetailList = new List<PackageDto>();

                var finalBillingRepo = finalBillingRepository.Where(x => (x.CustomerId == searchId || x.ClientId == searchId)
                                                                    && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                foreach (var transaction in finalBillingRepo)
                {
                    var packageTransactions = finalBillingRepo.Where(x => x.Package.PackageId == transaction.Package.PackageId).Distinct();

                    var package = Mapper.Map<Package, PackageDto>(transaction.Package);
                    package.PackageTransactions = packageTransactions.Count();

                    var packageIndex = customerPackagesDetailList.FindIndex(x => x.PackageId == package.PackageId);
                    if (packageIndex < 0) customerPackagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = customerPackagesDetailList });
            };

        }

        private async Task CheckCache(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            this.Info(() => "Checking FinalBilling Cache");

            if (finalBillingRepository.Count <= 0)
            {
                this.Info(() => "No FinalBilling records in cache. Switching to FinalBilling DB Repository");
                finalBillingRepository = _finalBillingDBRepository.ToList();
            }
            else
            {
                this.Info(() => "FinalBilling Cache loaded");
            }
        }
    }

}