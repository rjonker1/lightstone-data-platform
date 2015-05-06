﻿using System;
using System.Collections.Generic;
using System.Linq;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class FinalBillingModule : NancyModule
    {
        public FinalBillingModule(IRepository<FinalBilling> stageBillingRepository)
        {

            Get["/FinalBilling/"] = _ =>
            {

                var customerList = new List<StageBillingDto>();

                foreach (var transaction in stageBillingRepository)
                {

                    var userList = new List<User>();

                    //Transactions total for customer
                    var customerTransactionsTotal = stageBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    //Products total for customer
                    var customerPackagesTotal = stageBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    //Transactions total for client
                    var clientTransactionsTotal = stageBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    //Products total for client
                    var clientPackagesTotal = stageBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    var customer = new StageBillingDto();
                    //Customer
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

                    //Client
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

                    //Customer user
                    var user = new User
                    {
                        UserId = transaction.UserId,
                        Username = transaction.Username,
                        HasTransactions = true
                    };

                    //Indices
                    var userIndex = userList.FindIndex(x => x.UserId == user.UserId);
                    var customerIndex = customerList.FindIndex(x => x.Id == customer.Id);


                    //Index restrictions for new records
                    if (userIndex < 0) userList.Add(user);

                    customer.Users = userList;

                    if (customerIndex < 0) customerList.Add(customer);
                }

                //return Response.AsJson(new { data = customerList });
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customerList });
            };


            Get["/FinalBilling/CustomerClient/{searchId}/Users"] = param =>
            {

                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<User>();

                foreach (var transaction in stageBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId))
                {
                    //User
                    var user = new User
                    {
                        UserId = transaction.UserId,
                        Username = transaction.Username,
                        FirstName = transaction.FirstName,
                        LastName = transaction.LastName,
                        HasTransactions = true
                    };

                    //Index
                    var userIndex = customerUsersDetailList.FindIndex(x => x.UserId == user.UserId);

                    //Index restriction for new record
                    if (userIndex < 0) customerUsersDetailList.Add(user);
                }

                return Response.AsJson(new { data = customerUsersDetailList });
            };


            Get["/FinalBilling/CustomerClient/{searchId}/Packages"] = param =>
            {

                var searchId = new Guid(param.searchId);
                var customerPackagesDetailList = new List<PackageDto>();

                foreach (var transaction in stageBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId))
                {

                    var dataProviderList = stageBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId)
                                            .Select(x =>
                                                new DataProviderDto()
                                                {
                                                    DataProviderId = x.DataProviderId,
                                                    DataProviderName = x.DataProviderName,
                                                    CostPrice = x.CostPrice,
                                                    RecommendedPrice = x.RecommendedPrice,

                                                    PackageId = x.PackageId,
                                                    PackageName = x.PackageName

                                                }).Distinct();

                    //Package
                    var package = new PackageDto()
                    {
                        PackageId = transaction.PackageId,
                        PackageName = transaction.PackageName,
                        DataProviders = dataProviderList
                    };

                    //Package Index
                    var packageIndex = customerPackagesDetailList.FindIndex(x => x.PackageId == package.PackageId);

                    //Index restriction for new record
                    if (packageIndex < 0) customerPackagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = customerPackagesDetailList });
            };

        }
    }

}