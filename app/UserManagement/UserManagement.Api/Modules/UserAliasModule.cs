using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Entities.Commands.UserAliases;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class UserAliasModule : SecureModule
    {
        public UserAliasModule(IBus bus, IRepository<ClientUserAlias> userAliasRepository, IRepository<User> usereRepository)
        {
            Get["/UserAliases/{clientId:guid}"] = _ =>
            {
                var clientId = (Guid)_.clientId;
                var aliases = userAliasRepository.Where(x => x.Client.Id == clientId);
                return Response.AsJson(Mapper.Map<IEnumerable<ClientUserAlias>, IEnumerable<UserAliasDto>>(aliases));
            };

            //TODO: Error checking for file type. Allow csv only
            Post["/UserAliases/ImportUsers/FilesUpload/{clientId:guid}"] = _ =>
            {
                var clientId = (Guid)_.clientId;
                var filesUploaded = Request.Files;
                var files = new List<FileUploadDto>();
                var clientImportUsers = new List<UserAliasDto>();

                foreach (var httpFile in filesUploaded)
                {
                    //if (httpFile.ContentType != "text/csv")
                    //{
                    //    // Response for file upload component
                    //    files.Add(new FileUploadDto
                    //    {
                    //        name = httpFile.Name,
                    //        size = Convert.ToInt32(httpFile.Value.Length),
                    //        error = "File type not allowed"
                    //    });

                    //    break;
                    //};

                    // CSV to object
                    using (var reader = new StreamReader(httpFile.Value))
                    {
                        var contents = reader.ReadToEnd().Split('\n');
                        var csv = from line in contents select line.Split(',').ToArray();

                        clientImportUsers.AddRange(csv.Skip(1).TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0)
                            .Select(row => new UserAliasDto
                            {
                                UuId = row[0],
                                FirstName = row[1],
                                LastName = row[2],
                                UserName = row[3].Replace("\r", ""),
                                ClientId = clientId
                            }));

                        foreach (var clientImportUser in clientImportUsers)
                        {
                            var exists = userAliasRepository.Any(x => x.Client.Id == clientId && x.UserName.Trim().ToLower() == clientImportUser.UserName.Trim().ToLower());
                            if (exists)
                                throw new LightstoneAutoException("{0} already exists".FormatWith(clientImportUser.UserName));
                            var entity = Mapper.Map(clientImportUser, new ClientUserAlias());
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

                var fileResponseJsonObject = new JObject(new JProperty("files", JsonConvert.SerializeObject(files)));

                return Response.AsJson(fileResponseJsonObject);
            };

            Post["/UserAliases/LinkAlias"] = _ =>
            {
                var dto = this.Bind<AliasDto>();
                var command = new LinkUserAliasCommand(dto.AliasId, dto.CustomerId, dto.UserId);
                bus.Publish(command);

                return Response.AsJson("Saved!");
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