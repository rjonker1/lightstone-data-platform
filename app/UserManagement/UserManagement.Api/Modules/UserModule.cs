﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.Helpers.Nancy;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Repositories;
using IBus = MemBus.IBus;

namespace UserManagement.Api.Modules
{
    public class UserModule : SecureModule
    {
        public UserModule(IBus bus, IAdvancedBus eBus, IUserRepository users, CurrentNancyContext currentNancyContext)
        {
            Get["/Users/All"] = _ => Response.AsJson(Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users));

            Get["/Users"] = _ =>
            {
                var search = Context.Request.Query["search"];
                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;

                var model = this.Bind<DataTablesViewModel>();
                var dto = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users.Where(x => x.IsActive != false));//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.ToList() });
            };

            Get["/Users/{filter:alpha}"] = parameters =>
            {
                
                
                //var dto = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(source);//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));

                //return Negotiate
                //    .WithView("Index")
                //    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.ToList() });

                var filter = (string)Context.Request.Query["q_word[]"].Value.ToString();
                var pageIndex = 0;
                var pageSize = 0;
                int.TryParse(Context.Request.Query["page_num"].Value, out pageIndex);
                int.TryParse(Context.Request.Query["per_page"].Value, out pageSize);

                var source = users.Where(x => x.IsActive != false && (x.FirstName.StartsWith(filter) || x.LastName.StartsWith(filter)));

                var packages = JsonConvert.DeserializeObject<PagedCollectionDto<PackageDto>>(null);
                //var result = packages.Select(x => new { id = x.Id, name = x.Name });
                //var dto = Mapper.Map<IEnumerable<PackageBuilder.Domain.Entities.Packages.ReadModels.Package>, IEnumerable<PackageDto>>(packages);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { result = packages.Data, cnt_whole = packages.RecordsFiltered });
            };

            Get["/Users/Add"] = _ => View["Save", new UserDto()];

            Post["/Users"] = _ =>
            {
                var dto = this.BindAndValidate<UserDto>();
                dto.Created = DateTime.UtcNow;
                dto.CreatedBy = currentNancyContext.NancyContext.CurrentUser.UserName;
                dto.IsActive = true;

                if (ModelValidationResult.IsValid)
                {
                    var clientUsersDto = this.Bind<List<ClientUserDto>>();
                    dto.ClientUsers = clientUsersDto;

                    var entity = Mapper.Map(dto, users.Get(dto.Id) ?? new User());

                    bus.Publish(new CreateUpdateEntity(entity, "Create"));

                    ////RabbitMQ
                    var metaEntity = Mapper.Map(entity, new UserMessage());
                    var advancedBus = new TransactionBus(eBus);
                    advancedBus.SendDynamic(metaEntity);

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Get["/Users/{id:guid}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<User, UserDto>(users.Get(guid));

                return View["Save", dto];
            };

            Put["/Users/{id}"] = parameters =>
            {
                var dto = this.BindAndValidate<UserDto>();
                dto.Modified = DateTime.UtcNow;
                dto.ModifiedBy = currentNancyContext.NancyContext.CurrentUser.UserName;

                if (ModelValidationResult.IsValid)
                {
                    var clientUsersDto = this.Bind<List<ClientUserDto>>();
                    dto.ClientUsers = clientUsersDto;
                    var entity = Mapper.Map(dto, users.Get(dto.Id));

                    bus.Publish(new CreateUpdateEntity(entity, "Update"));

                    ////RabbitMQ
                    var metaEntity = Mapper.Map(entity, new UserMessage());
                    var advancedBus = new TransactionBus(eBus);
                    advancedBus.SendDynamic(metaEntity);

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Delete["/Users/{id}"] = _ =>
            {
                var dto = this.Bind<UserDto>();
                var entity = users.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("User has been soft deleted");
            };
        }
    }
}