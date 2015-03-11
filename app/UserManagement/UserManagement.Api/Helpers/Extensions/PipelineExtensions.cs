using System.Linq;
using System.Transactions;
using Castle.Windsor;
using Nancy;
using Nancy.Bootstrapper;
using NHibernate;
using UserManagement.Api.Helpers.NancyRazorHelpers;
using UserManagement.Domain.Core.Entities;
using UserManagement.Infrastructure.Helpers;

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

        public static void AddLookupDataToViewBag<T>(this IPipelines pipelines, IRetrieveEntitiesByType entityRetriever) where T : IValueEntity, IEntity
        {
            var type = typeof (T);
            var valueEntities = entityRetriever.GetValueEntities(type);
            var list = valueEntities.ToList().Select(x => new SelectListItem(x.Value, x.Id + ""));

            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                ctx.ViewBag[type.Name + "s"] = list;
                return null;
            });
        }
    }
}