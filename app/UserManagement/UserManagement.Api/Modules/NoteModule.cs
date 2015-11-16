using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Modules
{
    public class NoteModule : SecureModule
    {
        public NoteModule(IEntityByTypeRepository entityRetriever, IBus bus)
        {
            Get["/Notes/{type}/{id}"] = _ =>
            {
                var typeName = _.type.ToString();
                var type = Type.GetType(typeName);
                var notes = Mapper.Map<IEnumerable<Note>, IEnumerable<NoteItemDto>>(entityRetriever.GetEntityNotes(type)) as IEnumerable<NoteItemDto>;
                var noteDto = new NoteDto(_.id, type, notes != null ? notes.Where(x => x != null) : Enumerable.Empty<NoteItemDto>());

                return Negotiate
                    .WithView("Index")
                    .WithModel(noteDto)
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), noteDto);
            };

            Post["/Notes"] = _ =>
            {
                var dto = this.Bind<NoteDto>();
                dto.CreatedBy = Context.CurrentUser.UserName;
                
                if (ModelValidationResult.IsValid)
                {
                    var entity = (EntityNote)Mapper.Map(dto, null, typeof(NoteDto), Type.GetType(dto.AssemblyQualifiedName));

                    bus.Publish(new CreateUpdateEntity(entity, "Read"));
                }

                return Response.AsJson(dto.AssemblyQualifiedName);
            };
        }
    }
}