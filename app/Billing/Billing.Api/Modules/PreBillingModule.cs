using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;
using PreBillingDto = Billing.Domain.Dtos.PreBillingDto;

namespace Billing.Api.Modules
{
    public class PreBillingModule : SecureModule
    {
        private readonly IRepository<PreBilling> _preBillingDBRepository;
        private readonly ICacheProvider<PreBilling> _preBillingCacheProvider;
        private IList<PreBilling> _preBillingRepository;

        public PreBillingModule(IRepository<PreBilling> preBillingDBRepository, 
                                IRepository<UserMeta> userMetaRepository, ICacheProvider<PreBilling> preBillingCacheProvider)
        {
            _preBillingDBRepository = preBillingDBRepository;
            _preBillingCacheProvider = preBillingCacheProvider;
            _preBillingRepository = preBillingCacheProvider.CacheClient.GetAll();

            Before += async (ctx, ct) =>
            {
                await CheckCache(ct);
                this.Info(() => "Before Hook - PreBilling");
                return null;
            };

            After += async (ctx, ct) =>
            {
                ct.ThrowIfCancellationRequested();
                this.Info(() => "After Hook - PreBilling");
            };

            Get["/PreBilling/", true] = async (parameters, ct) =>
            {
                var customerClientList = new List<PreBillingDto>();

                foreach (var transaction in _preBillingRepository)
                {
                    var customerClient = new PreBillingDto();
                    var userList = new List<User>();

                    var customerTransactions = _preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId).DistinctBy(x => x.TransactionId);

                    var customerPackages = customerTransactions.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();


                    var clientTransactions = _preBillingRepository.Where(x => x.ClientId == transaction.ClientId).DistinctBy(x => x.TransactionId);

                    var clientPackagesTotal = clientTransactions.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.PackageId).Distinct().Count();

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


            Get["/PreBilling/CustomerClient/{searchId}/Users"] = param =>
            {
                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                var preBillingRepo = _preBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId).DistinctBy(x => x.TransactionId);

                foreach (var transaction in preBillingRepo)
                {
                    var userTransactionsList = new List<TransactionDto>();

                    var userMeta = userMetaRepository.FirstOrDefault(x => x.Id == transaction.UserId) ?? new UserMeta
                    {
                        Id = transaction.UserId,
                        Username = transaction.Username
                    };

                    // Filter repo for user transaction;
                    var userTransactions = preBillingRepo.Where(x => x.UserId == transaction.UserId)
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
                var searchId = new Guid(param.searchId);
                var customerPackagesDetailList = new List<PackageDto>();

                var preBillingRepo = _preBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId).DistinctBy(x => x.TransactionId);

                foreach (var transaction in preBillingRepo)
                {
                    var packageTransactions = preBillingRepo.Where(x => x.PackageId == transaction.PackageId).Distinct();

                    var package = Mapper.Map<PreBilling, PackageDto>(transaction);
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

            if (_preBillingRepository.Count <= 0) _preBillingRepository = _preBillingDBRepository.ToList();

            //try
            //{
            //    if (_preBillingRepository.Count <= 0)
            //    {
            //        this.Info(() => "Cache not available. Switching to DB repository.");

            //        var cache = await DBtoCache(_preBillingDBRepository, _preBillingCacheProvider);
            //        ct.ThrowIfCancellationRequested();

            //        if (cache) this.Info(() => "PreBilling loaded to cache.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.Error(() => ex.Message);
            //    _preBillingRepository = _preBillingDBRepository.ToList();
            //}
        }

        private async Task<bool> DBtoCache(IRepository<PreBilling> repository, ICacheProvider<PreBilling> cacheProvider)
        {
            return await cacheProvider.CachePipelineInsert(repository);
        }
    }

}