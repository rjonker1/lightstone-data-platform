using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class StageBillingModule : NancyModule
    {
        public StageBillingModule(//IPreBillingRepository preBilling, IServerPageRepo serverPageRepo,
                                IRepository<StageBilling> stageBillingRepository)
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
                    //Products total for customer
                    var customerPackagesTotal = stageBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
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
                            Transactions = customerTransactionsTotal,
                            Products = customerPackagesTotal
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


            Get["/StageBilling/Customer/{customerId}/Users"] = param =>
            {

                var customerSearchId = new Guid(param.customerId);
                var customerUsersDetailList = new List<User>();

                foreach (var transaction in stageBillingRepository.Where(x => x.CustomerId == customerSearchId))
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


            Get["/StageBilling/Customer/{customerId}/Packages"] = param =>
            {

                var customerSearchId = new Guid(param.customerId);
                var customerPackagesDetailList = new List<PackageDto>();

                foreach (var transaction in stageBillingRepository.Where(x => x.CustomerId == customerSearchId || x.ClientId == customerSearchId))
                {

                    var dataProviderList = stageBillingRepository.Where(x => x.CustomerId == customerSearchId || x.ClientId == customerSearchId)
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

            //Get["/PreBilling/Transactions"] = _ => Response.AsJson(new { Products = products });

            //Get["/PreBilling/Customers"] = _ => Response.AsJson(new { Customers = customersRepo });

        }
    }

    //DTO's
    public class StageBillingDto
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

    //public class PackageDto
    //{
    //    public Guid PackageId { get; set; }
    //    public Guid PackageName { get; set; }
    //    public IEnumerable<DataProviderDto> DataProviders { get; set; }
    //}

    //public class DataProviderDto
    //{
    //    public Guid DataProviderId { get; set; }
    //    public string DataProviderName { get; set; }
    //    public double CostPrice { get; set; }
    //    public double RecommendedPrice { get; set; }

    //    public Guid PackageId { get; set; }
    //    public string PackageName { get; set; }
    //}

    ////Server side Paging
    //public interface IServerPageRepo : IRepository<Transaction>
    //{
    //    PagedList<Transaction> Search(string searchValue, int pageIndex, int pageSize);
    //}

    //public class PreBillingDtoRepository : Repository<Transaction>, IServerPageRepo
    //{
    //    public PreBillingDtoRepository(ISession session)
    //        : base(session)
    //    {
    //    }

    //    public PagedList<Transaction> Search(string searchValue, int pageIndex, int pageSize)
    //    {
    //        var predicate = PredicateBuilder.False<Transaction>();
    //        //predicate = predicate.Or(x => (x.CustomerName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
    //        return new PagedList<Transaction>(this, pageIndex, pageSize);
    //    }
    //}
}