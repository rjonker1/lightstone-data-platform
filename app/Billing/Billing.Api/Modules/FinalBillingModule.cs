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

namespace Billing.Api.Modules
{
    public class FinalBillingModule : SecureModule
    {
        public FinalBillingModule(IRepository<FinalBilling> finalBillingRepository, IRepository<UserMeta> userMetaRepository)
        {

            Get["/FinalBilling/"] = _ =>
            {
                var customerClientList = new List<FinalBillingDto>();

                foreach (var transaction in finalBillingRepository)
                {
                    var customerClient = new FinalBillingDto();
                    var userList = new List<User>();

                    IQueryable<FinalBilling> customerTransactions = finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId);

                    var customerPackages = customerTransactions.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    IQueryable<FinalBilling> clientTransactions = finalBillingRepository.Where(x => x.ClientId == transaction.ClientId);

                    var clientPackagesTotal = clientTransactions.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    // Customer
                    if (transaction.ClientId == new Guid())
                    {
                        customerClient = new FinalBillingDto
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
                        customerClient = new FinalBillingDto
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


            Get["/FinalBilling/CustomerClient/{searchId}/Users"] = param =>
            {
                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                IQueryable<FinalBilling> finalBillingRepo = finalBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId);

                foreach (var transaction in finalBillingRepo)
                {
                    var userTransactionsList = new List<TransactionDto>();

                    var userMeta = userMetaRepository.FirstOrDefault(x => x.Id == transaction.UserId) ?? new UserMeta
                    {
                        Id = transaction.UserId,
                        Username = transaction.Username
                    };

                    // Filter repo for user transaction;
                    var userTransactions = finalBillingRepo.Where(x => x.UserId == transaction.UserId)
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
                var searchId = new Guid(param.searchId);
                var customerPackagesDetailList = new List<PackageDto>();

                IQueryable<FinalBilling> finalBillingRepo = finalBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId);

                foreach (var transaction in finalBillingRepo)
                {
                    var package = Mapper.Map<FinalBilling, PackageDto>(transaction);

                    var packageIndex = customerPackagesDetailList.FindIndex(x => x.PackageId == package.PackageId);
                    if (packageIndex < 0) customerPackagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = customerPackagesDetailList });
            };

        }
    }

}