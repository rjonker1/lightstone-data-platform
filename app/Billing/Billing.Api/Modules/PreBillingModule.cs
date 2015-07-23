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
    public class PreBillingModule : SecureModule
    {
        public PreBillingModule(IRepository<PreBilling> preBillingRepository, IRepository<UserMeta> userMetaRepository)
        {

            Get["/PreBilling/"] = _ =>
            {
                var customerList = new List<PreBillingDto>();

                foreach (var transaction in preBillingRepository)
                {

                    var userList = new List<User>();

                    // Transactions total for customer
                    //var customerTransactionsTotal = preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                    //                                    .Select(x => x.TransactionId).Distinct().Count();
                    
                    //DB Query
                    IQueryable<PreBilling> customerTransactions = preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId);
                    // Products total for customer
                    //var customerPackagesTotal = preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                    //                                    .Select(x => x.PackageId).Distinct().Count();

                    //In-Memory
                    var customerPackages = customerTransactions.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    // Transactions total for client
                    //var clientTransactionsTotal = preBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                    //                                    .Select(x => x.TransactionId).Distinct().Count();

                    //DB Query
                    IQueryable<PreBilling> clientTransactions = preBillingRepository.Where(x => x.ClientId == transaction.ClientId);

                    // Products total for client
                    //var clientPackagesTotal = preBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                    //                                    .Select(x => x.PackageId).Distinct().Count(); 

                    //In-Memory
                    var clientPackagesTotal = clientTransactions.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    var customer = new PreBillingDto();
                    // Customer
                    if (transaction.ClientId == new Guid())
                    {
                        customer = new PreBillingDto
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
                        customer = new PreBillingDto
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
                    var customerIndex = customerList.FindIndex(x => x.Id == customer.Id);


                    // Index restrictions for new records
                    if (userIndex < 0) userList.Add(user);

                    customer.Users = userList;

                    if (customerIndex < 0) customerList.Add(customer);
                }

                //return Response.AsJson(new { data = customerList });
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customerList });
            };


            Get["/PreBilling/CustomerClient/{searchId}/Users"] = param =>
            {
                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                foreach (var transaction in preBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId))
                {

                    var userTransactionsList = new List<TransactionDto>();

                    // Get User Meta data
                    var userMeta = userMetaRepository.FirstOrDefault(x => x.Id == transaction.UserId) ?? new UserMeta
                    {
                        Id = transaction.UserId,
                        Username = transaction.Username
                    };

                    // Filter repo for user transaction; For specified customer | client
                    var userTransactions = preBillingRepository.Where(x => x.UserId == transaction.UserId
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


            Get["/PreBilling/CustomerClient/{searchId}/Packages"] = param =>
            {
                var searchId = new Guid(param.searchId);
                var customerPackagesDetailList = new List<PackageDto>();

                foreach (var transaction in preBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId))
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