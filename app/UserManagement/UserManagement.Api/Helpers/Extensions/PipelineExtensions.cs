using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Nancy;
using Nancy.Bootstrapper;
using NHibernate;
using UserManagement.Api.Helpers.NancyRazorHelpers;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Helpers;
using UserManagement.Infrastructure.Repositories;
using IEntity = UserManagement.Domain.Core.Entities.IEntity;

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

        public static void AddLookupDataToViewBag(this IPipelines pipelines, string key, object value) 
        {
            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                ctx.ViewBag[key] = value;
                return null;
            });
        }

        public static void PublishTransactionToQueue(this IPipelines pipelines, IWindsorContainer container)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(nancyContext =>
            {

                //Customer
                if (nancyContext.Request.Method == "POST" && nancyContext.Request.Url.Path.Contains("Customer"))
                {

                    var customers = container.Resolve<ICustomerRepository>().Select(x => x);

                    foreach (var customer in customers)
                    {

                        //Set new customer AccountNumber
                        //Send to Queue
                        if (customer.CustomerAccountNumber.Customer == null)
                        {
                            customer.CustomerAccountNumber.Customer = customer;

                            ////RabbitMQ
                            var metaEntity = Mapper.Map(customer, new CustomerMessage());
                            metaEntity.BillingType = "Response"; //TODO: Map from Contract
                            var advancedBus = new TransactionBus(container.Resolve<IAdvancedBus>());
                            advancedBus.SendDynamic(metaEntity);
                        }
                    }
                }

                if (nancyContext.Request.Method == "PUT" && nancyContext.Request.Url.Path.Contains("Customer"))
                {

                    var valueArray = nancyContext.Request.Url.ToString().Split('/');
                    var customers = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(container.Resolve<ICustomerRepository>());

                    foreach (var val in valueArray)
                    {
                        Guid urlId;
                        if (Guid.TryParse(val, out urlId))
                        {

                            var dto = customers.FirstOrDefault(x => x.Id == urlId);

                            ////RabbitMQ
                            var metaEntity = Mapper.Map(dto, new CustomerMessage());
                            metaEntity.BillingType = "Response"; //TODO: Map from Contract
                            var advancedBus = new TransactionBus(container.Resolve<IAdvancedBus>());
                            advancedBus.SendDynamic(metaEntity);

                        }
                    }
                }

                //Client
                if (nancyContext.Request.Method == "POST" && nancyContext.Request.Url.Path.Contains("Client"))
                {

                    var clients = container.Resolve<IClientRepository>().Select(x => x);

                    foreach (var client in clients)
                    {

                        //Set new client AccountNumber
                        //Send to Queue
                        if (client.ClientAccountNumber.Client == null)
                        {
                            client.ClientAccountNumber.Client = client;

                            ////RabbitMQ
                            var metaEntity = Mapper.Map(client, new ClientMessage());
                            metaEntity.BillingType = "Response"; //TODO: Map from Contract
                            var advancedBus = new TransactionBus(container.Resolve<IAdvancedBus>());
                            advancedBus.SendDynamic(metaEntity);
                        }
                    }
                }

                if (nancyContext.Request.Method == "PUT" && nancyContext.Request.Url.Path.Contains("Client"))
                {

                    var valueArray = nancyContext.Request.Url.ToString().Split('/');
                    var clients = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(container.Resolve<IClientRepository>());

                    foreach (var val in valueArray)
                    {
                        Guid urlId;
                        if (Guid.TryParse(val, out urlId))
                        {

                            var dto = clients.FirstOrDefault(x => x.Id == urlId);

                            ////RabbitMQ
                            var metaEntity = Mapper.Map(dto, new ClientMessage());
                            metaEntity.BillingType = "Response"; //TODO: Map from Contract
                            var advancedBus = new TransactionBus(container.Resolve<IAdvancedBus>());
                            advancedBus.SendDynamic(metaEntity);

                        }
                    }
                }
            });
        }
    }
}