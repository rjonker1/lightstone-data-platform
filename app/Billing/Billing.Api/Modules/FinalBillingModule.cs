using System;
using System.Collections.Generic;
using System.Linq;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class FinalBillingModule : SecureModule
    {
        public FinalBillingModule(IRepository<FinalBilling> finalBillingRepository, IRepository<UserMeta> userMetaRepository)
        {

            Get["/FinalBilling/"] = _ =>
            {

                var customerList = new List<StageBillingDto>();

                foreach (var transaction in finalBillingRepository)
                {
                    var userList = new List<User>();

                    // Transactions total for customer
                    var customerTransactionsTotal = finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    // Products total for customer
                    var customerPackagesTotal = finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    // Transactions total for client
                    var clientTransactionsTotal = finalBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    // Products total for client
                    var clientPackagesTotal = finalBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    var customer = new StageBillingDto();
                    // Customer
                    if (transaction.ClientId == new Guid())
                    {
                        customer = new StageBillingDto
                        {
                            Id = transaction.CustomerId,
                            CustomerName = transaction.CustomerName,
                            Transactions = customerTransactionsTotal,
                            Products = customerPackagesTotal
                        };
                    }

                    // Client
                    if (transaction.CustomerId == new Guid())
                    {
                        customer = new StageBillingDto
                        {
                            Id = transaction.ClientId,
                            CustomerName = transaction.ClientName,
                            Transactions = clientTransactionsTotal,
                            Products = clientPackagesTotal
                        };
                    }

                    // Customer user
                    var user = new User
                    {
                        UserId = transaction.UserId,
                        Username = transaction.Username,
                        HasTransactions = true
                    };

                    // Indices
                    var userIndex = userList.FindIndex(x => x.UserId == user.UserId);
                    var customerIndex = customerList.FindIndex(x => x.Id == customer.Id);


                    // Index restrictions for new records
                    if (userIndex < 0) userList.Add(user);

                    customer.Users = userList;

                    if (customerIndex < 0) customerList.Add(customer);
                }

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customerList });
            };


            Get["/FinalBilling/CustomerClient/{searchId}/Users"] = param =>
            {
                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                foreach (var transaction in finalBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId))
                {

                    var userTransactionsList = new List<TransactionDto>();

                    // Get User Meta data
                    var userMeta = userMetaRepository.FirstOrDefault(x => x.Id == transaction.UserId) ?? new UserMeta
                    {
                        Id = transaction.UserId,
                        Username = transaction.Username
                    };

                    // Filter repo for user transaction; For specified customer | client
                    var userTransactions = finalBillingRepository.Where(x => x.UserId == transaction.UserId
                        && (x.CustomerId == searchId || x.ClientId == searchId))
                                            .Select(x =>
                                            new TransactionDto
                                            {
                                                TransactionId = x.TransactionId,
                                                RequestId = x.RequestId,
                                                IsBillable = x.IsBillable
                                            }).Distinct();

                    foreach (var userTransaction in userTransactions)
                    {

                        // Index
                        var userTransIndex = userTransactionsList.FindIndex(x => x.TransactionId == userTransaction.TransactionId);
                        if (userTransIndex < 0) userTransactionsList.Add(userTransaction);
                    }

                    // User
                    var user = new UserDto
                    {
                        UserId = transaction.UserId,
                        Username = transaction.Username,
                        FirstName = userMeta.FirstName,
                        LastName = userMeta.LastName,
                        Transactions = userTransactionsList
                    };

                    // Index
                    var userIndex = customerUsersDetailList.FindIndex(x => x.UserId == user.UserId);

                    // Index restriction for new record
                    if (userIndex < 0) customerUsersDetailList.Add(user);
                }

                return Response.AsJson(new { data = customerUsersDetailList });
            };


            Get["/FinalBilling/CustomerClient/{searchId}/Packages"] = param =>
            {
                var searchId = new Guid(param.searchId);
                var customerPackagesDetailList = new List<PackageDto>();

                foreach (var transaction in finalBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId))
                {
                    // Package
                    var package = new PackageDto()
                    {
                        PackageId = transaction.PackageId,
                        PackageName = transaction.PackageName,
                        PackageCostPrice = transaction.PackageCostPrice,
                        PackageRecommendedPrice = transaction.PackageRecommendedPrice
                    };

                    // Package Index
                    var packageIndex = customerPackagesDetailList.FindIndex(x => x.PackageId == package.PackageId);

                    // Index restriction for new record
                    if (packageIndex < 0) customerPackagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = customerPackagesDetailList });
            };

        }
    }

}