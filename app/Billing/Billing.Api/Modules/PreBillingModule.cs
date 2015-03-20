using System;
using System.Collections.Generic;
using Billing.Domain.Core.Entities;
using Billing.Domain.Core.Helpers;
using Billing.Domain.Core.Repositories;
using Billing.Domain.Entities;
using Billing.Domain.Entities.DemoEntities;
using Billing.Infrastructure.Helpers;
using Billing.Infrastructure.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;
using NHibernate;

namespace Billing.Api.Modules
{
    public class PreBillingModule : NancyModule
    { 
        public PreBillingModule(IPreBillingRepository preBilling, IServerPageRepo serverPageRepo, 
                                IRepository<Customer> customers, IRepository<User> users, IRepository<TransactionMocks> transactions, IRepository<Product> products)
        {

            Get["/PreBilling/"] = _ =>
            {
                //var model = this.Bind<DataTablesViewModel>();

                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;
                //var dto = new PreBillingDto();
                //var dto = (IEnumerable<PreBilling>)(preBilling.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));

                //var dto = (IEnumerable<PreBillingDto>)Mapper.Map<IEnumerable<PreBilling>, IEnumerable<PreBillingDto>>(serverPageRepo.Search("", offset, limit));

                //var dto = new ArrayList
                //{
                //    new PreBilling()
                //};

                const string dto = "gh";
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
            };

            Get["/PreBilling/Users"] = _ => Response.AsJson(new { Users = users });

            Get["/PreBilling/Transactions"] = _ => Response.AsJson(new { Transactions = transactions });

            Get["/PreBilling/Products"] = _ => Response.AsJson(new { Products = products });

            Get["/PreBilling/Customers"] = _ => Response.AsJson(new {Customers = customers});

        }
    }

    public class PreBillingDto : Entity
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<User> Users { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<TransactionMocks> Transactions { get; set; }
        public string UserType { get; set; }
        public int Total { get; set; }

        public PreBillingDto(Guid id, string customerName, IEnumerable<User> users, string type, string owner, IEnumerable<Product> products, IEnumerable<TransactionMocks> transactions, string userType, int total)
            : base(id)
        {
            CustomerName = customerName;
            Users = users;
            Type = type;
            Owner = owner;
            Products = products;
            Transactions = transactions;
            UserType = userType;
            Total = total;
        }
    }

    public interface IServerPageRepo : IRepository<PreBilling>
    {
        PagedList<PreBilling> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class PreBillingDtoRepository : Repository<PreBilling>, IServerPageRepo
    {
        public PreBillingDtoRepository(ISession session)
            : base(session)
        {
        }

        public PagedList<PreBilling> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<PreBilling>();
            //predicate = predicate.Or(x => (x.CustomerName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<PreBilling>(this, pageIndex, pageSize);
        }
    }
}