using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Helpers;
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
            Get["/Notes/{type}/{id:guid}/{returnPath}"] = _ =>
            {
                var noteDto = NoteDto(entityRetriever, _) as NoteDto;

                return Negotiate
                    .WithView("Index")
                    .WithModel(noteDto)
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), noteDto);
            };

            Get["/Notes/{type}/{id:guid}/{returnPath}/{pageIndex:int}"] = _ =>
            {
                var noteDto = NoteDto(entityRetriever, _) as NoteDto;

                return Negotiate
                    .WithView("NoteBody")
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

                return Response.AsRedirect(Context.Request.Headers.Referrer + "#/" + dto.RedirectPath);
            };
        }

        private static NoteDto NoteDto(IEntityByTypeRepository entityRetriever, dynamic _)
        {
            var typeName = _.type.ToString();
            var type = Type.GetType(typeName);
            var pageIndex = 0;
            int.TryParse(_.pageIndex, out pageIndex);
            var notes = new PagedList<EntityNote>(entityRetriever.GetEntityNotes(type), pageIndex != 0 ? pageIndex - 1 : pageIndex, 10);
            var noteItems = Mapper.Map<IEnumerable<EntityNote>, IEnumerable<NoteItemDto>>(notes);
            var noteDto = new NoteDto(_.id, type,
                noteItems != null ? noteItems.Where(x => x != null) : Enumerable.Empty<NoteItemDto>())
            {
                RedirectPath = _.returnPath,
                HasNextPage = notes.HasNextPage,
                HasPreviousPage = notes.HasPreviousPage,
                PageIndex = notes.PageIndex,
                PageSize = notes.PageSize,
                PageTotal = notes.PageTotal,
                RecordsFiltered = notes.RecordsFiltered,
                RecordsTotal = notes.RecordsTotal
            };
            return noteDto;
        }
    }
}