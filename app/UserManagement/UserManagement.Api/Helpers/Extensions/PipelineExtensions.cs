using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.ViewEngines.Razor.HtmlHelpers;
using NHibernate;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.Extensions
{
    public static class PipelineExtensions
    {
         public static void AddTransactionScope(this IPipelines pipelines, IWindsorContainer container, TransactionScope scope)
        {
            //pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
            //{
            //    if (ctx.Response.StatusCode == HttpStatusCode.InternalServerError)
            //    {
            //        scope.Dispose();
            //        return;
            //    }

            //    var session = container.Resolve<IDocumentSession>();
            //    session.SaveChanges();
            //    scope.Complete();
            //    scope.Dispose();
            //});
        }

        public static void AddTransactionScope(this IPipelines pipelines, IWindsorContainer container)
        {
            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                var session = container.Resolve<ISession>();
                if (session != null)
                {
                    session.BeginTransaction();
                    return null;
                }
                return null;
            });

            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
            {
                var session = container.Resolve<ISession>();
                if (session == null)
                    return;
                if (!session.Transaction.IsActive) 
                    return;
                if (ctx.Response.StatusCode == HttpStatusCode.InternalServerError)
                    session.Transaction.Rollback();
                else
                    session.Transaction.Commit();
            });
        }

        public static void AddLookupDataToViewBag<T>(this IPipelines pipelines, IWindsorContainer container) where T : INamedEntity, IEntity
        {
            var type = typeof (T);
            var executorType = typeof(INamedEntityRepository<>).MakeGenericType(type);
            var repo = (IEnumerable)container.Resolve(executorType);
            var list = (from object item in repo select new SelectListItem(((INamedEntity) item).Name, ((IEntity) item).Id + "")).ToList();

            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                ctx.ViewBag[type.Name + "s"] = list;
                return null;
            });
        }
    }
}