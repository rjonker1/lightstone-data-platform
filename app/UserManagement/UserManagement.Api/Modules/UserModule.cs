using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DataPlatform.Shared.Helpers;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.Helpers.Nancy;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Enums;
using UserManagement.Infrastructure.Repositories;
using IBus = MemBus.IBus;

namespace UserManagement.Api.Modules
{
    public class UserModule : SecureModule
    {
        public UserModule(IBus bus, IAdvancedBus eBus, IUserRepository userRepository, CurrentNancyContext currentNancyContext)
        {
            Get["/Users/All"] = _ => Response.AsJson(Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(userRepository));

            Get["/Users"] = _ =>
            {
                var search = Context.Request.Query["search"];
                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;

                var model = this.Bind<DataTablesViewModel>();
                var dto = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(userRepository.Where(x => x.IsActive != false));//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.ToList() });
            };

            Get["/UserLookup/{filter}"] = _ =>
            {
                var filter = (string)_.filter;
                var dto = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(userRepository.Where(x => x.IsActive == true && (x.FirstName.StartsWith(filter) || x.LastName.StartsWith(filter))));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { dto });
            };

            Get["/UserCustomers/{userId:guid}"] = _ =>
            {
                var userId = (Guid)_.userId;
                var customers = userRepository.Where(x => x.Id == userId && x.IsActive == true).SelectMany(x => x.CustomerUsers.Select(cu => cu.Customer));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers));
            };

            Get["/Userlist"] = parameters =>
            {
                var filter = "";
                if (Context.Request.Query["q_word[]"].HasValue)
                    filter = (string)Context.Request.Query["q_word[]"].Value.ToString();
                var pageIndex = 0;
                var pageSize = 0;
                int.TryParse(Context.Request.Query["page_num"].Value, out pageIndex);
                int.TryParse(Context.Request.Query["per_page"].Value, out pageSize);

                Expression<Func<User, bool>> predicate = x => x.IsActive == true && x.UserType == UserType.Internal && (x.FirstName.StartsWith(filter) || x.LastName.StartsWith(filter));
                var users = new PagedList<User>(userRepository, pageIndex != 0 ? pageIndex - 1 : pageIndex, pageSize == 0 ? 10 : pageSize, predicate);

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { result = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users), cnt_whole = users.RecordsFiltered });
            };

            Get["/Users/Add"] = _ => View["Save", new UserDto()];

            Post["/Users"] = _ =>
            {
                var dto = this.BindAndValidate<UserDto>();
                dto.Created = DateTime.UtcNow;
                dto.CreatedBy = currentNancyContext.NancyContext.CurrentUser.UserName;
                dto.IsActive = true;

                if (dto.TrialExpiration == null) dto.TrialExpiration = DateTime.UtcNow.Date;

                if (ModelValidationResult.IsValid)
                {
                    //var clientUsersDto = this.Bind<List<ClientUserDto>>();
                    //dto.ClientUsers = clientUsersDto;

                    var entity = Mapper.Map(dto, userRepository.Get(dto.Id) ?? new User());

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
                var dto = Mapper.Map<User, UserDto>(userRepository.Get(guid));

                return View["Save", dto];
            };

            Get["/Users/Details/{id:guid}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<User, UserDto>(userRepository.Get(guid));

                return Response.AsJson(dto);
            };

            Put["/Users/{id}"] = parameters =>
            {
                var dto = this.BindAndValidate<UserDto>();
                dto.Modified = DateTime.UtcNow;
                dto.ModifiedBy = currentNancyContext.NancyContext.CurrentUser.UserName;

                if (dto.TrialExpiration == null) dto.TrialExpiration = DateTime.UtcNow.Date;

                if (ModelValidationResult.IsValid)
                {
                    //var clientUsersDto = this.Bind<List<ClientUserDto>>();
                    //dto.ClientUsers = clientUsersDto;
                    var entity = Mapper.Map(dto, userRepository.Get(dto.Id));

                    bus.Publish(new CreateUpdateEntity(entity, "Update"));

                    ////RabbitMQ
                    var metaEntity = Mapper.Map(entity, new UserMessage());
                    var advancedBus = new TransactionBus(eBus);
                    advancedBus.SendDynamic(metaEntity);

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Put["/Users/Lock/{id}"] = parameters =>
            {
                var dto = this.Bind<CustomerDto>();

                var entity = userRepository.Get(dto.Id);
                entity.Modified = DateTime.UtcNow;
                entity.ModifiedBy = currentNancyContext.NancyContext.CurrentUser.UserName;
                entity.IsLocked = true;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return Response.AsJson("User has been locked");
            };

            Put["/Users/UnLock/{id}"] = parameters =>
            {
                var dto = this.Bind<CustomerDto>();

                var entity = userRepository.Get(dto.Id);
                entity.Modified = DateTime.UtcNow;
                entity.ModifiedBy = currentNancyContext.NancyContext.CurrentUser.UserName;
                entity.IsLocked = false;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return Response.AsJson("User has been un-locked");
            };

            Delete["/Users/{id}"] = _ =>
            {
                var dto = this.Bind<UserDto>();
                var entity = userRepository.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("User has been soft deleted");
            };
        }
    }
}