using System.Transactions;
using Castle.Windsor;
using Nancy;
using Nancy.Bootstrapper;
using Raven.Client;

namespace PackageBuilder.Api.Helpers.Extensions
{
    public static class PipelineExtensions
    {
        public static void AddTransactionScope(this IPipelines pipelines, IWindsorContainer container, TransactionScope scope)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
            {
                if (ctx.Response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    scope.Dispose();
                    return;
                }

                var session = container.Resolve<IDocumentSession>();
                session.SaveChanges();
                scope.Complete();
                scope.Dispose();
            });
        }
    }
}