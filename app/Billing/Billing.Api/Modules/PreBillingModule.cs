using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;
using PreBillingDto = Billing.Domain.Dtos.PreBillingDto;

namespace Billing.Api.Modules
{
    public class PreBillingModule : SecureModule
    {
        public PreBillingModule(IRepository<PreBilling> preBillingRepository, IRepository<UserMeta> userMetaRepository)
        {

            Get["/PreBilling/"] = _ =>
            {
                var customerClientList = new List<PreBillingDto>();

                foreach (var transaction in preBillingRepository)
                {
                    var customerClient = new PreBillingDto();
                    var userList = new List<User>();
                    
                    IQueryable<PreBilling> customerTransactions = preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId);

                    var customerPackages = customerTransactions.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    IQueryable<PreBilling> clientTransactions = preBillingRepository.Where(x => x.ClientId == transaction.ClientId);

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

                IQueryable<PreBilling> preBillingRepo = preBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId);

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

                IQueryable<PreBilling> preBillingRepo = preBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId);

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
    }

}