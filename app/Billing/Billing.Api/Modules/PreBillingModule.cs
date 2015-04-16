using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                                //IRepository<Customer> customersRepo, IRepository<User> users, IRepository<TransactionMocks> transactions, IRepository<Product> products,
                                IRepository<PreBilling> preBillingRepository)
        {

            Get["/PreBilling/"] = _ =>
            {
                ////var model = this.Bind<DataTablesViewModel>();

                //var offset = Context.Request.Query["offset"];
                //var limit = Context.Request.Query["limit"];

                //if (offset == null) offset = 0;
                //if (limit == null) limit = 10;

                //var userIds = users.ToList().Where(x => x.HasTransactions).Select(x => x.Id);

                //var customers = customersRepo.Where(c => c.Users.Any(x => userIds.Contains(x.Id)));
                //var dto = Mapper.Map<IEnumerable<Customer>, IEnumerable<PreBillingDto>>(customers, new[] { new PreBillingDto() });

                ////const string dto = "gh";
                //return Negotiate
                //    .WithView("Index")
                //    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });


                var customerList = new List<PreBillingDto>();


                foreach (var transaction in preBillingRepository)
                {
                    //Transactions total for customer
                    var customerTransactionsTotal = preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.TransactionId).Distinct().Count();
                    //Products total for customer
                    var customerPackagesTotal = preBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                                                        .Select(x => x.PackageId).Distinct().Count();

                    var userList = new List<User>();
                    //var customerTransactionsList = new List<TransactionMocks>();

                    var customer = new PreBillingDto();
                    var user = new User();

                    //Customer
                    customer.Id = transaction.CustomerId;
                    customer.CustomerName = transaction.CustomerName;
                    customer.Transactions = customerTransactionsTotal;
                    customer.Products = customerPackagesTotal;

                    //Customer user
                    user.Id = transaction.UserId;
                    user.Username = transaction.Username;
                    user.HasTransactions = true;


                    //Indices
                    var userIndex = userList.FindIndex(x => x.Id == user.Id);
                    var customerIndex = customerList.FindIndex(x => x.Id == customer.Id);


                    //Check lists don't contain indices for new records
                    if (userIndex < 0) userList.Add(user);

                    customer.Users = userList;

                    if (customerIndex < 0) customerList.Add(customer);
                }

                //return Response.AsJson(new { data = customerList });
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customerList });
            };

            //Get["/PreBilling/Customer/{id}/Users"] = param =>
            //{
            //    var searchId = new Guid(param.id);

            //    var userIds = users.ToList().Where(x => x.HasTransactions).Select(x => x.Id);
            //    var customerUsers = customersRepo.Where(x => x.Id.Equals(searchId)).Select(x => x.Users.Where(u => userIds.Contains(u.Id)));

            //    return Response.AsJson(new { data = customerUsers.Select(x => x).SelectMany(y => y) });
            //};

            //Get["/PreBilling/Customer/{id}/Products"] = param =>
            //{
            //    var searchId = new Guid(param.id);
            //    var customerProducts = customersRepo.Get(searchId).Products;

            //    return Response.AsJson(new { data = customerProducts });
            //};

            //Get["/PreBilling/Transactions"] = _ => Response.AsJson(new { Products = products });

            //Get["/PreBilling/Customers"] = _ => Response.AsJson(new { Customers = customersRepo });

        }
    }

    public class PreBillingDto //: Entity
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

        public PreBillingDto() { }

        //public PreBillingDto(Guid id, string customerName, IEnumerable<User> users, string type, string owner, IEnumerable<Product> products, IEnumerable<TransactionMocks> transactions, string userType, int total)
        //    : base(id)
        //{
        //    CustomerName = customerName;
        //    Users = users;
        //    Type = type;
        //    Owner = owner;
        //    Products = products;
        //    Transactions = transactions;
        //    UserType = userType;
        //    Total = total;
        //}
    }

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