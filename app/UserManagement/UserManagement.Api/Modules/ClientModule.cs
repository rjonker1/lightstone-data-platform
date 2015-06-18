using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DataPlatform.Shared.Helpers;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
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
    public class ClientModule : SecureModule
    {
        public ClientModule(IBus bus, IClientRepository clientRepository)
        {
            Get["/Clients"] = _ =>
            {
                var search = Context.Request.Query["search"];
                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;

                var model = this.Bind<DataTablesViewModel>();
                var dto = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clientRepository);//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.Where(x => x.IsActive != false).ToList() });
            };

            Get["/ClientLookup"] = parameters =>
            {
                var filter = "";
                if (Context.Request.Query["q_word[]"].HasValue)
                    filter = (string)Context.Request.Query["q_word[]"].Value.ToString();
                var pageIndex = 0;
                var pageSize = 0;
                int.TryParse(Context.Request.Query["page_num"].Value, out pageIndex);
                int.TryParse(Context.Request.Query["per_page"].Value, out pageSize);

                Expression<Func<Client, bool>> predicate = x => x.IsActive && x.Name.StartsWith(filter);
                var clients = new PagedList<Client>(clientRepository, pageIndex != 0 ? pageIndex - 1 : pageIndex, pageSize == 0 ? 10 : pageSize, predicate);

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { result = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients), cnt_whole = clients.RecordsFiltered });
            };

            Get["/ClientUsers/{clientId:guid}"] = _ =>
            {
                var filter = "";
                if (Context.Request.Query["q_word[]"].HasValue)
                    filter = (string)Context.Request.Query["q_word[]"].Value.ToString();
                var pageIndex = 0;
                var pageSize = 0;
                int.TryParse(Context.Request.Query["page_num"].Value, out pageIndex);
                int.TryParse(Context.Request.Query["per_page"].Value, out pageSize);

                var clientId = (Guid)_.clientId;
                var clientUsers = clientRepository.Where(x => x.Id == clientId).SelectMany(x => x.Customers.SelectMany(c => c.CustomerUsers)).Select(x => x.User);

                Expression<Func<User, bool>> predicate = x => x.IsActive == true && x.UserType == UserType.Internal && (x.FirstName.StartsWith(filter) || x.LastName.StartsWith(filter));
                var users = new PagedList<User>(clientUsers, pageIndex != 0 ? pageIndex - 1 : pageIndex, pageSize == 0 ? 10 : pageSize, predicate);

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { result = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users), cnt_whole = users.RecordsFiltered });
            };

            Get["/ClientLookup/{industryIds?}/{filter:alpha}"] = parameters =>
            {
                var dto = Enumerable.Empty<NamedEntityDto>();
                if (parameters.industryIds.Value != null)
                {
                    var industryString = (string)parameters.industryIds.Value;
                    var industryIds = industryString.Split(',').Select(x => new Guid(x)).ToArray();
                    var filter = (string)parameters.filter + "";
                    var valueEntities = clientRepository.Where(x => (x.Name + "").Trim().ToLower().StartsWith(filter.Trim().ToLower()) && x.Industries.Any(ind => industryIds.Contains(ind.IndustryId)));
                    dto = Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(valueEntities);
                }

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { dto });
            };

            Get["/Clients/Add"] = parameters => View["Save", new ClientDto()];


            Post["/Clients"] = _ =>
            {
                var dto = this.BindAndValidate<ClientDto>();
                dto.Created = DateTime.UtcNow;
                dto.CreatedBy = Context.CurrentUser.UserName;
                dto.IsActive = true;

                if (dto.TrialExpiration == null) dto.TrialExpiration = DateTime.UtcNow.Date;

                if (ModelValidationResult.IsValid)
                {
                    var entity = Mapper.Map(dto, clientRepository.Get(dto.Id) ?? new Client());

                    bus.Publish(new CreateUpdateEntity(entity, "Create"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Get["/Clients/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var client = clientRepository.Get(guid);
                var dto = Mapper.Map<Client, ClientDto>(client);
                return View["Save", dto];
            };

            Get["/Clients/Details/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var client = clientRepository.Get(guid);
                var dto = Mapper.Map<Client, ClientDto>(client);

                return Response.AsJson(dto);
            };

            Put["/Clients/{id}"] = parameters =>
            {
                var dto = this.BindAndValidate<ClientDto>();
                dto.Modified = DateTime.UtcNow;
                dto.ModifiedBy = Context.CurrentUser.UserName;

                if (dto.TrialExpiration == null) dto.TrialExpiration = DateTime.UtcNow.Date;

                if (ModelValidationResult.IsValid)
                {
                    var entity = Mapper.Map(dto, clientRepository.Get(dto.Id));

                    bus.Publish(new CreateUpdateEntity(entity, "Update"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Put["/Clients/Lock/{id}"] = parameters =>
            {
                var dto = this.Bind<ClientDto>();

                var entity = clientRepository.Get(dto.Id);
                entity.Modified = DateTime.UtcNow;
                entity.ModifiedBy = Context.CurrentUser.UserName;
                entity.IsLocked = true;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return Response.AsJson("Client has been locked");
            };

            Put["/Clients/UnLock/{id}"] = parameters =>
            {
                var dto = this.Bind<ClientDto>();

                var entity = clientRepository.Get(dto.Id);
                entity.Modified = DateTime.UtcNow;
                entity.ModifiedBy = Context.CurrentUser.UserName;
                entity.IsLocked = false;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return Response.AsJson("Client has been un-locked");
            };

            Delete["/Clients/{id}"] = _ =>
            {

                var dto = this.Bind<ClientDto>();
                var entity = clientRepository.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("Client has been soft deleted");
            };
        }

        
    }
}