using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EasyNetQ;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.Helpers.Nancy;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Enums;
using UserManagement.Infrastructure.Repositories;
using IBus = MemBus.IBus;

namespace UserManagement.Api.Modules
{
    public class CustomerModule : SecureModule
    {
        public CustomerModule(IBus bus, IAdvancedBus eBus, ICustomerRepository customers, IRepository<User> userRepository, IRepository<CreateSource> createSources, CurrentNancyContext currentNancyContext)
        {
            Get["/Customers"] = _ =>
            {
                var search = Context.Request.Query["search"];
                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;

                var model = this.Bind<DataTablesViewModel>();
                var dto = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers.Where(x => x.IsActive));//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.ToList() });
            };

            Get["/Customers/Add"] = parameters => View["Save", new CustomerDto()];

            Post["/Customers"] = _ =>
            {
                var dto = this.BindAndValidate<CustomerDto>();
                dto.Created = DateTime.UtcNow;
                dto.CreatedBy = currentNancyContext.NancyContext.CurrentUser.UserName;
                dto.IsActive = true;

                if (ModelValidationResult.IsValid)
                {
                    var user = userRepository.Get(dto.accountownername_primary_key);
                    var entity = Mapper.Map(dto, new Customer());
                    entity.CreateSource = createSources.FirstOrDefault(x => x.CreateSourceType == CreateSourceType.UserManagement);
                    entity.AccountOwner = user;

                    bus.Publish(new CreateUpdateEntity(entity, "Create"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Get["/Customers/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Customer, CustomerDto>(customers.Get(guid));

                return View["Save", dto];
            };

            Put["/Customers/{id}"] = parameters =>
            {
                var dto = this.BindAndValidate<CustomerDto>();
                dto.Modified = DateTime.UtcNow;
                dto.ModifiedBy = currentNancyContext.NancyContext.CurrentUser.UserName;

                if (ModelValidationResult.IsValid)
                {
                    var user = userRepository.Get(dto.accountownername_primary_key);
                    var entity = Mapper.Map(dto, customers.Get(dto.Id));
                    entity.AccountOwner = user;

                    bus.Publish(new CreateUpdateEntity(entity, "Update"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Delete["/Customers/{id}"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var entity = customers.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("Customer has been soft deleted");
            };
        }
    }
}