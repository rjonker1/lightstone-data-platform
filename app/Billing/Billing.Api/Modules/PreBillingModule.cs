using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Api.ViewModels;
using Billing.Domain.Core.Helpers;
using Billing.Domain.Core.Repositories;
using Billing.Domain.Entities;
using Billing.Domain.Entities.DemoEntities;
using Billing.Infrastructure.Helpers;
using Billing.Infrastructure.Repositories;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using NHibernate;

namespace Billing.Api.Modules
{
    public class PreBillingModule : NancyModule
    {
        public PreBillingModule(IPreBillingRepository preBilling, IServerPageRepo serverPageRepo)
        {

            Get["/PreBilling/"] = _ =>
            {
                var model = this.Bind<DataTablesViewModel>();

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

                const string dto = "[{'customerName':'CUST01','numUsers':{'name':'TT','surname':'QQ','numTransactionsUser':322,'id':'00000000-0000-0000-0000-000000000000','modified':null,'modifiedBy':null,'created':null,'createdBy':null},'type':'Type123','owner':'Testeroonie','numProducts':{'productName':'PROD001','id':'00000000-0000-0000-0000-000000000000','modified':null,'modifiedBy':null,'created':null,'createdBy':null},'numTransactions':{'transactionDetail':'Trans001','state':'Successful','id':'00000000-0000-0000-0000-000000000000','modified':null,'modifiedBy':null,'created':null,'createdBy':null},'userType':'User Type 1','total':123,'id':'b94ec2d5-bc22-4d5b-b2f4-12df26060077','modified':null,'modifiedBy':null,'created':null,'createdBy':null}]";
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
            };

            Get["/PreBilling/Users"] = _ =>
            {
                var dto = new ArrayList
                {
                    //new PreBilling().NumUsers
                };
                return Negotiate
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
            };

            Get["/PreBilling/Products"] = _ =>
            {
                var dto = new ArrayList
                {
                    //new PreBilling().NumProducts
                };
                return Negotiate
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
            };

        }
    }

    public class PreBillingDto
    {
        public Guid Id = Guid.NewGuid();
        public string CustomerName { get; set; }
        public User NumUsers { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public Product NumProducts { get; set; }
        public TransactionMocks NumTransactions { get; set; }
        public string UserType { get; set; }
        public int Total { get; set; }
    }

    //public class UsersDto
    //{
    //    public Guid Id = Guid.NewGuid();
    //    public string Name = "TT";
    //    public string Surname = "QQ";
    //}

    //public class ProductsDto
    //{
    //    public Guid Id = Guid.NewGuid();
    //    public string ProductName = "Product 123";
    //}

    //public class TransactionsDto
    //{
    //    public Guid Id = Guid.NewGuid();
    //    public string TransactionDetail = "trans001";
    //}

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