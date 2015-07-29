using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Billing.Domain.Dtos;
using Billing.Domain.Entities;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
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

        public StageBillingModule(IRepository<StageBilling> stageBillingDBRepository, IRepository<AuditLog> auditLogs, IRepository<UserMeta> userMetaRepository,
                                    ICommitBillingTransaction<UserTransactionDto> userBillingTransaction,
                                    ICommitBillingTransaction<CustomerClientTransactionDto> customerClientBillingTransaction,
                                    ICommitBillingTransaction<PackageTransactionDto> packBillingTransaction,
                                    ICacheProvider<StageBilling> stageBillingCacheProvider)
        {
            _stageBillingDBRepository = stageBillingDBRepository;
            stageBillingRepository = stageBillingCacheProvider.CacheClient.GetAll();

            Before += async (ctx, ct) =>
            {
                await CheckCache(ct);
                this.Info(() => "Before Hook - PreBilling");
                return null;
            };

            After += async (ctx, ct) => this.Info(() => "After Hook - PreBilling");
            
            Get["/StageBilling/"] = _ =>
            {
                var customerClientList = new List<StageBillingDto>();

                foreach (var transaction in stageBillingRepository)
                {
                    var customerClient = new StageBillingDto();
                    var userList = new List<User>();

                    var customerTransactions = stageBillingRepository.Where(x => x.CustomerId == transaction.CustomerId).DistinctBy(x => x.TransactionId);

                    var customerPackages = customerTransactions.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    var billedCustomerTransactionsTotal = customerTransactions.Where(x => x.IsBillable);


                    var clientTransactions = stageBillingRepository.Where(x => x.ClientId == transaction.ClientId).DistinctBy(x => x.TransactionId);

                    var clientPackagesTotal = clientTransactions.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    var billedClientTransactionsTotal = clientTransactions.Where(x => x.IsBillable);

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
                        UserId = transaction.UserId,
                        Username = transaction.Username,
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
                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                var stageBillingRepo = stageBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId).DistinctBy(x => x.TransactionId);

                foreach (var transaction in stageBillingRepo)
                {
                    var userTransactionsList = new List<TransactionDto>();

                    var userMeta = userMetaRepository.FirstOrDefault(x => x.Id == transaction.UserId) ?? new UserMeta
                    {
                        Id = transaction.UserId,
                        Username = transaction.Username
                    };

                    // Filter repo for user transaction;
                    var userTransactions = stageBillingRepo.Where(x => x.UserId == transaction.UserId)
                                            .Select(x =>
                                            new TransactionDto
                                            {
                                                TransactionId = x.TransactionId,
                                                RequestId = x.RequestId,
                                                IsBillable = x.IsBillable
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

                var stageBillingRepo = stageBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId).DistinctBy(x => x.TransactionId);

                foreach (var transaction in stageBillingRepo)
                {
                    var packageTransactions = stageBillingRepo.Where(x => x.PackageId == transaction.PackageId).Distinct();

                    var package = Mapper.Map<StageBilling, PackageDto>(transaction);
                    package.PackageTransactions = packageTransactions.Count();

                    var packageIndex = customerPackagesDetailList.FindIndex(x => x.PackageId == package.PackageId);
                    if (packageIndex < 0) customerPackagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = customerPackagesDetailList });
            };

            Get["/StageBilling/Billable/Transactions/{searchId}"] = param =>
            {
                var searchId = new Guid(param.searchId);
                var packagesDetailList = new List<PackageDto>();

                var transactions = stageBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId).DistinctBy(x => x.TransactionId);

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

                    var package = Mapper.Map<StageBilling, PackageDto>(transaction);
                    package.PackageTransactions = transactions.Count(x => x.PackageId == transaction.PackageId);

                    var packageIndex = packagesDetailList.FindIndex(x => x.PackageId == package.PackageId);
                    if (packageIndex < 0) packagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = packagesDetailList });
            };

            Post["/StageBilling/User/Transactions"] = param =>
            {
                var dto = this.Bind<UserDto>();

                var packageTransaction = new List<UserTransaction>();

                foreach (var transaction in dto.Transactions)
                {
                    foreach (var billTransaction in stageBillingRepository.Where(x => x.RequestId == transaction.RequestId).DistinctBy(x => x.PackageId))
                    {
                        packageTransaction.Add(new UserTransaction
                        {
                            RequestId = transaction.RequestId,
                            PackageName = billTransaction.PackageName,
                            IsBillable = billTransaction.IsBillable
                        });
                    }
                }

                return Response.AsJson(new { data = packageTransaction });
            };

            // User billable transactions
            Post["/StageBilling/User/Transactions/Update"] = param =>
            {
                var body = Request.Body<UserTransactionDto>();
                body.UserName = Context.CurrentUser.UserName;

                userBillingTransaction.Commit(body);

                return Response.AsJson(new {data = "Success"});
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

            if (stageBillingRepository.Count <= 0) stageBillingRepository = _stageBillingDBRepository.ToList();
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