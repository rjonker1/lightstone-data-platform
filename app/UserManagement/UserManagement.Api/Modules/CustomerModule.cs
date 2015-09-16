using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;
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
        public CustomerModule(IBus bus, IAdvancedBus eBus, ICustomerRepository customers, IRepository<User> userRepository)
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

            Get["/CustomerLookup/{industryIds?}/{filter:alpha}"] = parameters =>
            {
                var dto = Enumerable.Empty<NamedEntityDto>();
                if (parameters.industryIds.Value != null)
                {
                    var industryString = (string)parameters.industryIds.Value;
                    var industryIds = industryString.Split(',').Select(x => new Guid(x)).ToArray();
                    var filter = (string)parameters.filter + "";
                    var valueEntities = customers.Where(x => (x.Name + "").Trim().ToLower().StartsWith(filter.Trim().ToLower()) && x.Industries.Any(ind => industryIds.Contains(ind.IndustryId)));
                    dto = Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(valueEntities);
                }
                
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { dto });
            };

            Get["/Customers/Add"] = parameters =>
            {
                return View["Save", new CustomerDto()];
            };

            Post["/Customers"] = _ =>
            {
                var dto = this.BindAndValidate<CustomerDto>();
                dto.CreatedBy = Context.CurrentUser.UserName;
                dto.IsActive = true;

                if(dto.TrialExpiration == null) dto.TrialExpiration = DateTime.UtcNow.Date;

                if (ModelValidationResult.IsValid)
                {
                    var user = userRepository.Get(dto.accountownerlastname_primary_key);
                    var entity = Mapper.Map(dto, new Customer(dto.Name));
                    entity.CreateSource = CreateSourceType.UserManagement;
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

            Get["/Customers/Details/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Customer, CustomerDto>(customers.Get(guid));

                return Response.AsJson(dto);
            };

            Put["/Customers/{id}"] = parameters =>
            {
                var dto = this.BindAndValidate<CustomerDto>();
                dto.ModifiedBy = Context.CurrentUser.UserName;

                if (dto.TrialExpiration == null) dto.TrialExpiration = DateTime.UtcNow.Date;

                if (ModelValidationResult.IsValid)
                {
                    var user = userRepository.Get(dto.accountownerlastname_primary_key);
                    var entity = Mapper.Map(dto, customers.Get(dto.Id));
                    entity.AccountOwner = user;

                    bus.Publish(new CreateUpdateEntity(entity, "Update"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Put["/Customers/Lock/{id}"] = parameters =>
            {
                var dto = this.Bind<CustomerDto>();

                var entity = customers.Get(dto.Id);
                entity.Modified = DateTime.UtcNow;
                entity.ModifiedBy = Context.CurrentUser.UserName;
                entity.IsLocked = true;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return Response.AsJson("Customer has been locked");
            };

            Put["/Customers/UnLock/{id}"] = parameters =>
            {
                var dto = this.Bind<CustomerDto>();

                var entity = customers.Get(dto.Id);
                entity.Modified = DateTime.UtcNow;
                entity.ModifiedBy = Context.CurrentUser.UserName;
                entity.IsLocked = false;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return Response.AsJson("Customer has been un-locked");
            };

            Delete["/Customers/{id}"] = _ =>
            {
                this.RequiresClaims(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

                var dto = this.Bind<CustomerDto>();
                var entity = customers.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("Customer has been soft deleted");
            };
        }
    }
}