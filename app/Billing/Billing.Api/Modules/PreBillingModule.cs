using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using AutoMapper;
using Billing.Domain.Core.Entities;
using Billing.Domain.Core.Helpers;
//using Billing.Domain.Core.Repositories;
using Billing.Domain.Core.Repositories;
using Billing.Domain.Entities;
using Billing.Domain.Entities.DemoEntities;
using Billing.Infrastructure.Helpers;
//using Billing.Infrastructure.Repositories;
using Billing.Infrastructure.Repositories;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;
using NHibernate;
using Workflow.Billing.Domain.Entities;
using Product = Billing.Domain.Entities.DemoEntities.Product;
using User = Billing.Domain.Entities.DemoEntities.User;

namespace Billing.Api.Modules
{
    public class PreBillingModule : NancyModule
    {
        public PreBillingModule(//IPreBillingRepository preBilling, IServerPageRepo serverPageRepo,
                                IRepository<PreBilling> preBillingRepository)
        {

            Get["/PreBilling/"] = _ =>
            {

                var customerList = new List<PreBillingDto>();

                foreach (var transaction in preBillingRepository)
                {

                    var userList = new List<User>();

                    //Transactions total for customer
                    var customerTransactionsTotal = preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    //Products total for customer
                    var customerPackagesTotal = preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    //Customer
                    var customer = new PreBillingDto
                    {
                        Id = transaction.CustomerId,
                        CustomerName = transaction.CustomerName,
                        Transactions = customerTransactionsTotal,
                        Products = customerPackagesTotal
                    };

                    //Customer user
                    var user = new User
                    {
                        Id = transaction.UserId,
                        Username = transaction.Username,
                        HasTransactions = true
                    };

                    //Indices
                    var userIndex = userList.FindIndex(x => x.Id == user.Id);
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


            Get["/PreBilling/Customer/{customerId}/Users"] = param =>
            {

                var customerSearchId = new Guid(param.customerId);
                var customerUsersDetailList = new List<User>();

                foreach (var transaction in preBillingRepository.Where(x => x.CustomerId == customerSearchId))
                {
                    //User
                    var user = new User
                    {
                        Id = transaction.UserId,
                        Name = transaction.Username,
                        HasTransactions = true
                    };

                    //Index
                    var userIndex = customerUsersDetailList.FindIndex(x => x.Id == user.Id);

                    //Index restriction for new record
                    if (userIndex < 0) customerUsersDetailList.Add(user);
                }

                return Response.AsJson(new { data = customerUsersDetailList });
            };


            Get["/PreBilling/Customer/{customerId}/Packages"] = param =>
            {

                var customerSearchId = new Guid(param.customerId);
                var customerPackagesDetailList = new List<PackageDto>();

                foreach (var transaction in preBillingRepository.Where(x => x.CustomerId == customerSearchId))
                {

                    var dataProviderList = preBillingRepository.Where(x => x.CustomerId == customerSearchId)
                                            .Select(x =>
                                                new DataProviderDto()
                                                {
                                                    DataProviderId = x.DataProviderId,
                                                    DataProviderName = x.DataProviderName,
                                                    CostPrice = x.CostPrice,
                                                    RecommendedPrice = x.RecommendedPrice

                                                }).Distinct();

                    //Package
                    var package = new PackageDto()
                    {
                        PackageId = transaction.PackageId,
                        DataProviders = dataProviderList
                    };

                    //Package Index
                    var packageIndex = customerPackagesDetailList.FindIndex(x => x.PackageId == package.PackageId);

                    //Index restriction for new record
                    if (packageIndex < 0) customerPackagesDetailList.Add(package);
                }

                return Response.AsJson(new { data = customerPackagesDetailList });
            };

            //Get["/PreBilling/Transactions"] = _ => Response.AsJson(new { Products = products });

            //Get["/PreBilling/Customers"] = _ => Response.AsJson(new { Customers = customersRepo });

        }
    }

    //DTO's
    public class PreBillingDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<User> Users { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public int Products { get; set; }
        public int Transactions { get; set; }
        public string UserType { get; set; }
        public int Total { get; set; }
    }

    public class PackageDto
    {
        public Guid PackageId { get; set; }
        public Guid PackageName { get; set; }
        public IEnumerable<DataProviderDto> DataProviders { get; set; }
    }

    public class DataProviderDto
    {
        public Guid DataProviderId { get; set; }
        public string DataProviderName { get; set; }
        public double CostPrice { get; set; }
        public double RecommendedPrice { get; set; }
    }

    //Server side Paging
    public interface IServerPageRepo : IRepository<Domain.Entities.Transaction>
    {
        PagedList<Domain.Entities.Transaction> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class PreBillingDtoRepository : Repository<Domain.Entities.Transaction>, IServerPageRepo
    {
        public PreBillingDtoRepository(ISession session)
            : base(session)
        {
        }

        public PagedList<Domain.Entities.Transaction> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<Domain.Entities.Transaction>();
            //predicate = predicate.Or(x => (x.CustomerName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<Domain.Entities.Transaction>(this, pageIndex, pageSize);
        }
    }
}