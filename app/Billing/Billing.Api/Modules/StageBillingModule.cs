using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Billing.Domain.Dtos;
using Billing.Domain.Entities;
using DataPlatform.Shared.Repositories;
using FluentNHibernate.Utils;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class StageBillingModule : NancyModule
    {
        public StageBillingModule(IRepository<StageBilling> stageBillingRepository, 
                                    ICommitBillingTransaction<UserTransactionDto> userBillingTransaction,
                                    ICommitBillingTransaction<CustomerClientTransactionDto> customerClientBillingTransaction,
                                    ICommitBillingTransaction<PackageTransactionDto> packBillingTransaction)
        {

            Get["/StageBilling/"] = _ =>
            {

                var customerList = new List<StageBillingDto>();

                foreach (var transaction in stageBillingRepository)
                {

                    var userList = new List<User>();

                    //Transactions total for customer
                    var customerTransactionsTotal = stageBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    var billedCustomerTransactionsTotal = stageBillingRepository.Where(x => x.CustomerId == transaction.CustomerId && x.IsBillable)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    //Products total for customer
                    var customerPackagesTotal = stageBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    //Transactions total for client
                    var clientTransactionsTotal = stageBillingRepository.Where(x => x.ClientId == transaction.ClientId)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    var billedClientTransactionsTotal = stageBillingRepository.Where(x => x.ClientId == transaction.ClientId && x.IsBillable)
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
                            BilledTransactions = billedCustomerTransactionsTotal,
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
                            BilledTransactions = billedClientTransactionsTotal,
                            Products = clientPackagesTotal
                        };
                    }

                    //Customer user
                    var user = new User
                    {
                        UserId = transaction.UserId,
                        Username = transaction.Username,
                        HasTransactions = transaction.HasTransactions
                    };

                    //Indices
                    var userIndex = userList.FindIndex(x => x.UserId == user.UserId);
                    var customerIndex = customerList.FindIndex(x => x.Id == customer.Id);

                    //Index restrictions for new records
                    if (userIndex < 0 && user.HasTransactions) userList.Add(user);

                    customer.Users = userList;
                    if (customerIndex < 0 && customer.Users.Any()) customerList.Add(customer);
                }

                //return Response.AsJson(new { data = customerList });
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customerList });
            };


            Get["/StageBilling/CustomerClient/{searchId}/Users"] = param =>
            {

                var searchId = new Guid(param.searchId);
                var customerUsersDetailList = new List<UserDto>();

                foreach (var transaction in stageBillingRepository.Where(x => x.CustomerId == searchId || x.ClientId == searchId))
                {

                    var userTransactionsList = new List<TransactionDto>();

                    //Filter repo for user transaction; For specified customer | client
                    var userTransactions = stageBillingRepository.Where(x => x.UserId == transaction.UserId
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

                        //Index
                        var userTransIndex = userTransactionsList.FindIndex(x => x.TransactionId == userTransaction.TransactionId);
                        if (userTransIndex < 0) userTransactionsList.Add(userTransaction);
                    }

                    //User
                    var user = new UserDto
                    {
                        UserId = transaction.UserId,
                        Username = transaction.Username,
                        FirstName = transaction.FirstName,
                        LastName = transaction.LastName,
                        Transactions = userTransactionsList
                    };

                    //Index
                    var userIndex = customerUsersDetailList.FindIndex(x => x.UserId == user.UserId);

                    //Index restriction for new record
                    if (userIndex < 0) customerUsersDetailList.Add(user);
                }

                return Response.AsJson(new { data = customerUsersDetailList });
            };


            Get["/StageBilling/CustomerClient/{searchId}/Packages"] = param =>
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

            Post["/StageBilling/User/Transactions/Update"] = param =>
            {
                var body = Request.Body<UserTransactionDto>();

                userBillingTransaction.Commit(body);

                return Response.AsJson(new {data = "Success"});
            };

            Post["/StageBilling/CustomerClient/Transactions/Update"] = param =>
            {
                var body = Request.Body<UserTransactionDto>();

                userBillingTransaction.Commit(body);

                return Response.AsJson(new { data = "Success" });
            };

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