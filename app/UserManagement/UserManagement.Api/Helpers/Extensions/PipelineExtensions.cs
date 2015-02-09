using System.Linq;
using System.Transactions;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.ViewEngines.Razor.HtmlHelpers;
using NHibernate;
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

        public static void AddProvincesToViewBag(this IPipelines pipelines, IWindsorContainer container, NancyContext context)
        {
            var repo = ServiceLocator.Current.GetInstance<IRepository<Province>>();
            context.ViewBag.Provinces = repo.Select(x => new SelectListItem(x.Value, x.Id + "", false));
        }
    }
}