using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Billing.Domain.Dtos;
using Billing.Domain.Entities;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Extensions;
using Nancy.Json;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Nancy.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;

namespace Billing.Api.Modules
{
    public class StageBillingModule : SecureModule
    {
        private readonly IRepository<StageBilling> _stageBillingDBRepository;
        private IList<StageBilling> stageBillingRepository;

        private static int _defaultJsonMaxLength;

        public StageBillingModule(IRepository<StageBilling> stageBillingDBRepository, IRepository<AuditLog> auditLogs, IRepository<UserMeta> userMetaRepository,
                                    IRepository<ContractMeta> contracMetaRepository,
                                    ICommitBillingTransaction<UserTransactionDto> userBillingTransaction,
                                    ICommitBillingTransaction<CustomerClientTransactionDto> customerClientBillingTransaction,
                                    ICommitBillingTransaction<PackageTransactionDto> packBillingTransaction,
                                    ICacheProvider<StageBilling> stageBillingCacheProvider)
        {
            this.RequiresClaims(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            if (_defaultJsonMaxLength == 0)
                _defaultJsonMaxLength = JsonSettings.MaxJsonLength;

            //Hackeroonie - Required, due to complex model structures (Nancy default restriction length [102400])
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            _stageBillingDBRepository = stageBillingDBRepository;
            stageBillingRepository = stageBillingCacheProvider.CacheClient.GetAll();

            var endDateFilter = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            var startDateFilter = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 26);

            Before += async (ctx, ct) =>
            {
                this.Info(() => "Before Hook - StageBilling");
                await CheckCache(ct);
                return null;
            };

            After += async (ctx, ct) => this.Info(() => "After Hook - StageBilling");

            Get["/StageBilling/"] = _ =>
            {
                var stageBillingStartDateFilter = Request.Query["startDate"];
                var stageBillingEndDateFilter = Request.Query["endDate"];

                if (stageBillingStartDateFilter.HasValue) endDateFilter = stageBillingStartDateFilter;
                if (stageBillingEndDateFilter.HasValue) startDateFilter = stageBillingEndDateFilter;

                endDateFilter = endDateFilter.AddHours(23).AddMinutes(59).AddSeconds(59);

                var customerClientList = new List<StageBillingDto>();

                foreach (var transaction in stageBillingRepository)
                {
                    var customerClient = new StageBillingDto();
                    var userList = new List<User>();

                    var customerTransactions = stageBillingRepository.Where(x => x.CustomerId == transaction.CustomerId
                                                                            && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                    var customerPackages = customerTransactions.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.Package.PackageId).Distinct().Count();

                    var billedCustomerTransactionsTotal = customerTransactions.Where(x => x.UserTransaction.IsBillable);


                    var clientTransactions = stageBillingRepository.Where(x => x.ClientId == transaction.ClientId).DistinctBy(x => x.UserTransaction.TransactionId);

                    var clientPackagesTotal = clientTransactions.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.Package.PackageId).Distinct().Count();

                    var billedClientTransactionsTotal = clientTransactions.Where(x => x.UserTransaction.IsBillable);

                    // Customer
                    if (transaction.ClientId == new Guid())
                    {
                        customerClient = new StageBillingDto
                        {
                            Id = transaction.CustomerId,
                            CustomerName = transaction.CustomerName,
                            Transactions = customerTransactions.Count(),
                            BilledTransactions = billedCustomerTransactionsTotal.Count(),
                            Products = customerPackages
                        };
                    }

                    // Client
                    if (transaction.CustomerId == new Guid())
                    {
                        customerClient = new StageBillingDto
                        {
                            Id = transaction.ClientId,
                            CustomerName = transaction.ClientName,
                            Transactions = clientTransactions.Count(),
                            BilledTransactions = billedClientTransactionsTotal.Count(),
                            Products = clientPackagesTotal
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


            Get["/StageBilling/CustomerClient/{searchId}/Users"] = param =>
            {
                var stageBillingStartDateFilter = Request.Query["startDate"];
                var stageBillingEndDateFilter = Request.Query["endDate"];

                if (stageBillingStartDateFilter.HasValue) endDateFilter = stageBillingStartDateFilter;
                if (stageBillingEndDateFilter.HasValue) startDateFilter = stageBillingEndDateFilter;

                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                var stageBillingRepo = stageBillingRepository.Where(x => (x.CustomerId == searchId || x.ClientId == searchId)
                                                                    && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                foreach (var transaction in stageBillingRepo)
                {
                    var userTransactionsList = new List<TransactionDto>();

                    var userMeta = userMetaRepository.FirstOrDefault(x => x.Id == transaction.User.UserId) ?? new UserMeta
                    {
                        Id = transaction.User.UserId,
                        Username = transaction.User.Username
                    };

                    // Filter repo for user transaction;
                    var userTransactions = stageBillingRepo.Where(x => x.User.UserId == transaction.User.UserId)
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

                    var user = Mapper.Map<StageBilling, UserDto>(transaction);
                    Mapper.Map(userMeta, user);
                    user.Transactions = userTransactionsList;

                    var userIndex = customerUsersDetailList.FindIndex(x => x.UserId == user.UserId);
                    if (userIndex < 0) customerUsersDetailList.Add(user);
                }

                return Response.AsJson(new { data = customerUsersDetailList });
            };


            Get["/StageBilling/CustomerClient/{searchId}/Packages"] = param =>
            {
                var searchId = new Guid(param.searchId);
                var customerPackagesDetailList = new List<PackageDto>();

                var stageBillingRepo = stageBillingRepository.Where(x => (x.CustomerId == searchId || x.ClientId == searchId)
                                                                    && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                foreach (var transaction in stageBillingRepo)
                {
                    var packageTransactions = stageBillingRepo.Where(x => x.Package.PackageId == transaction.Package.PackageId).Distinct();

                    var package = Mapper.Map<Package, PackageDto>(transaction.Package);
                    package.PackageTransactions = packageTransactions.Count();

                    var packageIndex = customerPackagesDetailList.FindIndex(x => x.PackageId == package.PackageId);
                    if (packageIndex < 0) customerPackagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = customerPackagesDetailList });
            };

            // Report build-up
            Get["/StageBilling/Billable/Transactions/{searchId}"] = param =>
            {
                var stageBillingStartDateFilter = Request.Query["startDate"];
                var stageBillingEndDateFilter = Request.Query["endDate"];

                if (stageBillingStartDateFilter.HasValue) endDateFilter = stageBillingStartDateFilter;
                if (stageBillingEndDateFilter.HasValue) startDateFilter = stageBillingEndDateFilter;

                var searchId = new Guid(param.searchId);
                var packagesDetailList = new List<PackageDto>();

                var transactions = stageBillingRepository.Where(x => (x.CustomerId == searchId || x.ClientId == searchId)
                                                                    && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.UserTransaction.TransactionId);

                var transactionsTotal = 0;

                foreach (var transaction in transactions)
                {
                    var contractId = transaction.ContractId;

                    var package = Mapper.Map<Package, PackageDto>(transaction.Package);
                    var packageTransactions = transactions.Count(x => x.Package.PackageId == transaction.Package.PackageId);

                    package.PackageDescription = package.PackageName;
                    package.PackageTransactions = packageTransactions;

                    // Return Pacakge details without price, if non-billable
                    if (!transaction.UserTransaction.IsBillable)
                    {
                        var emptyPackage = new PackageDto
                        {
                            PackageId = package.PackageId,
                            PackageName = package.PackageName,
                            PackageDescription = "Non-billable",
                            PackageTransactions = packageTransactions,
                            PackageCostPrice = 0.00,
                            PackageRecommendedPrice = 0.00
                        };

                        // Package Index
                        var emptyPackageIndex = packagesDetailList.FindIndex(x => x.PackageId == emptyPackage.PackageId);

                        //Index restriction for new record
                        if (emptyPackageIndex < 0) packagesDetailList.Add(emptyPackage);
                        continue;
                    }

                    var packageIndex = packagesDetailList.FindIndex(x => x.PackageId == package.PackageId);
                    if (packageIndex < 0)
                    {
                        packagesDetailList.Add(package);
                        transactionsTotal += package.PackageTransactions;
                    }

                    if (transaction.Equals(transactions.Last()))
                    {
                        var contractMeta = contracMetaRepository.FirstOrDefault(x => x.ContractId == contractId && x.IsActive && x.HasPackagePriceOverride);

                        if (contractMeta != null)
                        {
                            foreach (var packageDto in packagesDetailList)
                            {
                                packageDto.PackageDescription = "Pacakge bundled";
                                packageDto.PackageCostPrice = 0;
                                packageDto.PackageRecommendedPrice = 0;
                            }

                            if (transactionsTotal <= contractMeta.ContractBundleTransactionLimit)
                            {
                                var inBundle = new PackageDto
                                {
                                    PackageId = Guid.NewGuid(),
                                    PackageName = contractMeta.ContractBundleName,
                                    PackageDescription = contractMeta.ContractBundleTransactionLimit + " Transactions @ R" + Math.Round(contractMeta.ContractBundlePrice, 2),
                                    PackageCostPrice = 0,
                                    PackageRecommendedPrice = Math.Round(contractMeta.ContractBundlePrice, 2),
                                    PackageTransactions = 1
                                };

                                packagesDetailList.Add(inBundle);
                            }

                            if (transactionsTotal > contractMeta.ContractBundleTransactionLimit)
                            {
                                var diff = transactionsTotal - contractMeta.ContractBundleTransactionLimit;
                                double outOfBundleRate = (contractMeta.ContractBundlePrice / contractMeta.ContractBundleTransactionLimit);

                                var inBundle = new PackageDto
                                {
                                    PackageId = Guid.NewGuid(),
                                    PackageName = contractMeta.ContractBundleName,
                                    PackageDescription = contractMeta.ContractBundleTransactionLimit + " Transactions @ R" + Math.Round(contractMeta.ContractBundlePrice, 2),
                                    PackageCostPrice = 0,
                                    PackageRecommendedPrice = Math.Round(contractMeta.ContractBundlePrice, 2),
                                    PackageTransactions = 1
                                };

                                var outBundle = new PackageDto
                                {
                                    PackageId = Guid.NewGuid(),
                                    PackageName = "Out of Bundle",
                                    PackageDescription = diff + " Extra transactions @ R" + Math.Round(outOfBundleRate, 2),
                                    PackageCostPrice = 0,
                                    PackageRecommendedPrice = Math.Round(outOfBundleRate, 2),
                                    PackageTransactions = diff
                                };

                                packagesDetailList.Add(inBundle);
                                packagesDetailList.Add(outBundle);
                            }
                        }
                    }

                }

                return Response.AsJson(new { data = packagesDetailList });
            };

            Post["/StageBilling/User/Transactions"] = param =>
            {
                var stageBillingStartDateFilter = Request.Query["startDate"];
                var stageBillingEndDateFilter = Request.Query["endDate"];

                if (stageBillingStartDateFilter.HasValue) endDateFilter = stageBillingStartDateFilter;
                if (stageBillingEndDateFilter.HasValue) startDateFilter = stageBillingEndDateFilter;

                var dto = this.Bind<UserDto>();

                var userTransactions = new List<UserTransaction>();

                foreach (var transaction in dto.Transactions)
                {
                    foreach (var billTransaction in stageBillingRepository.Where(x => x.UserTransaction.RequestId == transaction.RequestId 
                                                                            && (x.Created >= startDateFilter && x.Created <= endDateFilter)).DistinctBy(x => x.Package.PackageId))
                    {
                        userTransactions.Add(new UserTransaction
                        {
                            RequestId = transaction.RequestId,
                            PackageName = billTransaction.Package.PackageName,
                            IsBillable = billTransaction.UserTransaction.IsBillable
                        });
                    }
                }

                return Response.AsJson(new { data = userTransactions });
            };

            // User billable transactions
            Post["/StageBilling/User/Transactions/Update"] = param =>
            {
                var body = Request.Body<UserTransactionDto>();
                body.UserName = Context.CurrentUser.UserName;

                userBillingTransaction.Commit(body);

                return Response.AsJson(new { data = "Success" });
            };

            // Customer | Client
            Post["/StageBilling/CustomerClient/Transaction/Update"] = param =>
            {
                var body = this.Bind<CustomerClientTransactionDto>();

                customerClientBillingTransaction.Commit(body);
                auditLogs.SaveOrUpdate(new AuditLog
                {
                    Id = Guid.NewGuid(),
                    Modified = DateTime.UtcNow,
                    ModifiedBy = Context.CurrentUser.UserName,
                    FieldName = body.Name,
                    NewValue = body.Value,
                    OriginalValue = body.OriginalValue
                });

                return Response.AsJson(new { data = "Success" });
            };

            // Package detail
            Post["/StageBilling/Package/Transaction/Update"] = param =>
            {
                var body = this.Bind<PackageTransactionDto>();

                packBillingTransaction.Commit(body);
                auditLogs.SaveOrUpdate(new AuditLog
                {
                    Id = Guid.NewGuid(),
                    Modified = DateTime.UtcNow,
                    ModifiedBy = Context.CurrentUser.UserName,
                    FieldName = body.Name,
                    NewValue = body.Value,
                    OriginalValue = body.OriginalValue
                });

                return Response.AsJson(new { data = "Success" });
            };

        }

        private async Task CheckCache(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            this.Info(() => "Checking StageBilling Cache");

            if (stageBillingRepository.Count <= 0)
            {
                this.Info(() => "No StageBilling records in cache. Switching to StageBilling DB Repository");
                stageBillingRepository = _stageBillingDBRepository.ToList();
            }
            else
            {
                this.Info(() => "StageBilling Cache loaded");
            }
        }
    }

    public static class BodyBinderExtension
    {
        public static T Body<T>(this Request request)
        {
            request.Body.Position = 0;
            string bodyText;
            using (var bodyReader = new StreamReader(request.Body))
            {
                bodyText = bodyReader.ReadToEnd();
            }

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
            };

            return JsonConvert.DeserializeObject<T>(bodyText);
        }
    }

}