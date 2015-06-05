using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;
using AutoMapper;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.Helpers.Nancy;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Repositories;
using IBus = MemBus.IBus;

namespace UserManagement.Api.Modules
{
    public class ClientModule : SecureModule
    {
        public ClientModule(IBus bus, IClientRepository clients, CurrentNancyContext currentNancyContext)
        {
            Get["/Clients"] = _ =>
            {

                var search = Context.Request.Query["search"];
                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;

                var model = this.Bind<DataTablesViewModel>();
                var dto = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients);//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.Where(x => x.IsActive != false).ToList() });
            };

            Get["/ClientLookup/{industryIds?}/{filter:alpha}"] = parameters =>
            {
                var dto = Enumerable.Empty<NamedEntityDto>();
                if (parameters.industryIds.Value != null)
                {
                    var industryString = (string)parameters.industryIds.Value;
                    var industryIds = industryString.Split(',').Select(x => new Guid(x)).ToArray();
                    var filter = (string)parameters.filter + "";
                    var valueEntities = clients.Where(x => (x.Name + "").Trim().ToLower().StartsWith(filter.Trim().ToLower()) && x.Industries.Any(ind => industryIds.Contains(ind.IndustryId)));
                    dto = Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(valueEntities);
                }

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { dto });
            };

            Get["/Clients/Add"] = parameters => View["Save", new ClientDto()];

            Get["/Clients/ImportUsers"] = _ => View["ImportClientUser"];

            Get["/Clients/ImportUsers/FilesUpload"] = _ => Response.AsJson("");

            //TODO: Error checking for file type. Allow csv only
            Post["/Clients/ImportUsers/FilesUpload"] = _ =>
            {
                var filesUploaded = Request.Files;

                var files = new List<FileUploadDto>();
                var clientImportUsers = new List<UserAliasDto>();

                foreach (var httpFile in filesUploaded)
                {
                    if (httpFile.ContentType != "text/csv")
                    {
                        // Response for file upload component
                        files.Add(new FileUploadDto
                        {
                            name = httpFile.Name,
                            size = Convert.ToInt32(httpFile.Value.Length),
                            error = "File type not allowed"
                        });

                        break;
                    };

                    // CSV to object
                    using (var reader = new StreamReader(httpFile.Value))
                    {
                        var contents = reader.ReadToEnd().Split('\n');
                        var csv = from line in contents
                                  select line.Split(',').ToArray();

                        clientImportUsers.AddRange(csv.Skip(1).TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0)
                            .Select(row => new UserAliasDto
                        {
                            UuId = row[0],
                            FirstName = row[1],
                            LastName = row[2],
                            UserName = row[3].Replace("\r", "")
                        }));

                        foreach (var clientImportUser in clientImportUsers)
                        {
                            var entity = Mapper.Map(clientImportUser, new UserAlias());
                            bus.Publish(new CreateUpdateEntity(entity, "Create"));
                        }
                        
                    }

                    // Response for file upload component
                    files.Add(new FileUploadDto
                    {
                        name = httpFile.Name,
                        size = Convert.ToInt32(httpFile.Value.Length),
                        thumbnailUrl = "http://icons.iconarchive.com/icons/custom-icon-design/pretty-office-2/72/success-icon.png",
                        deleteType = "DELETE"
                    });
                }

                JObject fileResponseJsonObject = new JObject(new JProperty("files", JsonConvert.SerializeObject(files)));

                return Response.AsJson(fileResponseJsonObject);
            };

            Post["/Clients"] = _ =>
            {
                var dto = this.BindAndValidate<ClientDto>();
                dto.Created = DateTime.UtcNow;
                dto.CreatedBy = currentNancyContext.NancyContext.CurrentUser.UserName;
                dto.IsActive = true;

                if (dto.TrialExpiration == null) dto.TrialExpiration = DateTime.UtcNow.Date;

                if (ModelValidationResult.IsValid)
                {
                    var entity = Mapper.Map(dto, clients.Get(dto.Id) ?? new Client());

                    bus.Publish(new CreateUpdateEntity(entity, "Create"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Get["/Clients/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var client = clients.Get(guid);
                var dto = Mapper.Map<Client, ClientDto>(client);
                return View["Save", dto];
            };

            Put["/Clients/{id}"] = parameters =>
            {
                var dto = this.BindAndValidate<ClientDto>();
                dto.Modified = DateTime.UtcNow;
                dto.ModifiedBy = currentNancyContext.NancyContext.CurrentUser.UserName;

                if (dto.TrialExpiration == null) dto.TrialExpiration = DateTime.UtcNow.Date;

                if (ModelValidationResult.IsValid)
                {
                    var entity = Mapper.Map(dto, clients.Get(dto.Id));

                    bus.Publish(new CreateUpdateEntity(entity, "Update"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Put["/Clients/Lock/{id}"] = parameters =>
            {
                var dto = this.Bind<ClientDto>();

                var entity = clients.Get(dto.Id);
                entity.Modified = DateTime.UtcNow;
                entity.ModifiedBy = currentNancyContext.NancyContext.CurrentUser.UserName;
                entity.IsLocked = true;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return Response.AsJson("Client has been locked");
            };

            Put["/Clients/UnLock/{id}"] = parameters =>
            {
                var dto = this.Bind<ClientDto>();

                var entity = clients.Get(dto.Id);
                entity.Modified = DateTime.UtcNow;
                entity.ModifiedBy = currentNancyContext.NancyContext.CurrentUser.UserName;
                entity.IsLocked = false;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return Response.AsJson("Client has been un-locked");
            };

            Delete["/Clients/{id}"] = _ =>
            {

                var dto = this.Bind<ClientDto>();
                var entity = clients.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("Client has been soft deleted");
            };
        }

        private class FileUploadDto
        {
            public string name { get; set; }
            public int size { get; set; }
            public string thumbnailUrl { get; set; }
            public string deleteType { get; set; }

            public string error { get; set; }
        }
    }
}